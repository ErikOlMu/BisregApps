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
using BisregApi.Utilidades;
using System.ComponentModel;
using System.Reflection;
using BisregApi.SQLite;
namespace Referencias_CSV.Vista
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    /// 


    //Clase de objeto base de datos
    public class Relacion
    {
        [CampoSQL(PrimaryKey =true, NotNull = true)]
        public string ID { get; set; }
        [CampoSQL(NotNull = true)]
        public string RefMokua { get; set; }
        [CampoSQL(NotNull = true)]
        public string RefProduccion { get; set; }
    }

    public partial class Principal : Window
    {
        GestorBDD gestor;
        List<Relacion> relaciones;

        public Principal()
        {

            InitializeComponent();

            gestor = new GestorBDD("erik.data");


            relaciones = gestor.SelectDatabaseItem(new Relacion());


            dtg_Relaciones.ItemsSource = relaciones;

        }


        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            gestor.UpdateDatabaseItem(dtg_Relaciones.ItemsSource as List<Relacion>);
            
        }
        private bool _handle = true;
        private void dtg_Relaciones_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (_handle)
            {
                _handle = false;
                dtg_Relaciones.CommitEdit();
                gestor.UpdateDatabaseItem(dtg_Relaciones.SelectedItem as Relacion);
                _handle = true;
            }
            
        }

        private void dtg_Relaciones_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            if (e.NewItem != null) gestor.UpdateDatabaseItem(e.NewItem as Relacion);
        }

     
    }
}