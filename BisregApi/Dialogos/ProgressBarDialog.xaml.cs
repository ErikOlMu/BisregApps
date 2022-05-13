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
using System.Windows.Shapes;

namespace BisregApi.Dialogos
{
    /// <summary>
    /// Lógica de interacción para ProgressBar.xaml
    /// </summary>
    public partial class ProgressBarDialog : Window
    {
        public ProgressBar progressBar
        {
            get
            {
                return progressbar;
            }
            set
            {
                progressbar = value;
            }
        }
        public string labelinfo
        {
            get
            {
                return lbl_info.Text;
            }
            set
            {
                lbl_info.Text = value;
            }
        }
        public ProgressBarDialog()
        {
            InitializeComponent();
        }
    }
}
