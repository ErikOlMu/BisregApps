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
using BisregApi.PDF;
using BisregApi.Utilidades;
using PrintBisreg.Modulos;
using System.Threading;
using System.ComponentModel;

namespace PrintBisreg.Vista
{
    /// <summary>
    /// Lógica de interacción para VentanaPrincipal.xaml
    /// </summary>
    public partial class VentanaPrincipal : Window
    {
        List<ItemProduccion> Referencias = new List<ItemProduccion>();
        CollecionReglas Reglas = new CollecionReglas();
        DataTable dataTableCantidades;
        DataTable dataTablePMinimo;
        DataTable dataTableAgotados;
        DataTable dataTablePlotter;
        Settings settings;
        public VentanaPrincipal()
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

            
            InitializeComponent();

            ReloadBDD();

            lst_items.ItemsSource = Referencias;

            //Inicio Settings
            StartSettings();

            
        }
        private void AñadirReferencia()
        {
            ItemProduccion item = new ItemProduccion(tbx_Referencia.Text, int.Parse(tbx_Copias.Text));
            if (item.Valido)
            {
                Referencias.Add(item);
                //Refresh el ItemSource
                CollectionViewSource.GetDefaultView(lst_items.ItemsSource).Refresh();
                tbx_Referencia.Text = "";
                tbx_Copias.Text = "1";

            }
            else
            {
                LogWrite("El item '" + tbx_Referencia.Text + "' no es valido");

            }
            
        }

        private void AñadirReferencia(string Referencia, int Copias,string Pedido)
        {
            ItemProduccion item = new ItemProduccion(Referencia, Copias, Pedido);
            if (item.Valido)
            {
                Referencias.Add(item);
                //Refresh el ItemSource
                CollectionViewSource.GetDefaultView(lst_items.ItemsSource).Refresh();

            }
            else
            {
                LogWrite("El item '" + Referencia + "' no es valido");

            }

        }

        private void LogWrite(string Texto)
        {

            tbk_Log.Text = tbk_Log.Text +"\n"+ Texto;
            slv_Log.ScrollToBottom();


        }

