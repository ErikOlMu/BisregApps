using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Xobject;
using iText.Kernel.Utils;
using System.Collections.Generic;
using iText.Kernel.Geom;
using iText.Layout.Element;
using System;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Layout;
using iText.Layout.Properties;
using BisregApi.Diseño;
using iText.Layout.Renderer;
using iText.Layout.Layout;
using iText.Layout.Borders;
using iText.Kernel.Pdf.Colorspace;
using iText.Kernel.Pdf.Function;
using iText.Kernel.Colors;
using iText.Pdfoptimizer;
using iText.Pdfoptimizer.Handlers;
using iText.Pdfoptimizer.Handlers.Imagequality.Processors;
using iText.Pdfoptimizer.Handlers.Converters;
using System.IO;

namespace BisregApi.PDF
{
    public class PDFPlotter
    {
        
        //DirDest: Directorio de Destino de los archivos resultantes
        //Comanda: Nombre de pedido
        //Source: Referencia de destino
        //MaxWidth: Ancho machimo del plotter
        //MaxHeight: Altura maxima del plotter
        //Copias: Nº de copias que hacen falta
        //MarginObject Margen entre las piezas
        //MarginPlotter El padding de la pieza
        //Vertical indica el sentido de colocacion de los objetos del plotter
        //Info activar la info de la plancha
        //Tamañoinfo es el ancho que queremos que ocupe la info
        //Contador es el contador de Plancha que lleva ya que al haber mas copias de las que caben en una plancha este metodo es recursivo y se invoca a si mismo

