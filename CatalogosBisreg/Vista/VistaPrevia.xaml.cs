using BisregApi.Utilidades;
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
using System.Windows.Shapes;

namespace CatalogosBisreg.Vista
{
    /// <summary>
    /// Lógica de interacción para VistaPrevia.xaml
    /// </summary>
    public partial class VistaPrevia : Window
    {
        public VistaPrevia(DataTable tabla, string rutaimg, PerfilCatalogo perfil)
        {
            InitializeComponent();


            ViewerDoc.Document = DocumentoCatalogo.GetFlowDocument(tabla,  perfil, rutaimg);
        
        }
    }
}
