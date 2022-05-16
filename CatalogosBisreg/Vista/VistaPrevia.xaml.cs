using BisregApi.Dialogos;
using BisregApi.Utilidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using UniversalSerializerLib3;

namespace CatalogosBisreg.Vista
{
    /// <summary>
    /// Lógica de interacción para VistaPrevia.xaml
    /// </summary>
    public partial class VistaPrevia : Window
    {

        FlowDocument doc = new FlowDocument();

        public VistaPrevia(DataTable tabla, string rutaimg, PerfilCatalogo perfil)
        {
            ProgressBarDialog progressbard = new ProgressBarDialog();

            InitializeComponent();
         


           
            ViewerDoc.Document = DocumentoCatalogo.GetFlowDocument(tabla, perfil, rutaimg);

        }

     
    }
}



