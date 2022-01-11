using System;
using System.Collections.Generic;
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
using Catalogos_Bisreg.Modulos;
using BisregApi.Utilidades;
using System.IO;
using System.Dynamic;
using System.Data;


namespace Catalogos_Bisreg.Vista
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        private string SettingsFile = "Config.conf";
        private Settings settings;


        //Constructor
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
                settings = (Settings) Config.getConfig("Config.conf", typeof(Settings));
            }

            //Añado las configuraciones a la vista
            tbx_DirectorioImagenes.Text = settings.Directorio_IMG;
        }

        //Evento de cambiar directorio Imagenes
        private void tbx_DirectorioImagenes_TextChanged(object sender, TextChangedEventArgs e)
        {
            settings.Directorio_IMG = tbx_DirectorioImagenes.Text;
            settings.Save();
        }

        //Boton para seleccionar carpeta imagenes
        private void btn_DirectorioImagenes_Click(object sender, RoutedEventArgs e)
        {
            tbx_DirectorioImagenes.Text = Dialogos.OpenFolder();
        }

        //Añado la Columna IMG y hago que sea ReadOnly
        private DataTable ComprobarIMG(DataTable data)
        {
            //Si no existe la creo
            if (data.Columns["IMG"] == null)
            {
                data.Columns.Add("IMG", typeof(bool));

                foreach (DataRow row in data.Rows)
                {
                    row["IMG"] = (File.Exists(settings.Directorio_IMG + "\\" + row["Referencia"] + ".jpg") || File.Exists(settings.Directorio_IMG + "\\" + row["Referencia"] + ".png") || File.Exists(settings.Directorio_IMG + "\\" + row["Referencia"] + "_0.jpg") || File.Exists(settings.Directorio_IMG + "\\" + row["Referencia"] + "_0.png"));
                }
            }
            //Si existe la actualizo
            else
            {
                data.Columns["IMG"].ReadOnly = false;
                foreach (DataRow row in data.Rows)
                {
                    try
                    {
                        row["IMG"] = (File.Exists(settings.Directorio_IMG + "\\" + row["Referencia"] + ".jpg") || File.Exists(settings.Directorio_IMG + "\\" + row["Referencia"] + ".png") || File.Exists(settings.Directorio_IMG + "\\" + row["Referencia"] + "_0.jpg") || File.Exists(settings.Directorio_IMG + "\\" + row["Referencia"] + "_0.png"));
                    }
                    catch
                    {
                        //La Fila esta eliminada, se continua y listo
                    }
                }

            }
            data.Columns["IMG"].ReadOnly = true;

            return data;

        }

        //Importar Excel
        private void btn_ImportarExcel_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {

                

                //Creo una Lista para los campos
                List<String> Campos = new List<string>();
                
                //Añado el Campo Referencia
                Campos.Add("Referencia");

                //Obtengo la Lista de Campos
                Campos.AddRange(lbx_Campos.Items.OfType<string>().ToList());


                //Obtengo el DataView desde el excel
                DataTable data = Excel.GetDataTable(Dialogos.OpenFile(), Campos, settings.Limite_Excel);

                if (data != null)
                {
                    //Compruebo que tenga IMG y lo añado
                    dtg.ItemsSource = ComprobarIMG(data).DefaultView;

                    MessageBox.Show("Excel Importado con exito");
                }
                else
                {
                    MessageBox.Show("Error Importando Excel. Comprueba si el tiene mas de " + settings.Limite_Excel + " referencias");
                }

                
            }

            catch (Exception)
            {
                dtg.ItemsSource = null;

                MessageBox.Show("Algo ha salido Mal");
            }

            
        }

        //Añadir campo
        private void tbx_AñadirCampo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                lbx_Campos.Items.Add(tbx_AñadirCampo.Text);
                tbx_AñadirCampo.Text = "";
            }
        }

        //Eliminar Campo
        private void lbx_Campos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                lbx_Campos.Items.Remove(lbx_Campos.SelectedItem);
            }
        }

        //Actualizar el campo de fotos
        private void btn_RecargarFotos_Click(object sender, RoutedEventArgs e)
        {
            if (dtg.ItemsSource != null)
            {
                dtg.ItemsSource = ComprobarIMG((dtg.ItemsSource as DataView).Table).DefaultView;
            }
            else
            {
                MessageBox.Show("Primero tienes que Importar un Excel");
            }
        }

        //Abrir Ventana para Generar PDF
        private void btn_GenerarPDF_Click(object sender, RoutedEventArgs e)
        {
            if(dtg.ItemsSource != null)
            {
                //Mando los datos de la tabla y los campos que quiero añadir
                new PDFView((dtg.ItemsSource as DataView).Table,lbx_Campos.Items.OfType<string>().ToList()).Show();
            }
            else
            {
                MessageBox.Show("Primero Importa los datos");
            }
        }
    }
}
