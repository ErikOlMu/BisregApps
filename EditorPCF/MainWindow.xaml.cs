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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BisregApi.ControlesWPF;
using BisregApi.Utilidades;
using EditorPCF.Objetos;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace EditorPCF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string FuenteTextoDefecto = "Arial";
        private PerfilCatalogo? Perfil;
        private CampoCanvas? ceditable;
        private CampoCanvas? CampoEditable
        {
            get
            {
                return ceditable;
            }
            set
            {
                ceditable = value;

                if (value == null)
                {
                    VisibilityToolbarIMG(false);
                    VisibilityToolbarTxt(false);
                }
                else
                {
                    if (value.Elemento is TextBlock)
                    {
                        VisibilityToolbarIMG(false);
                        VisibilityToolbarTxt(true);
                        CargarCampoTxt(value);

                    }
                    if (value.Elemento is Image)
                    {
                        VisibilityToolbarIMG(true);
                        VisibilityToolbarTxt(false);
                        CargarCampoIMG(value);

                    }
                }



            }
        }
        ColeccionTamaños tamaños;

        public MainWindow()
        {
            LoadFileTamaños();

            InitializeComponent();

            LoadTamaños();

            //Añado las Fuentes al tbx de Fuentes
            LoadFonts();

            string[] lista = Environment.GetCommandLineArgs();
            try
            {
                CargarDocumento(PerfilCatalogo.GetPerfilCatalogo(Environment.GetCommandLineArgs()[1]));
            }
            catch
            {
                CerrarDocumento();
            }

        }

        public void LoadFileTamaños()
        {
            //Si  no existe eñ archivo tamaños lo creo
            if (!File.Exists(ColeccionTamaños.DirectorioAppData + ColeccionTamaños.file))
            {
                tamaños = new ColeccionTamaños();
            }
            else
            {
                tamaños = (ColeccionTamaños)Config.getConfig(ColeccionTamaños.file, typeof(ColeccionTamaños));
            }
            tamaños.Save();

        }

        public void LoadTamaños()
        {
            LoadFileTamaños();
            cbx_Tamaño.ItemsSource = null;
            cbx_Tamaño.ItemsSource = tamaños.Tamaños;
        }
        //Cargar Fuentes en el cbx Fuentes
        public void LoadFonts()
        {
            cbx_Fuente_Txt.ItemsSource = Fonts.SystemFontFamilies;
        }

        public void CrearDocumento()
        {
            //Creamos un Perfil en Blanco
            Perfil = new PerfilCatalogo();
            Perfil.NombrePerfil = "Perfil Nuevo";
            //Recargamos el Editor con el perfil Nuevo
            RecargarEditor();
        }
        //Iniciamos El Documento
        public void CargarDocumento(PerfilCatalogo perfilCatalogo)
        {
            //Añadimos el Perfil al Objeto
            Perfil = perfilCatalogo;
            //Recargamos el Editor con el perfil añadido
            RecargarEditor();
        }
        //Cerramos el Documento
        public void CerrarDocumento()
        {
            //Cerramos el Perfil
            Perfil = null;
            //Recargamos el Editor con El perfil null
            RecargarEditor();

        }
        //Recargamos el Editor con el Perfil
        public void RecargarEditor()
        {
            bool NoNull = Perfil != null;

            //Activamos o Desactivamos las Herramientas
            OnOfHerramientasTop(NoNull);
            OnOfHerramientasLeft(NoNull);
            //Cargamos datos en Herramientas Top si Perfil no es null
            CargarHerramientasTop();
            //Ocultamos las Herramientas de Campos
            VisibilityToolbarIMG(false);
            VisibilityToolbarTxt(false);
            //Cargamos el Canvas con el Perfil
            CargarCanvas();
        }
        //Activar o desactivar Toolbar Superior
        public void OnOfHerramientasTop(bool enable)
        {
            tbx_Name.IsEnabled = enable;
            tbx_Columnas.IsEnabled = enable;
            tbx_Filas.IsEnabled = enable;
            tbx_Ancho.IsEnabled = enable;
            tbx_Alto.IsEnabled = enable;
            cbx_Tamaño.IsEnabled = enable;
        }
        //Borrar datos Toolbar Superior
        public void DeleteHerramientasTop()
        {
            tbx_Name.Text = "";
            tbx_Columnas.Text = "";
            tbx_Filas.Text = "";
            tbx_Ancho.Text = "";
            tbx_Alto.Text = "";
            cbx_Tamaño.Text = "";
            tbx_Copias.Text = "";

        }
        //Cargar datos Toolbar Superior
        public void CargarHerramientasTop()
        {
            if (Perfil != null)
            {
                tbx_Name.Text = Perfil.NombrePerfil;
                tbx_Columnas.Text = Perfil.Columnas.ToString();
                tbx_Filas.Text = Perfil.Filas.ToString();
                tbx_Ancho.Text = Perfil.Ancho.ToString();
                tbx_Alto.Text = Perfil.Alto.ToString();
                cbx_Tamaño.Text = "";
                tbx_Copias.Text = Perfil.Copias.ToString();

            }
            else
            {
                DeleteHerramientasTop();
            }
        }
        //Activar o desactivar Toolbar Lateral Izquierdo
        public void OnOfHerramientasLeft(bool enable)
        {
            btn_AddImg.IsEnabled = enable;
            btn_AddTxt.IsEnabled = enable;
        }
        //Cargar Edicion IMG
        public void CargarCampoIMG(CampoCanvas campo)
        {
            if (campo != null)
            {
                //Si la Imagen no es la que esta por defecto, penemos el valor vacio
                string Nombre = campo.Valor;
                if (Nombre != "pack://application:,,/EditorPCF;Component/DefaultIMG512px.png") tbx_Nombre_IMG.Text = campo.Valor;
                else tbx_Nombre_IMG.Text = "";
                tbx_Tamaño_IMG.Text = campo.Tamaño.ToString();
                tbx_Rotacion_IMG.Text = campo.Rotacion.ToString();
                tbx_Columna_IMG.Text = campo.ColumnaExcel;
                tbx_AntesValor_IMG.Text = campo.TextoAnterior.ToString();
                tbx_DespuesValor_IMG.Text = campo.TextoPosterior.ToString();
            }
            else
            {
                tbx_Nombre_IMG.Text = "";
                tbx_Tamaño_IMG.Text = "";
                tbx_Rotacion_IMG.Text = "";
                tbx_Columna_IMG.Text = "";
                tbx_AntesValor_IMG.Text = "";
                tbx_DespuesValor_IMG.Text = "";
            }
        }
        //Cargar Edicion Txt
        public void CargarCampoTxt(CampoCanvas campo)
        {
            if (campo != null)
            {
                tbx_Nombre_Txt.Text = campo.Valor;
                cbx_Fuente_Txt.Text = (campo.Elemento.GetValue(TextBlock.FontFamilyProperty) as FontFamily ?? new FontFamily()).Source;
                tbx_Tamaño_Txt.Text = campo.Tamaño.ToString();
                tbx_Rotacion_Txt.Text = campo.Rotacion.ToString();
                tbx_Columna_Txt.Text = campo.ColumnaExcel;
                tbx_AntesValor_Txt.Text = campo.TextoAnterior.ToString();
                tbx_DespuesValor_Txt.Text = campo.TextoPosterior.ToString();
            }
            else
            {
                tbx_Nombre_Txt.Text = "";
                cbx_Fuente_Txt.Text = "";
                tbx_Tamaño_Txt.Text = "";
                tbx_Rotacion_Txt.Text = "";
                tbx_Columna_Txt.Text = "";
                tbx_AntesValor_IMG.Text = "";
                tbx_DespuesValor_IMG.Text = "";
            }
        }
        //Mostar o Ocultar Toolbar IMG
        public void VisibilityToolbarIMG(bool visible)
        {
            if (visible) Toolbar_IMG.Visibility = Visibility.Visible;
            else Toolbar_IMG.Visibility = Visibility.Hidden;

            OcultarToolbar();

        }
        //Ocultar Toolbar
        public void OcultarToolbar()
        {
            if (isVisibleToolbar())
            {
                clm_Toolbar.Width = new GridLength(0, GridUnitType.Auto);
            }
            else
            {
                clm_Toolbar.Width = new GridLength(0,GridUnitType.Pixel);
            }
        }
        //Comprobar Visibilidad
        public bool isVisibleToolbar()
        {
            return (Toolbar_IMG.IsVisible || Toolbar_Txt.IsVisible);
        }
        //Mostar o Ocultar Toolbar Txt
        public void VisibilityToolbarTxt(bool visible)
        {
            if (visible) Toolbar_Txt.Visibility = Visibility.Visible;
            else Toolbar_Txt.Visibility = Visibility.Hidden;

            OcultarToolbar();

        }











        //-------------Metodos Canvas------------
        //Cargar Perfil en Canvas
        public void CargarCanvas()
        {
            //Pongo el Tamaño del Canvas segun las Filas y Columnas
            CargarTamañoCanvas();
            //Actualizo los Elementos del Canvas
            UpdateElementosCanvas();

        }
        //Metodo para cargar Tamaño Canvas
        public void CargarTamañoCanvas()
        {
            //Pongo el Tamaño del Canvas segun las Filas y columnas
            if (Perfil != null)
            {
                (CanvasView.Contenido as BisregCanvas).Width = Perfil.Ancho / Perfil.Columnas;
                (CanvasView.Contenido as BisregCanvas).Height = Perfil.Alto / Perfil.Filas;
            }
            else
            {
                //Si no hay perfil ponemos el tamaño a 0
                (CanvasView.Contenido as BisregCanvas).Height = 0;
                (CanvasView.Contenido as BisregCanvas).Width = 0;
            }
        }
        //Metodo para Actualizar los campos del Perfil al Canvas
        public void UpdateElementosCanvas()
        {
            if (Perfil != null)
            {
                (CanvasView.Contenido as BisregCanvas).CamposList = Perfil.CamposPerfil;
            }
            //Si no hay Perfil eliminamos los campos que esten
            else
            {
                (CanvasView.Contenido as BisregCanvas).DeleteCampos();
            }
        }

        //Eventos del Programa
        private void btn_AddImg_Click(object sender, RoutedEventArgs e)
        {
            if (Perfil != null)
            {
                CampoCanvas cc = new CampoCanvas("pack://application:,,/EditorPCF;Component/DefaultIMG512px.png", new Point(0, 0), 100, CamposCanvas.Imagen);
                Perfil.CamposPerfil.Add(cc);
                UpdateElementosCanvas();
            }
        }
        private void btn_AddTxt_Click(object sender, RoutedEventArgs e)
        {
            if (Perfil != null)
            {
                CampoCanvas cc = new CampoCanvas("Text", new Point(0, 0), 20);
                Perfil.CamposPerfil.Add(cc);
                UpdateElementosCanvas();
            }

        }

        //Eventos para Abrir Guardar o Crear Archivos
        private void Abrir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dialog = new CommonOpenFileDialog();
                CommonFileDialogFilter pcfFilter = new CommonFileDialogFilter("PCF Files", ".pcf");
                pcfFilter.ShowExtensions = true;
                dialog.Filters.Add(pcfFilter);

                dialog.IsFolderPicker = false;
                dialog.Multiselect = false;
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    CargarDocumento(PerfilCatalogo.GetPerfilCatalogo(dialog.FileName));
                }

            }
            catch
            {
                MessageBox.Show("No se a podido abrir el archivo");
            }

        }
        private void Nuevo_Click(object sender, RoutedEventArgs e)
        {
            CrearDocumento();
        }
        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dialog = new CommonSaveFileDialog();
                CommonFileDialogFilter pcfFilter = new CommonFileDialogFilter("PCF Files", ".pcf");
                pcfFilter.ShowExtensions = true;
                dialog.Filters.Add(pcfFilter);

                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    PerfilCatalogo.SavePerfilCatalogo(Perfil, dialog.FileName);
                    CerrarDocumento();
                }
            }
            catch
            {
                MessageBox.Show("No se a podido Guardar el archivo");
            }
        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Evento interaccion con Canvas
            try
            {
                CampoEditable = Perfil.GetCampoCanvas((CanvasView.Contenido as BisregCanvas).GetUltimoCampo().Uid);
            }
            catch
            {
                CampoEditable = null;
            }

        }

        //Evento para solo permitir numeros y comas
        private void tbx_PuntoXComa_KeyDown(object sender, KeyEventArgs e)
        {
            Key newKey = e.Key;

            if (e.Key == Key.OemPeriod || e.Key == Key.Decimal)
            {
                //handle the event and cancel the original key
                e.Handled = true;

                //get caret position
                int tbPos = ((TextBox)sender).SelectionStart;

                //insert the new text at the caret position
                ((TextBox)sender).Text = ((TextBox)sender).Text.Insert(tbPos, ",");

                newKey = Key.OemComma;

                //replace the caret back to where it should be 
                //otherwise the insertion call above will reset the position
                ((TextBox)sender).Select(tbPos + 1, 0);
            }


            base.OnKeyDown(new KeyEventArgs(e.KeyboardDevice, e.InputSource, e.Timestamp, newKey));

        }

        //Eventos de Barra de Herramientas superior
        private void tbx_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Perfil != null)
            {
                //Guardamos el Nombre en el Perfil
                Perfil.NombrePerfil = tbx_Name.Text;
            }

        }
        private void tbx_Columnas_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbx_Columnas.Text != "")
            {
                try
                {
                    //Guardamos las columnas en el perfil y actualizamos el tamaño del canvas
                    Perfil.Columnas = int.Parse(tbx_Columnas.Text);
                    CargarTamañoCanvas();
                }
                catch
                {
                    int tbPos = ((TextBox)sender).SelectionStart;
                    tbx_Columnas.Text = Perfil.Columnas.ToString();
                    ((TextBox)sender).Select(tbPos, 0);
                }
            }

        }
        private void tbx_Filas_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbx_Filas.Text != "")
            {
                try
                {
                    //Guardamos las fila en el perfil y actualizamos el tamaño del canvas
                    Perfil.Filas = int.Parse(tbx_Filas.Text);
                    CargarTamañoCanvas();
                }
                catch
                {
                    int tbPos = ((TextBox)sender).SelectionStart;
                    tbx_Filas.Text = Perfil.Filas.ToString();
                    ((TextBox)sender).Select(tbPos, 0);

                }
            }
        }
        private void tbx_Ancho_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbx_Ancho.Text != "")
            {
                try
                {
                    //Guardamos el ancho en el perfil y actualizamos el tamaño del canvas
                    Perfil.Ancho = double.Parse(tbx_Ancho.Text);
                    CargarTamañoCanvas();
                }
                catch
                {
                    int tbPos = ((TextBox)sender).SelectionStart;
                    tbx_Ancho.Text = Perfil.Ancho.ToString();
                    ((TextBox)sender).Select(tbPos, 0);

                }
            }
        }
        private void tbx_Alto_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbx_Alto.Text != "")
            {
                try
                {
                    //Guardamos el alto en el perfil y actualizamos el tamaño del canvas
                    Perfil.Alto = double.Parse(tbx_Alto.Text);
                    CargarTamañoCanvas();
                }
                catch
                {
                    int tbPos = ((TextBox)sender).SelectionStart;
                    tbx_Alto.Text = Perfil.Alto.ToString();
                    ((TextBox)sender).Select(tbPos, 0);

                }
            }

        }
        private void tbx_Copias_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbx_Copias.Text != "")
            {
                try
                {
                    
                    Perfil.Copias = int.Parse(tbx_Copias.Text);
                    
                }
                catch
                {
                    int tbPos = ((TextBox)sender).SelectionStart;
                    tbx_Copias.Text = Perfil.Copias.ToString();
                    ((TextBox)sender).Select(tbPos, 0);

                }
            }
        }

        //Eventos Editor de Texto
        private void tbx_Nombre_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            CampoEditable.Valor = tbx_Nombre_Txt.Text;
        }
        private void cbx_Fuente_Txt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                CampoEditable.Elemento.SetValue(TextBlock.FontFamilyProperty, new FontFamily((sender as ComboBox).SelectedItem.ToString()));
            }
            catch
            {
                CampoEditable.Elemento.SetValue(TextBlock.FontFamilyProperty, new FontFamily(FuenteTextoDefecto));
            }
        }
        private void tbx_Tamaño_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbx_Tamaño_Txt.Text != "")
            {
                try
                {
                    CampoEditable.Tamaño = int.Parse(tbx_Tamaño_Txt.Text);
                }
                catch
                {
                    int tbPos = ((TextBox)sender).SelectionStart;
                    tbx_Tamaño_Txt.Text = CampoEditable.Tamaño.ToString();
                    ((TextBox)sender).Select(tbPos, 0);

                }
            }

        }
        private void tbx_Rotacion_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbx_Rotacion_Txt.Text != "")
            {
                try
                {
                    CampoEditable.Rotacion = int.Parse(tbx_Rotacion_Txt.Text);
                }
                catch
                {
                    int tbPos = ((TextBox)sender).SelectionStart;
                    tbx_Rotacion_Txt.Text = CampoEditable.Rotacion.ToString();
                    ((TextBox)sender).Select(tbPos, 0);

                }
            }
        }
        private void tbx_Columna_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                CampoEditable.ColumnaExcel = tbx_Columna_Txt.Text;
            }
            catch
            {
                int tbPos = ((TextBox)sender).SelectionStart;
                tbx_Columna_Txt.Text = CampoEditable.ColumnaExcel;
                ((TextBox)sender).Select(tbPos, 0);

            }
        }
        private void tbx_AntesValor_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                CampoEditable.TextoAnterior = tbx_AntesValor_Txt.Text;
            }
            catch
            {
                int tbPos = ((TextBox)sender).SelectionStart;
                tbx_AntesValor_Txt.Text = CampoEditable.TextoAnterior;
                ((TextBox)sender).Select(tbPos, 0);

            }
        }
        private void tbx_DespuesValor_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                CampoEditable.TextoPosterior = tbx_DespuesValor_Txt.Text;
            }
            catch
            {
                int tbPos = ((TextBox)sender).SelectionStart;
                tbx_DespuesValor_Txt.Text = CampoEditable.TextoPosterior;
                ((TextBox)sender).Select(tbPos, 0);

            }
        }

        //Eventos Editor Imagen
        private void tbx_Nombre_IMG_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbx_Nombre_IMG.Text != "")
            {
                try
                {
                    CampoEditable.Valor = tbx_Nombre_IMG.Text;

                }
                catch
                {
                    CampoEditable.Valor = "pack://application:,,/EditorPCF;Component/DefaultIMG512px.png";
                }
            }

        }
        private void tbx_Tamaño_IMG_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbx_Tamaño_IMG.Text != "")
            {
                try
                {
                    CampoEditable.Tamaño = int.Parse(tbx_Tamaño_IMG.Text);
                }
                catch
                {
                    int tbPos = ((TextBox)sender).SelectionStart;
                    tbx_Tamaño_IMG.Text = CampoEditable.Tamaño.ToString();
                    ((TextBox)sender).Select(tbPos, 0);

                }
            }
        }
        private void tbx_Rotacion_IMG_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbx_Rotacion_IMG.Text != "")
            {
                try
                {
                    CampoEditable.Rotacion = int.Parse(tbx_Rotacion_IMG.Text);
                }
                catch
                {
                    int tbPos = ((TextBox)sender).SelectionStart;
                    tbx_Rotacion_IMG.Text = CampoEditable.Rotacion.ToString();
                    ((TextBox)sender).Select(tbPos, 0);

                }
            }
        }
        private void tbx_Columna_IMG_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                CampoEditable.ColumnaExcel = tbx_Columna_IMG.Text;
            }
            catch
            {
                int tbPos = ((TextBox)sender).SelectionStart;
                tbx_Columna_IMG.Text = CampoEditable.ColumnaExcel;
                ((TextBox)sender).Select(tbPos, 0);

            }
        }


        private void tbx_AntesValor_IMG_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                CampoEditable.TextoAnterior = tbx_AntesValor_IMG.Text;
            }
            catch
            {
                int tbPos = ((TextBox)sender).SelectionStart;
                tbx_AntesValor_IMG.Text = CampoEditable.TextoAnterior;
                ((TextBox)sender).Select(tbPos, 0);
            }
        }
        private void tbx_DespuesValor_IMG_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                CampoEditable.TextoPosterior = tbx_DespuesValor_IMG.Text;
            }
            catch
            {
                int tbPos = ((TextBox)sender).SelectionStart;
                tbx_DespuesValor_IMG.Text = CampoEditable.TextoPosterior;
                ((TextBox)sender).Select(tbPos, 0);

            }
        }



        //Abrir Ventana de tamaños
        private void Tamaños_Click(object sender, RoutedEventArgs e)
        {

            View.VentanaTamaños vtamaños = new View.VentanaTamaños();
            vtamaños.Owner = this;
            vtamaños.ShowDialog();

            LoadTamaños();
        }

        private void cbx_Tamaño_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ComboBox).SelectedItem != null)
            {
                Perfil.Ancho = ((sender as ComboBox).SelectedItem as Tamaño).Ancho;
                Perfil.Alto = ((sender as ComboBox).SelectedItem as Tamaño).Alto;
                CargarHerramientasTop();
            }

        }

        private void BisregCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                try
                {
                    Perfil.CamposPerfil.Remove(ceditable);
                    CargarCanvas();
                    VisibilityToolbarIMG(false);
                    VisibilityToolbarTxt(false);
                }
                catch
                {

                }

            }
        }

        private void CanvasView_Drop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                { // Note that you can have more than one file.
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                    // Assuming you have one file that you care about, pass it off to whatever //
                    // handling code you have defined.
                    if (files[0].EndsWith(".pcf"))
                    {

                        CargarDocumento(PerfilCatalogo.GetPerfilCatalogo(files[0]));

                    }
                }
            }
            catch
            {
                MessageBox.Show("No se a podido cargar el perfil");
            }

        }

        
    }
}
