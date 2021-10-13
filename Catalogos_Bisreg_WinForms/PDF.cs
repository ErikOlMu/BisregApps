using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Catalogos_Bisreg_WinForms

{
    class PDF
    {


        private Tamaño Plotter;
        private Document doc;
        private int Filas;
        private ArrayList Productos;
        private FormPDF Ventana;

        public void inicializarDocumento()
        {
            //Cojer Plotter
            //Plotter = new Tamaño(99.57, 181.14); // Nota para Erik, Hay que poner como variable el tamaño del plotter
            //Crear documento con con el tamaño del plotter en Rectangle de PDF  -Nota: Los 0 Son los margenes
            doc = new Document(Plotter.getRectangle(), 0, 0, 0, 0);
            //Crear PDF
            PdfWriter.GetInstance(doc, new FileStream(Settings.Directorio_Salida_PDF, FileMode.Create));
            doc.Open();
        }
        public PDF(ArrayList pProductos,FormPDF Ventana,Tamaño Plotter)
        {
            this.Plotter = Plotter;
            this.Ventana = Ventana;
            Productos = pProductos;
            Filas = (Productos.Count / Settings.Columnas_Pagina)+1 ;
            inicializarDocumento();
            generarImagenes();
            doc.Add(RecorridoPDF());
            GuardarPDF();
        }
        public void generarImagenes()
        {
            foreach (Item i in Productos)
            {
                Ventana.Foto.Dispose();
                //Poner la foto
                try
                {
                    Ventana.Foto = System.Drawing.Image.FromFile(Settings.Directorio_IMG + "\\" + i.Referencia + ".jpg");
                }
                catch(Exception ex)
                {
                    try
                    {
                        Ventana.Foto = System.Drawing.Image.FromFile(Settings.Directorio_IMG + "\\" + i.Referencia + ".png");
                        
                    }
                    catch (Exception ex2)
                    {
                        try
                        {
                            Ventana.Foto = System.Drawing.Image.FromFile(Settings.Directorio_IMG + "\\" + i.Referencia + "_0.jpg");
                        }
                        catch (Exception ex3)
                        {
                            try
                            {
                                Ventana.Foto = System.Drawing.Image.FromFile(Settings.Directorio_IMG + "\\" + i.Referencia + "_0.png");

                            }
                            catch (Exception ex4)
                            {
                                Ventana.Foto = System.Drawing.Image.FromFile("Imagen.jpg");
                            }
                        }
                    }
                }

                //Poner la referencia
                ((CampoPB)Ventana.Campos[1]).Texto = i.Referencia;
                //Poner el Barcode
                ((CampoPB)Ventana.Campos[2]).Texto = "*"+i.Referencia+"*";
                //Poner el texto de cada campo por item //Empiezo desde 3 por la imagen la referencia y el barcode
                for (int y = 3; y < Ventana.Campos.Count ; y++)
                {
                    if (Ventana.chbx_Nombrescampos.Checked)
                    {
                        ((CampoPB)Ventana.Campos[y]).Texto = ((CampoPB)Ventana.Campos[y]).Nombre+" " + ((string)i.Valores[y - 3]);
                    }
                    else
                    {
                        ((CampoPB)Ventana.Campos[y]).Texto = ((string)i.Valores[y - 2]);
                    }
                }
                Ventana.Celda_PDF.Invalidate();
                
                guardarimagen(Ventana.Celda_PDF, "temp\\"+ i.Referencia + ".jpg");
            }
            
        }

        //Metodo para cerrar el PDF
        public void GuardarPDF()
        {
            List<string> strFiles = Directory.GetFiles("temp\\", "*", SearchOption.AllDirectories).ToList();

            foreach (string fichero in strFiles)
            {
                File.Delete(fichero);
            }
            doc.Close();
            MessageBox.Show("Pdf Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.None);
        }
        
        public void guardarimagen(PictureBox Celda_PDF, string ruta)
        {

            try
            {
                Bitmap Imagen = new Bitmap(Celda_PDF.Width, Celda_PDF.Height);
                Celda_PDF.DrawToBitmap(Imagen, Celda_PDF.ClientRectangle);
                Imagen.Save(ruta, ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido guardar la imagen: " + ruta, "Fallo guardando imagenes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
            

        }



        //Metodo que devuelve la imagen mas pequeña sin deformarla
        public iTextSharp.text.Image resize_Image(iTextSharp.text.Image pic)
        {
            

            if (pic.Height > pic.Width)
            {
                //Maximum height is 800 pixels.          -----Nota para Erik: Hacer respecto las columnas y filas del documento y el tamaño
                float percentage = 0.0f;
                percentage = 700 / pic.Height;
                pic.ScalePercent(percentage * 100);
            }
            else
            {
                //Maximum width is 600 pixels.
                float percentage = 0.0f;
                percentage = (700) / pic.Width;
                pic.ScalePercent(percentage * 100);
            }

            return pic;
        }

        //Metodo que retorna la Table General
        public PdfPTable RecorridoPDF()
        {
            PdfPTable table = new PdfPTable(Settings.Columnas_Pagina);
            table.TotalWidth = Plotter.getHorizontal_Pixel(); // El tamaño de Horizontal(Width) de la tabla es respecto el plotter
            //ancho sin variacion
            table.LockedWidth = true;
            PdfPCell[] Array_de_celdas = new PdfPCell[Settings.Columnas_Pagina];
            for (int i = 0; i < (Settings.Columnas_Pagina * Filas); i++)
            {
                //Añado una celda con el produto 0 para provar y le mando las columnas del PDF
                PdfPCell celda;
                if (i < Productos.Count)
                {
                    try{
                        
                        
                        //Colorespecial
                        //var color = new PdfSpotColor("CutContour",BaseColor.MAGENTA);
                        


                        
                        
                        //table.AddCell();
                        
                        //Color Blanco
                        celda = new PdfPCell(iTextSharp.text.Image.GetInstance(("temp\\" + ((Item)Productos[i]).Referencia + ".jpg")));
                        celda.BorderColor = new BaseColor(Color.White);

                        //celda.BorderColor = new BaseColor();
                        celda.FixedHeight = (Plotter.getHorizontal_Pixel() / Settings.Columnas_Pagina);
                        table.AddCell(celda);

                    }
                    catch (Exception ex)
                    {

                    }
                }
                else
                {
                    //Paragrafo para celda Prueba de Giro
                    celda  = new PdfPCell();
                    Paragraph Vacio = new Paragraph(" ");
                    celda.AddElement(Vacio);
                    celda.BorderColor = BaseColor.WHITE;
                    table.AddCell(celda);

                }

            }
            return table;
        }
        


    }
}
