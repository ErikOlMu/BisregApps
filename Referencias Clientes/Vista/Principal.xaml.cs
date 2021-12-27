using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + AppDomain.CurrentDomain.FriendlyName.Replace(".exe", "") + "\\" + SettingsFile))
            {
                settings = new Settings();
                settings.file = SettingsFile;
            }
            else
            {
                settings = (Settings) Config.getConfig(SettingsFile, typeof(Settings));
            }

            settings.Save();

            tbx_Copias.Text = settings.Copias.ToString();

        }
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        //Evento btn Importar Excel
        private void btn_ImporarExel_Click(object sender, RoutedEventArgs e)
        {
            //Añado los campos que quiero
            List<string> Campos = new List<string>();
            Campos.Add("Referencia");
            Campos.Add("Referencia Cliente");
            Campos.Add("Pueblo");
            //Añado las columnas que quiero cojer
            List<int> Columnas = new List<int>();
            Columnas.Add(3);
            Columnas.Add(0);
            Columnas.Add(8);
            try
            {
                //Importo el Excel al DataGrid
                dtg.ItemsSource = Excel.GetDataTable(Dialogos.OpenFile(), Campos, settings.Limite_Excel, Columnas).DefaultView;
            }
            catch
            {
                //Excepcion por si no importa el excel
                MessageBox.Show("No se a podido importar el archivo");
            }
        }

        //Abro la ventana Configuracion
        private void btn_Config_Click(object sender, RoutedEventArgs e)
        {
            new Configuracion().Show();
        }

        private void btn_VistaPrevia_Click(object sender, RoutedEventArgs e)
        {
            try{
                if (dtg.ItemsSource == null) MessageBox.Show("Primero debes importar datos");
                else new VistaPrevia((dtg.ItemsSource as DataView).ToTable()).Show();
        }
            catch
            {
                MessageBox.Show("No se puede mostrar la vista previa");
            }
}

        private void btn_Imprimir_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
                if (dtg.ItemsSource == null) MessageBox.Show("Primero debes importar datos");
                else PrintDoc.Print(new DocumentoCatalogo().GetFlowDocument((dtg.ItemsSource as DataView).ToTable()));
            
        }

        private static readonly Regex _regex = new Regex("[^0-9-]+");

        private void tbx_Copias_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void tbx_Copias_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                settings.Copias = Int32.Parse(tbx_Copias.Text);
                settings.Save();
                
            }
            catch
            {
                if (settings != null) settings.Copias = 0;
            }
        }
    }
}
