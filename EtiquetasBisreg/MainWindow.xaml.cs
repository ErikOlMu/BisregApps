using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BisregApi.Utilidades;

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
          
                if (file.EndsWith(".csv"))
                {
                    DataTable data = CSV.GetDataTable(file, true);
                    foreach (DataRow dtRow in data.Rows)
                    {
                        try
                        {
                            string Referencia = (dtRow[data.Columns[1]].ToString() ?? "").Replace("\"", "");
                            int Copias = int.Parse((dtRow[data.Columns[0]].ToString() ?? "").Replace("\"", ""));
                            MessageBox.Show(Referencia);
                        }
                        catch
                        {
                           // LogWrite("Error de Lectura en linea " + data.Rows.IndexOf(dtRow) + "");
                        }
                    }
                }
                else
                {
                   MessageBox.Show("El Archivo '" + file + "' no es un '.csv'");
                }

            
        }
    }
}
