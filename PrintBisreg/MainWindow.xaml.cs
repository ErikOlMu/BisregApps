using System;
using System.Collections.Generic;
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

using BisregApi.PDF;
namespace PrintBisreg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //dtg_CSV.ItemsSource = CSV.GetDataTable(Dialogos.OpenFile()).DefaultView;
            //PDF.CombinarPDF(Dialogos.SaveFile(), Dialogos.OpenFiles(), 650.0, 200.0);

            
        }
    }
}
