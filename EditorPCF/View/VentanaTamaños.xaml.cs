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
using EditorPCF.Objetos;
namespace EditorPCF.View
{
    /// <summary>
    /// Lógica de interacción para VentanaTamaños.xaml
    /// </summary>
    public partial class VentanaTamaños : Window
    {
        ColeccionTamaños tamaños;
        public VentanaTamaños()
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

            InitializeComponent();
            RefreshTamaños();
        }



        //Recargar lbx Tamaños
        private void RefreshTamaños()
        {
            if (tamaños != null)
            {
                tamaños.Save();
                lbx_Tamaños.ItemsSource = null;

                lbx_Tamaños.ItemsSource = tamaños.Tamaños;
            }

        }

        private void btn_Añadir_Click(object sender, RoutedEventArgs e)
        {
            Tamaño tam = new Tamaño();
            tam.Nombre = tbx_Nombre.Text;
            bool añadir = true;
            double result;
            if (double.TryParse(tbx_Ancho.Text, out result))
            {
                tam.Ancho = result;
            }
            else
            {
                tbx_Ancho.Foreground = Brushes.Red;
                añadir = false;
            }

            if (double.TryParse(tbx_Alto.Text, out result))
            {
                tam.Alto = result;
            }
            else
            {
                tbx_Alto.Foreground = Brushes.Red;
                añadir = false;
            }
            if (añadir)
            {
                tamaños.Tamaños.Add(tam);
                tbx_Nombre.Text = "";
                tbx_Alto.Text = "";
                tbx_Ancho.Text = "";
                RefreshTamaños();
            }
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


        private void tbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).Foreground == Brushes.Red)
            {
                (sender as TextBox).Foreground = Brushes.Black;
            }
        }

        private void lbx_Tamaños_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                try
                {

                    tamaños.Tamaños.RemoveAt((sender as ListBox).SelectedIndex);
                    RefreshTamaños();
                }
                catch
                {

                }
            }

        }
    }
}