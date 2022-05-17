using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BisregApi.Utilidades;
using iText.Layout.Properties;
using iText;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Kernel.Pdf.Canvas;
using System.IO;
using System.Drawing.Printing;

namespace EtiquetasBisreg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ImportarCSV();
        }

        private void ImportarCSV()
        {
            string file = Environment.GetCommandLineArgs()[1];
            string temp = System.IO.Path.GetFileNameWithoutExtension(file);
            PdfWriter writer = new PdfWriter(temp);
            PdfDocument pdfDoc = new PdfDocument(writer);

            if (file.EndsWith(".csv"))
            {
                DataTable data = CSV.GetDataTable(file, true);
                foreach (DataRow dtRow in data.Rows)
                {
                    
                    string Referencia = (dtRow[data.Columns[1]].ToString() ?? "").Replace("\"", "");
                    int Copias = int.Parse((dtRow[data.Columns[0]].ToString() ?? "").Replace("\"", ""));

                    Copias = Copias / FindCopias(Referencia);
                    for (int i = 0; 1 < Copias; i++)
                    {
                        BuclePage(pdfDoc.AddNewPage(new PageSize(113.0f, 57.0f)), Referencia);
                    }

                }


                pdfDoc.Close();
                PrintObject.PrintPdf(temp, new PrinterSettings().PrinterName);

            }


            else
            {
                MessageBox.Show("El Archivo '" + file + "' no es un '.csv'");
            }
        }



        //Diseño etiqueta
        private static void BuclePage(PdfPage pagina, string content)
        {
            
                iText.Layout.Canvas canvas = new iText.Layout.Canvas(pagina, new iText.Kernel.Geom.Rectangle(0, -12, 113.0f, 57.0f));
                Paragraph p = new Paragraph();
                p.SetFontSize(11);
                p.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                p.SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE);
                p.Add(content);

                canvas.Add(p);

            canvas.Close();

        }

        private static int FindCopias(string Referencia)
        {
            return 1;
        }
    }
}
