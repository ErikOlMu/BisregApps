using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using System.Windows.Shapes;
using BisregApi.Utilidades;

namespace Catalogos_Bisreg.Vista
{
    /// <summary>
    /// Lógica de interacción para PDFView.xaml
    /// </summary>
    public partial class PDFView : Window
    {
        DataTable dataTable;
        public PDFView(DataTable data, List<string> Campos)
        {
            dataTable = data;
            InitializeComponent();
            
        }

        private void GuardarCanvas()
        {
        }

       

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            GuardarCanvas();
        }


    }
}