        //Metodo para crear una plancha Genero Personalizado
        public static int CrearPlancha(ItemProduccion item ,string dirdest, string Source, double MaxWidth, double MaxHeight, int Copias , Margin MarginObject , Margin PaddingPlotter , bool Vertical = true , bool Info = true,double TamañoInfo = 20 ,bool CutContour = false, int Contador = 0)
        {

            string Comanda = item.Pedido + item.Codigo;
            string TextInfo = item.Codigo + " " + item.Pedido;



            //Si no esta activada la Info le quitamos el tamaño
            if (!Info) TamañoInfo = 0;

            //Le resto el Padding al tamaño maximo del Plotter y al ancho le quitamos el tamaño de la info
            MaxHeight = MaxHeight - (PaddingPlotter.MarginHeight * 2);
            MaxWidth = MaxWidth - (PaddingPlotter.MarginWidth * 2) - TamañoInfo;

            //Abro el PDF de Source y obtengo la primera pagina
            PdfDocument SourcePDF = new PdfDocument(new PdfReader(Source));
            PdfPage origPage = SourcePDF.GetFirstPage();


            //Creo el pdf de Destino de la Plancha
            PdfDocument pdf = new PdfDocument(new PdfWriter(dirdest+ "\\" + Comanda+"-"+Contador+".pdf"));


            //Copio la primera pagina
            PdfFormXObject pagecopy = origPage.CopyAsFormXObject(pdf);


            //Obtengo el tamaño de la pagina de origen mas el Margen total que queremos entre piezas
            double origHeight = origPage.GetPageSize().GetHeight()+ MarginObject.MarginHeight;
            double origWidth = origPage.GetPageSize().GetWidth()+ MarginObject.MarginWidth;


            //Calculo las Filas y las Columnas
            int Columnas = (int) Math.Floor((MaxWidth) / origWidth);
            int Filas = (int) Math.Floor((MaxHeight) / origHeight);


            //Si hace falta crear mas  =)
            if (Columnas * Filas < Copias)
            {
                //Volvemos a sumar el padding a la hora de crear otra plancha
                if (Columnas != 0 || Filas != 0) CrearPlancha(item,dirdest, Source, MaxWidth + (PaddingPlotter.MarginWidth* 2) + TamañoInfo, MaxHeight + (PaddingPlotter.MarginHeight* 2), (Copias - (Columnas * Filas)), MarginObject, PaddingPlotter, Vertical,Info,TamañoInfo,CutContour,Contador+1);
                //Error 0002 No cabe ningun objeto, Aumente el tamaño maximo o reduzca el origen
                else return 2;
               //Y dejo al que esta creandose completo
                Copias = (Columnas * Filas);
            }

            //------ Creacion de una sola placha ----//

            PdfCanvas Canvas;


            


            //Calculo de Filas y Columnas que usara en el caso que sean menos que el total que cabe en la pagina
            if (!(Copias == (Columnas * Filas)))
            {
                //Si esta activado el vertical
                if (Vertical)
                {

                    Columnas = (int)Math.Ceiling(Decimal.Divide(Copias, Filas));

                    if (Columnas == 1) Filas = Copias;

                }
                //Si no lo esta
                else
                {
                    Filas = (int)Math.Ceiling(Decimal.Divide(Copias, Columnas));

                    if (Filas == 1) Columnas = Copias;

                }

            }
            
            //Creo el Tamaño de pagina segun las columnas y filas, menos el margen de piezas mas el doble del Padding

            PdfPage page = pdf.AddNewPage(new PageSize(((float)origWidth * Columnas)-((float)MarginObject.MarginWidth) + ((float)PaddingPlotter.MarginWidth * 2)+ (float)TamañoInfo, ((float)origHeight * Filas) - ((float)MarginObject.MarginHeight)+((float)PaddingPlotter.MarginHeight* 2)));
            Canvas = new PdfCanvas(page);

            //Posicion Canvas, Tamaño es 20
            Canvas tag = new Canvas(page, new Rectangle((float)(0-(TamañoInfo/4)), 0,(float) TamañoInfo/2, page.GetPageSize().GetHeight()));

            
            //Si quieres añadir la informacion al lado
            if (Info)
            {
                
                //Añadir CutContour
                if (CutContour)
                {
                    Canvas.Rectangle(0.5f, 0.5f, (float)TamañoInfo * 0.7f, page.GetPageSize().GetHeight() - 1f).SetStrokeColor(new Separation(getCutContour())).Stroke();
                    Canvas.SetStrokeColor(new DeviceCmyk(0f, 0f, 0f, 1f));
                }
                

                Paragraph p = new Paragraph();
                p.SetFontSize((float)TamañoInfo/2);
                p.SetTextAlignment(TextAlignment.LEFT);
                p.SetVerticalAlignment(VerticalAlignment.MIDDLE);
                while (getRealParagraphWidth(tag,p) < page.GetPageSize().GetHeight())
                {
                    p.Add(" "+item.Tipo+"-"+item.Pueblo+"-");

                    p.Add(new Text(item.Base).SetBold());

                    p.Add("-"+item.Diseño+"-"+item.Pedido);


                }
                p.SetRotationAngle(-1.571);

                
                tag.Add(p);
                tag.Close();
            }


            //Si el producto es mas grande que el Maximo dado se no se puede insertar
            if (origHeight < MaxHeight || origWidth < MaxWidth)
            {
                int iColumna = 0;
                int iFila = 0;
                for(int i = 0; i < Copias; i++)
                {
                    //Coloco el objeto en su posicion mas el Padding
                   Canvas.AddXObjectAt(pagecopy, (float)(origWidth*iColumna)+(float)PaddingPlotter.MarginWidth+ (float)TamañoInfo, (float)(origHeight * iFila)+(float)PaddingPlotter.MarginHeight);

                    //Sumo columna o fila en el caso de que sea direccion vertical o horizontal
                    if (Vertical) iFila++;
                    else iColumna++;
                    
                    if (Vertical && iFila == Filas)
                    {
                        iFila = 0;
                        iColumna += 1;
                    }
                    if (!Vertical && iColumna == Columnas)
                    {
                        iColumna = 0;
                        iFila += 1;
                    }
                }
                pdf.Close();
            }
            //En el caso de ser mas grande retornar -1
            else
            {
                //Error 0002 No cabe ningun objeto, Aumente el tamaño maximo o reduzca el origen
                return 2;
            }
            //Todo OK
            return 0;
        }

        private static float getRealParagraphWidth(Canvas doc, Paragraph paragraph)
        {

                IRenderer paragraphRenderer = paragraph.CreateRendererSubTree();
            try
            {
                paragraphRenderer.SetParent(doc.GetRenderer()).
                                        Layout(new LayoutContext(new LayoutArea(1, new Rectangle(1000, 100))));
            }
            catch
            {
                //Excepcion por null, no afecta al funcionamiento del metodo
            }

                return ((ParagraphRenderer)paragraphRenderer).GetMinMaxWidth().GetMaxWidth();
        }
        private static PdfSpecialCs.Separation getCutContour()
        {

            //Color CMYK
            float c = 0.0f;
            float m = 1.0f;
            float y = 0.0f;
            float k = 0.0f;

            float[] c0 = new float[] { 0, 0, 0, 0 };
            float[] c1 = new float[] { c, m, y, k };
            PdfFunction pdfFunction = new PdfFunction.Type2(new PdfArray(new float[] { 0, 1 }), null, new PdfArray(c0),
                    new PdfArray(c1), new PdfNumber(1));
            PdfSpecialCs.Separation cs = new PdfSpecialCs.Separation("CutContour",
                    new DeviceCmyk(c, m, y, k).GetColorSpace(), pdfFunction);

            return cs;
        }

    }
}
