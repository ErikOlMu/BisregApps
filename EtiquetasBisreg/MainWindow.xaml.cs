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
        GestorReglas Reglas = new GestorReglas();
        DataTable dataTableCantidades;

        public MainWindow()
        {
            InitializeComponent();

            if (Environment.GetCommandLineArgs().Length > 1)
            {
                ImportarCSV(Environment.GetCommandLineArgs()[1]);
                this.Close();
            }
            else
            {
                ReloadBDD();
            }
        }


        private bool ReloadBDD()
        {
            try
            {
                Reglas = new GestorReglas();
                if (!Reglas.DBValida())
                {
                    throw new Exception("Error");
                }
                UpdateDataGridCantidades();
                return true;

            }
            catch
            {
                MessageBox.Show("No se a podido cargar la Base de datos");
                return false;
            }
        }
        private void UpdateDataGridCantidades()
        {
            dataTableCantidades = Reglas.GetDataTable("ReglaCantidad");
            dtg_ReglasCantidad.ItemsSource = dataTableCantidades.DefaultView;
        }

        private void ImportarCSV(string file)
        {
            //string file = "C:\\Users\\Disseny\\Desktop\\00012000366103.csv";

            //string file = "C:\\Users\\oficina12\\Desktop\\00012000366103.csv";
            string temp = System.IO.Path.GetFileNameWithoutExtension(file);
            PdfWriter writer = new PdfWriter(temp);
            PdfDocument pdfDoc = new PdfDocument(writer);

            if (file.EndsWith(".csv"))
            {
                DataTable data = CSV.GetDataTable(file, true);
                foreach (DataRow dtRow in data.Rows)
                {
                    using (var documento = pdfDoc)
                    {
                        string Referencia = (dtRow[data.Columns[1]].ToString() ?? "").Replace("\"", "");
                        int Copias = int.Parse((dtRow[data.Columns[0]].ToString() ?? "").Replace("\"", ""));



                        Copias = Copias / Reglas.ConsultaReglaCantidad(new BisregApi.Diseño.ItemProduccion(Referencia, Copias));
                        for (int i = 0; i < Copias; i++)
                        {
                            BuclePage(documento.AddNewPage(new PageSize(113.0f, 57.0f)), Referencia);
                        }
                    }

                }


                pdfDoc.Close();
                PrintObject.Start(temp);


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

        private void btnGuardarReglasCantidad_Click(object sender, RoutedEventArgs e)
        {
            Reglas.SaveDataTable(dataTableCantidades);
            UpdateDataGridCantidades();
        }
    }
}
