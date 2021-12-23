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
            //Si no existe el fichero config lo creamos
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + AppDomain.CurrentDomain.FriendlyName.Replace(".exe", "") + "\\" + SettingsFile))
            {
                settings = new Settings();
                settings.file = SettingsFile;
            }
            else
            {
                settings = (Settings)Config.getConfig(SettingsFile, typeof(Settings));
            }

            settings.Save();


            ViewerDoc.Document = new DocumentoCatalogo().GetFlowDocument(datos);


        }


        
    
    }
}
