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
using BisregApi.ControlesWPF;

namespace Referencias_Clientes.Vista
{
    /// <summary>
    /// Lógica de interacción para Configuracion.xaml
    /// </summary>
    public partial class Configuracion : Window
    {
        private string SettingsFile = "Config.conf";
        private Settings settings;
        
        public Configuracion()
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

            SetCanvas();
            CargarCanvas();
            
        }
        //Metodo para iniciar el Canvas
        private void CargarCanvas()
        {
            
            //Actualizo el contenido
            (CanvasView.Contenido as BisregCanvas).UpdateCampos();

        }
        //Actualizo los valores del canvas
        private void SetCanvas()
        {
            //Pongo el Tamaño del Canvas segun las Filas y columnas
            (CanvasView.Contenido as BisregCanvas).Width = settings.TamañoPagina.Width / settings.Columnas;
            (CanvasView.Contenido as BisregCanvas).Height = settings.TamañoPagina.Height / settings.Filas;

            //Añado los dos campos
            (CanvasView.Contenido as BisregCanvas).CamposList.Add(new CampoCanvas("REFERENCIA", settings.CordReferencia, settings.TamañoReferencia));
            (CanvasView.Contenido as BisregCanvas).CamposList.Add(new CampoCanvas("CLIENTE", settings.CordReferenciaCliente, settings.TamañoReferenciaCliente));
        }
        //Guardar Configuracion del Canvas en Settings
        private void Save()
        {
            settings.TamañoReferencia = (CanvasView.Contenido as BisregCanvas).CamposList[0].Tamaño;
            settings.CordReferencia = (CanvasView.Contenido as BisregCanvas).CamposList[0].Coordenadas;

            settings.TamañoReferenciaCliente = (CanvasView.Contenido as BisregCanvas).CamposList[1].Tamaño;
            settings.CordReferenciaCliente = (CanvasView.Contenido as BisregCanvas).CamposList[1].Coordenadas;

            settings.Save();

        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }
    }
}
