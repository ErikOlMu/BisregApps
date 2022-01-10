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
using Referencias_CSV.Modulos;
using BisregApi.Utilidades;
using System.ComponentModel;
using System.Reflection;
using BisregApi.SQLite;
using BisregApi.SQLite.Tipos;
namespace Referencias_CSV.Vista
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    /// 

    public class PUEBLO : DatabaseItem
    {
        public PrimaryString ID { get; set; }
        public PrimaryInt IDN { get; set; }
        public String Nombre { get; set; }
        public Int64? Edad { get; set; }
    }

    public class PUEBLO2 : DatabaseItem
    {
        public PrimaryString ID { get; set; }
        public PrimaryInt IDN { get; set; }
        public String Nombre { get; set; }
        public Int64? Edad { get; set; }
    }

    public partial class Principal : Window
    {
        public string rutaxml = "Erik.xml";
        ListaRelacion documento;
        public Principal()
        {
            //importarDocumento();
            PUEBLO item = new PUEBLO() {ID = "1", IDN = 1 };
            InitializeComponent();

            GestorBDD gestor = new GestorBDD("erik.bdd");

            gestor.GenerarSQL(typeof(PUEBLO), typeof(PUEBLO2));

            //gestor.SelectDatabaseItem(item);
            //gestor.DeleteDatabaseItem(item);
                        

            //Obtengo la Lista de el xml de relaciones
            //dtg_Relaciones.ItemsSource = documento.relaciones;

        }

        private void importarDocumento()
        {
            //Importo el documento
            documento = XmlDocument.getDocument(rutaxml, typeof(ListaRelacion)) as ListaRelacion;
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            documento.relaciones = dtg_Relaciones.ItemsSource as List<Relacion>;
            documento.Save();
            importarDocumento();

            PropertyInfo[] properties = typeof(Relacion).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                string NombreAtributo = property.Name;
                property.SetValue(documento.relaciones[0], "eRIK");
                string Valor = property.GetValue(documento.relaciones[0]).ToString();
                MessageBox.Show("El atributo " + NombreAtributo + " tiene el valor: " + Valor+ " "+ property.PropertyType.ToString());

            }

        }   
    }
}