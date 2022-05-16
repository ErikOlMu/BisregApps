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
using CatalogosBisreg.Modulos;
using BisregApi.Utilidades;
using System.IO;
using System.Dynamic;
using System.Data;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Threading;

namespace CatalogosBisreg.Vista
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        private Settings settings;
        private PerfilCatalogo? Perfil;

        //Constructor
        public Principal()
        {
            InitializeComponent();
            try
            {
                ChangeProfile(PerfilCatalogo.GetPerfilCatalogo(Environment.GetCommandLineArgs()[1]));
            }
            catch (Exception ex)
            {

                Perfil = null;
            }
            finally
            {
                InicializarApp();
            }
        }



        //Inicializar Vista
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

        //Añado la Columna IMG y hago que sea ReadOnly //Añado el texto anterior y posterior en la busqueda
        private DataTable ComprobarIMG(DataTable data)
        {
            //Si no existe la creo
            if (data.Columns["IMG"] == null)
            {
                data.Columns.Add("IMG", typeof(bool));
                foreach (CampoCanvas c in Perfil.GetCampoXTipo(CamposCanvas.Imagen))
                {
                    if (c.ColumnaExcel != "")
                    {
                        foreach (DataRow row in data.Rows)
                        {
                            row["IMG"] = (File.Exists(settings.Directorio_IMG + "\\" +c.TextoAnterior+ row[c.ColumnaExcel] +c.TextoPosterior+ ".jpg") || File.Exists(settings.Directorio_IMG + "\\" + c.TextoAnterior + row[c.ColumnaExcel] + c.TextoPosterior + ".png") || File.Exists(settings.Directorio_IMG + "\\" + c.TextoAnterior + row[c.ColumnaExcel] + c.TextoPosterior + "_0.jpg") || File.Exists(settings.Directorio_IMG + "\\" + c.TextoAnterior + row[c.ColumnaExcel] + c.TextoPosterior + "_0.png"));
                        }
                    }
                }
            }
            //Si existe la actualizo
            else
            {
                data.Columns["IMG"].ReadOnly = false;
                foreach (CampoCanvas c in Perfil.GetCampoXTipo(CamposCanvas.Imagen))
                {
                    if (c.ColumnaExcel != "")
                    {
                        foreach (DataRow row in data.Rows)
                        {
                            try
                            {
                                row["IMG"] = (File.Exists(settings.Directorio_IMG + "\\" + c.TextoAnterior + row[c.ColumnaExcel] + c.TextoPosterior + ".jpg") || File.Exists(settings.Directorio_IMG + "\\" + c.TextoAnterior + row[c.ColumnaExcel] + c.TextoPosterior + ".png") || File.Exists(settings.Directorio_IMG + "\\" + c.TextoAnterior + row[c.ColumnaExcel] + c.TextoPosterior + "_0.jpg") || File.Exists(settings.Directorio_IMG + "\\" + c.TextoAnterior + row[c.ColumnaExcel] + c.TextoPosterior + "_0.png"));
                            }
                            catch
                            {
                                //La Fila esta eliminada, se continua y listo
                            }
                        }
                    }
                }

            }
            data.Columns["IMG"].ReadOnly = true;

            return data;

        }

        //Importar Excel
        private void btn_ImportarExcel_Click(object sender, RoutedEventArgs e)
        {
            if (Perfil != null)
            {
                try
                {

                    //Obtengo el DataView desde el excel
                    DataTable data = Excel.GetDataTable(Dialogos.OpenFile(), Perfil, settings.Limite_Excel);


                    if (data != null)
                    {


                        //Compruebo que tenga IMG y lo añado
                        //dtg.ItemsSource = ComprobarIMG(data).DefaultView;
                        dtg.ItemsSource = ComprobarIMG(data).DefaultView;

                        MessageBox.Show("Excel Importado con exito");
                    }
                    else
                    {
                        MessageBox.Show("Error Importando Excel. Comprueba si el tiene mas de " + settings.Limite_Excel + " referencias");
                    }


                }

                catch (Exception ex)
                {
                    dtg.ItemsSource = null;

                    MessageBox.Show("Algo ha salido Mal");
                }
            }
            else
            {
                MessageBox.Show("Primero añade un Perfil");
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

            if (dtg.ItemsSource == null) MessageBox.Show("Primero debes importar datos");
            else PrintDoc.Print(DocumentoCatalogo.GetFlowDocument((dtg.ItemsSource as DataView).Table, Perfil, tbx_DirectorioImagenes.Text));
            
        }

        private void btn_Generar_Click(object sender, RoutedEventArgs e)
        {
            if (dtg.ItemsSource != null)
            {
                PrintDoc.Print(DocumentoCatalogo.GetFlowDocument((dtg.ItemsSource as DataView).Table, Perfil, settings.Directorio_IMG));
            }
            else MessageBox.Show("Primero debes importar datos");
        }

        private void btn_VistaPrevia_Click(object sender, RoutedEventArgs e)
        {
            if (dtg.ItemsSource != null)
            {
                VistaPrevia vista;
                new VistaPrevia((dtg.ItemsSource as DataView).Table, settings.Directorio_IMG, Perfil).Show();
            }
            else MessageBox.Show("Primero debes importar datos");
            
        }

        private void Window_Drop(object sender, DragEventArgs e)
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

                        ChangeProfile(PerfilCatalogo.GetPerfilCatalogo(files[0]));
                    }
                }
            }
            catch
            {
                MessageBox.Show("No se a podido cargar el perfil");
                Perfil = null;
                dtg.ItemsSource = null;

            }
        }
        private void ChangeProfile(PerfilCatalogo perf)
        {
            Perfil = perf;
            MainWindow.Title = Perfil.NombrePerfil;
            dtg.ItemsSource = null;
        }
    }
}
