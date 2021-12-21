using System;
using System.Collections.Generic;
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
namespace Referencias_Clientes.Vista
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        private string SettingsFile = "Config.conf";
        private Settings settings;

        public Principal()
        {
            InitializeComponent();
            InicializarApp();
        }

        //Inicializar Vista
        private void InicializarApp()
        {
            //Si no existe el fichero config lo creamos
            if (!File.Exists(SettingsFile))
            {
                settings = new Settings();
                settings.File = SettingsFile;
            }
            else
            {
                settings = (Settings)Config.getConfig("Config.conf", typeof(Settings));
            }

            settings.Save();

        }

        //Evento btn Importar Excel
        private void btn_ImporarExel_Click(object sender, RoutedEventArgs e)
        {
            //Añado los campos que quiero
            List<string> Campos = new List<string>();
            Campos.Add("Referencia");
            Campos.Add("Referencia Cliente");
            //Importo el Excel al DataGrid
            dtg.ItemsSource = Excel.GetDataTable(Dialogos.OpenFile(),Campos,settings.Limite_Excel).DefaultView;
        }

        private void btn_EditarCanvas_Click(object sender, RoutedEventArgs e)
        {
            //TO DO ----- Venta Vista Previa
        }

        //Abro la ventana Configuracion
        private void btn_Config_Click(object sender, RoutedEventArgs e)
        {
            new Configuracion().Show();
        }
    }
}
