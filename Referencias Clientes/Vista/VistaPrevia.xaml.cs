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
using Referencias_Clientes.Modulos;
using BisregApi.ControlesWPF;
namespace Referencias_Clientes.Vista
{
    /// <summary>
    /// Lógica de interacción para VistaPrevia.xaml
    /// </summary>
    public partial class VistaPrevia : Window
    {
        private string SettingsFile = "Config.conf";
        private Settings settings;
        DataTable datos;
        public VistaPrevia(DataTable table)
        {
            this.datos = table;
            InitializeComponent();

            InicializarApp();

        }

        private void InicializarApp()
        {
            //Inicializamos Settings
            // Si no existe el fichero config lo creamos
            if (!File.Exists(Settings.DirectorioAppData + Settings.file))
            {
                settings = new Settings();
            }
            else
            {
                settings = (Settings)Config.getConfig(Settings.file, typeof(Settings));
            }
            settings.Save();



            ViewerDoc.Document = new DocumentoCatalogo().GetFlowDocument(datos);


        }


        
    
    }
}
