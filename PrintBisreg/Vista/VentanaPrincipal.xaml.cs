using BisregApi.Utilidades;
using PdfiumViewer;
using PrintBisreg.Modulos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;
using BisregApi.PDF;
using BisregApi.Diseño;
using System.Reflection;

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
        Thread RecargaImagenes;
        CancellationTokenSource TokenCancelar;
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


            //Cargamos los Datos de las rteglas
            ReloadBDD();


            //enlazamos el objeto Referencias con el list_items
            lst_items.ItemsSource = Referencias;


            //Inicio Settings
            StartSettings();



            
            
        }


        //Metodo para añadir referencia desde el tbx_Referencia
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
        //Añadir referencia al ListView
        private void AñadirReferencia(string Referencia, int Copias, string Pedido)
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
        //Metodo para poner la imagen de Recarga temporal al pdfviewer
        private static void StartReloadImage(System.Windows.Controls.Image img)
        {

            img.Source = null;

            img.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
                BitmapImage imagen = new BitmapImage();

                var bi = new BitmapImage();

                var assembly = Assembly.GetExecutingAssembly();
                var resourcename = "PrintBisreg.Reload.gif";
                using (var fs = assembly.GetManifestResourceStream(resourcename))
                {
                    bi.BeginInit();
                    bi.StreamSource = fs;
                    bi.CacheOption = BitmapCacheOption.OnLoad;
                    bi.EndInit();
                    try
                    {
                        ImageBehavior.SetAnimatedSource(img, bi);
                    }
                    catch { }

                }


                img.MaxHeight = 100;

                bi.Freeze();

            });


        }
        //Recargar la Imagen por la que esta generada en el pdfviewer
        private static void ReloadImage(System.Windows.Controls.Image img)  
        {
            try
            {
                ImageBehavior.SetAnimatedSource(img, null);
            }
            catch { }
                img.Source = null;

                img.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (ThreadStart)delegate ()
                {
                    BitmapImage imagen = new BitmapImage();

                    var bi = new BitmapImage();

                    using (var fs = new FileStream(Directory.GetCurrentDirectory() + "//view.tmp", FileMode.Open))
                    {
                        bi.BeginInit();
                        bi.StreamSource = fs;
                        bi.CacheOption = BitmapCacheOption.OnLoad;
                        bi.EndInit();
                    }
                    img.MaxHeight = 1000;
                    bi.Freeze();
                    img.Source = bi;
                });
            

        }
        //Metodo principal para recargar el la imagen del pdfviewer en un Thread aparte
        private static void GuardarAndReloadPDF(string ruta, Image imagen, Thread? Anterior, CancellationToken cancellationToken, CancellationTokenSource? cancellationTokenAnterior)

        {

            if (Anterior != null)
            {
                if (cancellationTokenAnterior != null) cancellationTokenAnterior.Cancel();
                Anterior.Join();
            }
            if (!cancellationToken.IsCancellationRequested)
            {
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {

                    StartReloadImage(imagen);

                }));
                GuardarImagenPDF(ruta);
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {

                    ReloadImage(imagen);

                }));
            }

        }
        //Guardar la primera pagina de un PDF como una imagen
        public static void GuardarImagenPDF(string ruta)
        {
            var document = PdfDocument.Load(ruta);
                var pageCount = document.PageCount;

                var dpi = 300;

            var image = document.Render(0, dpi, dpi, PdfRenderFlags.CorrectFromDpi);
                
                    var encoder = ImageCodecInfo.GetImageEncoders()
                        .First(c => c.FormatID == ImageFormat.Jpeg.Guid);
                    var encParams = new EncoderParameters(1);
                    encParams.Param[0] = new EncoderParameter(Encoder.Quality, 100L);

                    File.Delete(Directory.GetCurrentDirectory() + "//view.tmp");
                    image.Save(Directory.GetCurrentDirectory() + "//view.tmp", encoder, encParams);

        }
        //Esxribir en el Log 
        private void LogWrite(string Texto)
        {

            tbk_Log.Text = tbk_Log.Text +"\n"+ Texto;
            slv_Log.ScrollToBottom();


        }
        //Escribir en el Log desde otro Thread
        private static void LogWrite(string Texto, TextBlock tbk_Log, ScrollViewer slv_Log)
        {

            tbk_Log.Text = tbk_Log.Text + "\n" + Texto;
            slv_Log.ScrollToBottom();


        }
        //Metodo para cambiar la foto del pdfViewer, Usando Threads
        private void CambiarFoto(ItemProduccion item)
        {
            if (item != null)
            {
                string file = item.GetRutaDiseño(settings.CarpetaDiseños);
                //Compruebo que exista el archivo y lo creo
                if (File.Exists(file))
                {
                    Thread? Anterior = RecargaImagenes;
                    CancellationTokenSource? TokenAnterior = TokenCancelar;
                    TokenCancelar = new CancellationTokenSource();
                    RecargaImagenes = new Thread(() => GuardarAndReloadPDF(file, pdfViewer, Anterior, TokenCancelar.Token, TokenAnterior));
                    RecargaImagenes.Start();
                }
                else
                {
                    pdfViewer.Source = null;
                    if (item != null) LogWrite("No se encuentra el diseño de '" + item.Codigo + "'.");
                }
            }
            
        }
        //Metodo para importar uno o varios CSV al programa
        private void ImportarCSV()
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
                            string Referencia = (dtRow[data.Columns[1]].ToString() ?? "").Replace("\"", "");
                            int Copias = int.Parse((dtRow[data.Columns[0]].ToString()?? "").Replace("\"", ""));
                            AñadirReferencia(Referencia, Copias, Path.GetFileNameWithoutExtension(file));
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
        //Eventos de los Controles WPF
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
            var item = e.AddedItems[0] as ItemProduccion;
            if (item != null) CambiarFoto(item);
        }
        private void btn_Importar_Click(object sender, RoutedEventArgs e)
        {
            ImportarCSV();
        }
        //Eventos Controles WPF de las Reglas
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

        //Evento para eliminar las selecciones de el listview
        private void lst_items_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                try { 

                    foreach(ItemProduccion item in (sender as ListView ?? new ListView()).SelectedItems)
                    {

                        Referencias.Remove(item);
                        LogWrite("Se a eliminado la Referencia: " + item.Codigo);
                    }


                    ICollectionView view = CollectionViewSource.GetDefaultView(Referencias);
                    view.Refresh();

                }
                catch
                {
                    LogWrite("Error al Eliminar");
                }

            }
        }

        
        //Metodo para generar plotter
        private void btn_Generar_Click(object sender, RoutedEventArgs e)
        {
            Thread GenerarThread = new Thread(() => Generar(Referencias, Reglas, settings, tbk_Log, slv_Log,lbl_Process, pbr_Generar));
            GenerarThread.Start();
        }
        //Thread para generar el plotter
        public static void Generar(List<ItemProduccion> Referencias,CollecionReglas Reglas,Settings settings, TextBlock tbk_Log, ScrollViewer slv_Log,Label lbl_Process, ProgressBar pbr_Generar)
        {
            if (Referencias.Count != 0)
            {
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    pbr_Generar.Maximum = Referencias.Count;
                    pbr_Generar.Value = 0;
                }));
            //-----------------Nota Erik Revisar Gestion de Copias
            foreach (ItemProduccion item in Referencias)
                {
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        lbl_Process.Content = "Generando " + item.Codigo;
                    }));
                    //Miramos si esta agotado
                    if (!Reglas.ConsultaAgotado(item))
                    {
                        string rutadiseño = item.GetRutaDiseño(settings.CarpetaDiseños);
                        //revisamos si existe el diseño
                        if (rutadiseño != "")
                        {
                            //Calculo las Copias
                            int Copias = item.Copias;

                            //Si es  menos que el pedido minimo lo paso a Pedido Minimo
                            int PedidoMinimo = Reglas.ConsultaReglaPMinimo(item);
                            if (Copias < PedidoMinimo) Copias = PedidoMinimo;

                            //Calculo las Copias que necesito
                            if (item.CopiasXArchivo == 1) Copias = (int)Math.Ceiling((decimal)Copias / (decimal)Reglas.ConsultaReglaCantidad(item));
                            else Copias = (int)Math.Ceiling((decimal)Copias / (decimal)item.CopiasXArchivo);


                            //Miramos si es un plotter
                            if (!Reglas.ConsultaPlotter(item))
                            {
                                PDFPlotter.CrearPlancha(item,settings.CarpetaSalida, rutadiseño, Conversor.mm2Px(settings.AnchoMaximo,72), Conversor.mm2Px(settings.AltoMaximo, 72), Copias, new Margin(Conversor.mm2Px(settings.MargenAlto, 72), Conversor.mm2Px(settings.MargenAncho, 72)), new Margin(Conversor.mm2Px(settings.PaddingAlto, 72), Conversor.mm2Px(settings.MargenAncho, 72)), settings.Sentido, settings.Info,CutContour:true);
                            }
                            else
                            {

                                //Codigo Copiar Source X veces
                                for (int i = 0; i < Copias; i++)
                                {
                                    string RutaSalida = settings.CarpetaSalida + "\\" + item.Pedido + item.Codigo + "_" + i + ".pdf";

                                    if (!File.Exists(RutaSalida))
                                    {

                                        File.Copy(rutadiseño, RutaSalida);
                                    }
                                    else
                                    {
                                        Application.Current.Dispatcher.Invoke(new Action(() =>
                                        {

                                            LogWrite("Ya existe el Archivo " + RutaSalida + " (" + item.Codigo + ")",tbk_Log,slv_Log);

                                        }));
                                    }

                                }
                            }
                        }
                        else
                        {
                            Application.Current.Dispatcher.Invoke(new Action(() =>
                            {

                                LogWrite("No se encuentra el diseño de '" + item.Codigo + "'.", tbk_Log, slv_Log);

                            }));
                          
                        }
                    }
                    else
                    {
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {

                            LogWrite("La referencia " + item.Codigo + " esta agotada", tbk_Log, slv_Log);

                        }));
                    }
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    { 
                        pbr_Generar.Value = pbr_Generar.Value + 1;
                    }));

            }
            }
            else
            {
                MessageBox.Show("Añade Referencias a la Lista");
            }

            MessageBox.Show("Generado");

            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                lbl_Process.Content = null;

                pbr_Generar.Value = 0;

            }));
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
        private void tbx_Datos_TextChanged(object sender, TextChangedEventArgs e)
        {
            settings.rutaBDD = tbx_Datos.Text;
            settings.Save();
        }
        private void tbx_Diseños_TextChanged(object sender, TextChangedEventArgs e)
        {
            settings.CarpetaDiseños = tbx_Diseños.Text;
            settings.Save();
        }
        private void tbx_Salida_TextChanged(object sender, TextChangedEventArgs e)
        {
            settings.CarpetaSalida = tbx_Salida.Text;
            settings.Save();
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
        private void MasCantidad_Click(object sender, RoutedEventArgs e)
        {
            if (btn_MasCantidad.Content.ToString() == "On")
            {
                settings.MasCantidad = false;
                btn_MasCantidad.Content = "Off";
            }
            else
            {
                settings.MasCantidad = true;
                btn_MasCantidad.Content = "On";
            }
            settings.Save();

        }
        private void btn_Datos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tbx_Datos.Text = Dialogos.OpenFile();
            }
            catch { }
        }
        private void btn_RecargarDatos_Click(object sender, RoutedEventArgs e)
        {
            if (ReloadBDD()) MessageBox.Show("Datos Cargados Correctamente");
        }
        private void btn_Diseños_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tbx_Diseños.Text = Dialogos.OpenFolder();
            }
            catch { }
        }
        private void btn_Salida_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tbx_Salida.Text = Dialogos.OpenFolder();
            }
            catch { }
        }

        //Añado los datos a las Pestaña settings
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
            if (settings.MasCantidad) btn_MasCantidad.Content = "On";
            else btn_MasCantidad.Content = "Off";

            tbx_Datos.Text = settings.rutaBDD;
            tbx_Diseños.Text = settings.CarpetaDiseños;

            tbx_Salida.Text = settings.CarpetaSalida;

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

        //Compruebo que la Base de Datos SQLite sea valida
        private bool ReloadBDD()
        {
            try
            {
                Reglas = new CollecionReglas();
                if (!Reglas.DBValida())
                {
                    throw new Exception("Error");
                }
                btn_RecargarDatos.Foreground = System.Windows.Media.Brushes.Green;
                //Hacemos Update de las Reglas
                UpdateDataGridCantidades();
                UpdateDataGridPMinimo();
                UpdateDataGridAgotados();
                UpdateDataGridPlotter();
                return true;
                
            }
            catch
            {
                btn_RecargarDatos.Foreground = System.Windows.Media.Brushes.Red;
                MessageBox.Show("No se a podido cargar la Base de datos");
                return false;
            }
        }


        



        
    }
}
