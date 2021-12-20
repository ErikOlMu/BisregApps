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

namespace BisregApi.ControlesWPF
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class BotonImagen : UserControl
    {
        public BotonImagen()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public string Imagen { get; set; }
        public string Titulo { get; set; }
        public new double FontSize { get; set; }

        public event RoutedEventHandler Click;

        void onButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.Click != null)
            {
                this.Click(this, e);
            }
        }
    }
}
