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
using BisregApi.Estructuras;
using Referencias_Clientes.Modulos;
using BisregApi.ControlesWPF;
using System.Text.RegularExpressions;

namespace Referencias_Clientes.Vista
{
    /// <summary>
    /// Lógica de interacción para Configuracion.xaml
    /// </summary>
    public partial class Configuracion : Window
    {
        private string SettingsFile ="Config.conf";
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
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + AppDomain.CurrentDomain.FriendlyName.Replace(".exe", "") + "\\" + SettingsFile))
            {
                settings = new Settings();
                settings.file = SettingsFile;
            }
            else
            {
                settings = (Settings)Config.getConfig(SettingsFile, typeof(Settings));
            }

            
            
            //Cargar Datos de Settings
            cbx_Fuente.ItemsSource = Fonts.SystemFontFamilies;
            tbx_Columnas.Text = settings.Columnas.ToString();
            tbx_Filas.Text = settings.Filas.ToString();

            cbx_Tamaños.Items.Clear();
            foreach (Tamaño tamaño in settings.TamañosPagina)
            {
                cbx_Tamaños.Items.Add(tamaño.Nombre);
            }

            cbx_Tamaños.SelectedIndex = settings.TamañoSeleccionado;

            

            
            
            

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
            try
            {
                (CanvasView.Contenido as BisregCanvas).Width = settings.TamañosPagina[settings.TamañoSeleccionado].size.Width / settings.Columnas;
                (CanvasView.Contenido as BisregCanvas).Height = settings.TamañosPagina[settings.TamañoSeleccionado].size.Height / settings.Filas;
            }
            catch
            {
                //Excepcion en caso que no encuentre el tamaño, ponerlo en A4
                (CanvasView.Contenido as BisregCanvas).Width = Sizes.A4.Width / settings.Columnas;
                (CanvasView.Contenido as BisregCanvas).Width = Sizes.A4.Height / settings.Filas;
            }
            

            //Creo los campos
            CampoCanvas CampoReferencia = new CampoCanvas("REFERENCIA", settings.CordReferencia, settings.TamañoReferencia);
            CampoCanvas CampoReferenciaCliente = new CampoCanvas("CLIENTE", settings.CordReferenciaCliente, settings.TamañoReferenciaCliente);
            CampoCanvas CampoPueblo = new CampoCanvas("PUEBLO", settings.CordPueblo, settings.TamañoPueblo);
            CampoCanvas CampoCantidad = new CampoCanvas("Uds:", settings.CordCantidad, settings.TamañoCantidad);

            //Pongo la Fuente
            try
            {
                CampoReferencia.Elemento.SetValue(TextBlock.FontFamilyProperty, new FontFamily(settings.FuenteReferencia));
                CampoReferenciaCliente.Elemento.SetValue(TextBlock.FontFamilyProperty, new FontFamily(settings.FuenteReferenciaCliente));
                CampoPueblo.Elemento.SetValue(TextBlock.FontFamilyProperty, new FontFamily(settings.FuentePueblo));
                CampoCantidad.Elemento.SetValue(TextBlock.FontFamilyProperty, new FontFamily(settings.FuenteCantidad));
            }
            catch
            {
                //Excepcion en caso de que no encuentre la fuente
            }

            //Elimino en el caso que haya algun campo
            (CanvasView.Contenido as BisregCanvas).CamposList.Clear();
            //Añado los dos campos
            (CanvasView.Contenido as BisregCanvas).CamposList.Add(CampoReferencia);
            (CanvasView.Contenido as BisregCanvas).CamposList.Add(CampoReferenciaCliente);
            (CanvasView.Contenido as BisregCanvas).CamposList.Add(CampoPueblo);
            (CanvasView.Contenido as BisregCanvas).CamposList.Add(CampoCantidad);
        }
        //Guardar Configuracion del Canvas en Settings
        private void Save()
        {
            settings.TamañoReferencia = (CanvasView.Contenido as BisregCanvas).CamposList[0].Tamaño;
            settings.CordReferencia = (CanvasView.Contenido as BisregCanvas).CamposList[0].Coordenadas;
            settings.FuenteReferencia = ((CanvasView.Contenido as BisregCanvas).CamposList[0].Elemento.GetValue(TextBlock.FontFamilyProperty) as FontFamily).Source;


            settings.TamañoReferenciaCliente = (CanvasView.Contenido as BisregCanvas).CamposList[1].Tamaño;
            settings.CordReferenciaCliente = (CanvasView.Contenido as BisregCanvas).CamposList[1].Coordenadas;
            settings.FuenteReferenciaCliente = ((CanvasView.Contenido as BisregCanvas).CamposList[1].Elemento.GetValue(TextBlock.FontFamilyProperty) as FontFamily).Source;

            settings.TamañoPueblo = (CanvasView.Contenido as BisregCanvas).CamposList[2].Tamaño;
            settings.CordPueblo = (CanvasView.Contenido as BisregCanvas).CamposList[2].Coordenadas;
            settings.FuentePueblo = ((CanvasView.Contenido as BisregCanvas).CamposList[2].Elemento.GetValue(TextBlock.FontFamilyProperty) as FontFamily).Source;

            settings.TamañoCantidad = (CanvasView.Contenido as BisregCanvas).CamposList[3].Tamaño;
            settings.CordCantidad = (CanvasView.Contenido as BisregCanvas).CamposList[3].Coordenadas;
            settings.FuenteCantidad = ((CanvasView.Contenido as BisregCanvas).CamposList[3].Elemento.GetValue(TextBlock.FontFamilyProperty) as FontFamily).Source;


            settings.Save();

        }
        //Evento para Poner los valores del Elemento seleccionado
        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                tbx_Tamaño.Text = (CanvasView.Contenido as BisregCanvas).GetUltimoCampo().Tamaño.ToString();
                cbx_Fuente.Text = ((CanvasView.Contenido as BisregCanvas).GetUltimoCampo().Elemento.GetValue(TextBlock.FontFamilyProperty) as FontFamily).Source;
            }
            catch
            {
                tbx_Tamaño.Text = "";
                cbx_Fuente.Text = "";
            }


        }
        //Evento para cambiar el tamaño
        private void tbx_Tamaño_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    (CanvasView.Contenido as BisregCanvas).GetUltimoCampo().Tamaño = Int32.Parse(tbx_Tamaño.Text);
                }
                catch
                {
                    //Excepcion por si no hay elemento seleccionado
                }
            }
        }
        //Evento para cambiar la fuente
        private void cbx_Fuente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                (CanvasView.Contenido as BisregCanvas).GetUltimoCampo().Elemento.SetValue(TextBlock.FontFamilyProperty, cbx_Fuente.SelectedItem);
            }
            catch
            {
                //Excepcion en caso de que no encuentre la Fuente
            }
        }
        //Evento para guardar cuando cerramos la ventana
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Save();
        }
        //Control para borrar todas las configuraciones y volver a empezar
        private void btn_Recargar_Click(object sender, RoutedEventArgs e)
        {
            settings.SettingsReload();
            InicializarApp();
            
        }
        //Metodos para comprobar is es un texto o no
        private static readonly Regex _regex = new Regex("[^0-9.-]+"); 
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        //Interrumpo en el caso que no sea un numero ni un punto
        private void tbx_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        //Evento para seleccionar tamaños
        private void cbx_Tamaños_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            settings.TamañoSeleccionado = cbx_Tamaños.SelectedIndex;
            settings.Save();

            SetCanvas();
            CargarCanvas();

            if (Enumerable.Range(0, settings.TamañosPagina.Count).Contains(cbx_Tamaños.SelectedIndex))
            {
                //Cargo la seleccion en los tbx 
                tbx_Alto.Text = Conversor.Double2Cm((double)(settings.TamañosPagina[settings.TamañoSeleccionado]).size.Height);
                tbx_Ancho.Text = Conversor.Double2Cm((double)(settings.TamañosPagina[settings.TamañoSeleccionado]).size.Width);
            }
            else
            {
                cbx_Tamaños.SelectedIndex = 0;

            }
            
            
            
            
        }
        //Eventos para guardar Filas y columnas en el fichero settings
        private void tbx_Filas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    settings.Filas = Int32.Parse(tbx_Filas.Text);
                    settings.Save();
                    InicializarApp();
                }
                catch
                {
                    //Excepcion en caso de introducior un valor erroneo
                }
            }
           
        }
        private void tbx_Columnas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                { 
                settings.Columnas = Int32.Parse(tbx_Columnas.Text);
                settings.Save();
                InicializarApp();
                }
                catch
                {
                    //Excepcion en caso de introducior un valor erroneo
                }
            }
        }
        private void btn_EliminarTamaño_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbx_Tamaños.Items.Count <= 1) MessageBox.Show("No se puede eliminar el tamaño seleccionado");
                else
                {
                    if (MessageBox.Show("Estas seguro de Eliminar el diseño " + settings.TamañosPagina[cbx_Tamaños.SelectedIndex].Nombre, "Eliminar", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
                    {
                        settings.TamañosPagina.RemoveAt(cbx_Tamaños.SelectedIndex);
                        settings.Save();
                        InicializarApp();
                    }
                }
            }
            catch
            {
                //Excepcion por si no hay ninguno seleccionado 
            }
        }
        private void btn_AñadirTamaño_Click(object sender, RoutedEventArgs e)
        {
            //Ocultamos el cbx de Tamaños , el boton añadir Tamaño y el boton eliminar tamaño
            cbx_Tamaños.Visibility = Visibility.Hidden;
            btn_AñadirTamaño.Visibility = Visibility.Hidden;
            btn_EliminarTamaño.Visibility = Visibility.Hidden;

            //Desactivamos la recarga
            btn_Recargar.IsEnabled = false;

            //Cambiamos el nombre del lbl NTPagina
            lbl_NTPagina.Content = "Nombre Tamaño";

            //Mostramos el tbx para poner el nombre, el boton guardar Tamaño y el boton cancelar
            tbx_NombreTamaños.Visibility = Visibility.Visible;
            btn_GuardarTamaño.Visibility = Visibility.Visible;
            btn_CancelarCreacion.Visibility = Visibility.Visible;

            //Activamos los tbx Ancho, Alto y borramos el contenido
            tbx_Alto.IsEnabled = true;
            tbx_Ancho.IsEnabled = true;

            tbx_Alto.Text = "";
            tbx_Ancho.Text = "";
        }
        private void btn_GuardarTamaño_Click(object sender, RoutedEventArgs e)
        {
            bool Guardado;
            try
            {
                //Añadimos el nuevo tamaño
                settings.TamañosPagina.Add(new Tamaño(tbx_NombreTamaños.Text, new Size(Conversor.Cm2Double(tbx_Ancho.Text.Replace(".",",")+"cm"), Conversor.Cm2Double(tbx_Alto.Text.Replace(".", ",") + "cm"))));
                settings.Save();
                Guardado = true;
            }
            catch
            {
                //Excepcion por si no deja guardar tamaño pagina
                MessageBox.Show("No se puede guardar el Tamaño");
                Guardado = false;
            }

            if (Guardado)
            {
                SalirDeCreacion();
            }
            


        }
        private void SalirDeCreacion()
        {
            //Vaciamos el contenido de Nombre y cambiamos el nombre del lbl NTPagina
            tbx_NombreTamaños.Text = "";
            lbl_NTPagina.Content = "Tamaño Pagina";

            //Mostramos el cbx de Tamaños, el boton añadir Tamaño y el boton eliminar tamaño
            btn_EliminarTamaño.Visibility = Visibility.Visible;
            cbx_Tamaños.Visibility = Visibility.Visible;
            btn_AñadirTamaño.Visibility = Visibility.Visible;

            //Activamos la Recarga
            btn_Recargar.IsEnabled = true;

            //Ocultamos el tbx para poner el nombre , el boton guardar Tamaño y el boton cancelar
            tbx_NombreTamaños.Visibility = Visibility.Hidden;
            btn_GuardarTamaño.Visibility = Visibility.Hidden;
            btn_CancelarCreacion.Visibility = Visibility.Hidden;


            //Desactivamos los tbx Ancho y Alto 
            tbx_Alto.IsEnabled = false;
            tbx_Ancho.IsEnabled = false;
            InicializarApp();
        }
        private void btn_CancelarCreacion_Click(object sender, RoutedEventArgs e)
        {
            SalirDeCreacion();
        }
    }
}