        private void tbx_Referencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AñadirReferencia();

            }
        }

        private void btn_AñadirReferencia_Click(object sender, RoutedEventArgs e)
        {
            AñadirReferencia();
        }

        private void lst_items_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ItemProduccion? item = null;
            try
            {
                item = e.AddedItems[0] as ItemProduccion;
                if (item != null)
                {
                    string file = item.GetRutaDiseño(settings.CarpetaDiseños);
                    pdfViewer.Source = new Uri(file);
                }
            }
            catch
            {
                pdfViewer.Source = null;
                if (item != null) LogWrite("No se encuentra el diseño de '" + item.Codigo + "'.");
            }
        }
        private void btn_Importar_Click(object sender, RoutedEventArgs e)
        {
            List<string> Files = Dialogos.OpenFiles();
            foreach (string file in Files)
            {
                if (file.EndsWith(".csv"))
                {
                    DataTable data = CSV.GetDataTable(Files[0], true);
                    foreach (DataRow dtRow in data.Rows)
                    {
                        try
                        {
                            string Referencia = dtRow[data.Columns[1]].ToString().Replace("\"", "");
                            int Copias = int.Parse(dtRow[data.Columns[0]].ToString().Replace("\"", ""));
                            AñadirReferencia(Referencia, Copias, System.IO.Path.GetFileNameWithoutExtension(file));
                        }
                        catch
                        {
                            LogWrite("Error de Lectura en linea " + data.Rows.IndexOf(dtRow) + "");
                        }
                    }
                }
                else
                {
                    LogWrite("El Archivo '" + file + "' no es un '.csv'");
                }
                
            }
        }

        private void btnGuardarReglasCantidad_Click(object sender, RoutedEventArgs e)
        {
            Reglas.SaveDataTable(dataTableCantidades);
            UpdateDataGridCantidades();
        }

        private void UpdateDataGridCantidades()
        {
            dataTableCantidades = Reglas.GetDataTable("ReglaCantidad");
            dtg_ReglasCantidad.ItemsSource = dataTableCantidades.DefaultView;
        }

        private void btnGuardarReglasPMinimo_Click(object sender, RoutedEventArgs e)
        {
            Reglas.SaveDataTable(dataTablePMinimo);
            UpdateDataGridPMinimo();
        }

        private void UpdateDataGridPMinimo()
        {
            dataTablePMinimo = Reglas.GetDataTable("ReglaPMinimo");
            dtg_ReglasPMinimo.ItemsSource = dataTablePMinimo.DefaultView;
        }

        private void btnGuardarReglasAgotados_Click(object sender, RoutedEventArgs e)
        {
            Reglas.SaveDataTable(dataTableAgotados);
            UpdateDataGridAgotados();
        }

        private void UpdateDataGridAgotados()
        {
            dataTableAgotados = Reglas.GetDataTable("ReglaAgotados");
            dtg_ReglasAgotados.ItemsSource = dataTableAgotados.DefaultView;
        }

        private void btnGuardarReglasPlotter_Click(object sender, RoutedEventArgs e)
        {
            Reglas.SaveDataTable(dataTablePlotter);
            UpdateDataGridPlotter();
        }

        private void UpdateDataGridPlotter()
        {
            dataTablePlotter = Reglas.GetDataTable("ReglaPlotter");
            dtg_ReglasPlotter.ItemsSource = dataTablePlotter.DefaultView;
        }

        private void lst_items_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                try
                {
                    int index = (sender as ListView).SelectedIndex;
                    string referencia = Referencias[index].Codigo;
                    Referencias.RemoveAt(index);

                    ICollectionView view = CollectionViewSource.GetDefaultView(Referencias);
                    view.Refresh();

                    LogWrite("Se a eliminado la Referencia: " + referencia);
                }
                catch
                {
                    LogWrite("Error al Eliminar");
                }

            }
        }

        private void btn_Generar_Click(object sender, RoutedEventArgs e)
        {
            //Metodo plara generar plotter





        }


        //Settings
        private void tbx_AltoMaximo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbx_AltoMaximo.Text == "")
            {
                settings.AltoMaximo = 0;
                settings.Save();
            }
            else
            {
                int tbPos = ((TextBox)sender).SelectionStart;
                string tmp = settings.AltoMaximo.ToString();
                if (Double.TryParse(tbx_AltoMaximo.Text, out settings.AltoMaximo)) settings.Save();
                else
                {
                    tbx_AltoMaximo.Text = tmp;
                    ((TextBox)sender).Select(tbPos, 0);
                }
            }
        }

        private void tbx_AnchoMaximo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbx_AnchoMaximo.Text == "")
            {
                settings.AnchoMaximo = 0; 
                settings.Save();
            }
            else
            {
                int tbPos = ((TextBox)sender).SelectionStart;
                string tmp = settings.AnchoMaximo.ToString();
                if (Double.TryParse(tbx_AnchoMaximo.Text, out settings.AnchoMaximo)) settings.Save();
                else
                {
                    tbx_AnchoMaximo.Text = tmp;
                    ((TextBox)sender).Select(tbPos, 0);
                }
            }
        }

        private void tbx_PaddingAlto_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbx_PaddingAlto.Text == "")
            {
                settings.PaddingAlto = 0; 
                settings.Save();
            }
            else
            {
                int tbPos = ((TextBox)sender).SelectionStart;
                string tmp = settings.PaddingAlto.ToString();
                if (Double.TryParse(tbx_PaddingAlto.Text, out settings.PaddingAlto)) settings.Save();
                else
                {
                    tbx_PaddingAlto.Text = tmp;
                    ((TextBox)sender).Select(tbPos, 0);
                }
            }

        }

        private void tbx_PaddingAncho_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbx_PaddingAncho.Text == "")
            {
                settings.PaddingAncho = 0; 
                settings.Save();
            }
            else
            {
                int tbPos = ((TextBox)sender).SelectionStart;
                string tmp = settings.PaddingAncho.ToString();
                if (Double.TryParse(tbx_PaddingAncho.Text, out settings.PaddingAncho)) settings.Save();
                else
                {
                    tbx_PaddingAncho.Text = tmp;
                    ((TextBox)sender).Select(tbPos, 0);
                }
            }
        }

        private void tbx_MargenAlto_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbx_MargenAlto.Text == "")
            {
                settings.MargenAlto = 0; 
                settings.Save();
            }
            else
            {
                int tbPos = ((TextBox)sender).SelectionStart;
                string tmp = settings.MargenAlto.ToString();
                if (Double.TryParse(tbx_MargenAlto.Text, out settings.MargenAlto)) settings.Save();
                else
                {
                    tbx_MargenAlto.Text = tmp;
                    ((TextBox)sender).Select(tbPos, 0);
                }
            }
        }

        private void tbx_MargenAncho_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbx_MargenAncho.Text == "")
            {
                settings.MargenAncho = 0;
                settings.Save();
            }
            else
            {
                int tbPos = ((TextBox)sender).SelectionStart;
                string tmp = settings.MargenAncho.ToString();
                if (Double.TryParse(tbx_MargenAncho.Text, out settings.MargenAncho)) settings.Save();
                else
                {
                    tbx_MargenAncho.Text = tmp;
                    ((TextBox)sender).Select(tbPos, 0);
                }
            }

        }

        private void btn_Sentido_Click(object sender, RoutedEventArgs e)
        {

            if (btn_Sentido.Content.ToString() == "Vertical")
            {
                settings.Sentido = false;
                btn_Sentido.Content = "Horizontal";
            }
            else
            {
                settings.Sentido = true;
                btn_Sentido.Content = "Vertical";
            }

            settings.Save();

        }

        private void btn_Info_Click(object sender, RoutedEventArgs e)
        {
            if (btn_Info.Content.ToString() == "On")
            {
                settings.Info = false;
                btn_Info.Content = "Off";
            }
            else
            {
                settings.Info = true;
                btn_Info.Content = "On";
            }
            settings.Save();

        }

        private void StartSettings()
        {
            tbx_AltoMaximo.Text = settings.AltoMaximo.ToString();
            tbx_AnchoMaximo.Text = settings.AnchoMaximo.ToString();
            tbx_PaddingAlto.Text = settings.PaddingAlto.ToString();
            tbx_PaddingAncho.Text = settings.PaddingAncho.ToString();
            tbx_MargenAlto.Text = settings.MargenAlto.ToString();
            tbx_MargenAncho.Text = settings.MargenAncho.ToString();

            if (settings.Sentido) btn_Sentido.Content = "Vertical";
            else btn_Sentido.Content = "Horizontal";
            if (settings.Info) btn_Info.Content = "On";
            else btn_Info.Content = "Off";

            tbx_Datos.Text = settings.rutaBDD;
            tbx_Diseños.Text = settings.CarpetaDiseños;

            tbx_Salida.Text = settings.CarpetaSalida;

        }

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

        private void tbx_Datos_TextChanged(object sender, TextChangedEventArgs e)
        {   
            settings.rutaBDD = tbx_Datos.Text;
            settings.Save();
        }

        private void btn_Datos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tbx_Datos.Text = Dialogos.OpenFile();
            }
            catch{}
        }

        private void btn_RecargarDatos_Click(object sender, RoutedEventArgs e)
        {
            if (ReloadBDD()) MessageBox.Show("Datos Cargados Correctamente");
        }

        private bool ReloadBDD()
        {
            try
            {
                Reglas = null;
                Reglas = new CollecionReglas();
                if (!Reglas.DBValida())
                {
                    throw new Exception("Error");
                }
                btn_RecargarDatos.Foreground = Brushes.Green;
                //Hacemos Update de las Reglas
                UpdateDataGridCantidades();
                UpdateDataGridPMinimo();
                UpdateDataGridAgotados();
                UpdateDataGridPlotter();
                return true;
                
            }
            catch
            {
                btn_RecargarDatos.Foreground = Brushes.Red;
                MessageBox.Show("No se a podido cargar la Base de datos");
                return false;
            }
        }

        private void tbx_Diseños_TextChanged(object sender, TextChangedEventArgs e)
        {
            settings.CarpetaDiseños = tbx_Diseños.Text;
            settings.Save();
        }

        private void btn_Diseños_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tbx_Diseños.Text = Dialogos.OpenFolder();
            }
            catch { }
        }

        private void tbx_Salida_TextChanged(object sender, TextChangedEventArgs e)
        {
            settings.CarpetaSalida = tbx_Salida.Text;
            settings.Save();
        }

        private void btn_Salida_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tbx_Salida.Text = Dialogos.OpenFolder();
            }
            catch { }
        }
    }
}
