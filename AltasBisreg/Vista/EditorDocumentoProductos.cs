using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AltasBisreg.Modelos.Capa1;


namespace AltasBisreg.Vista
{
    public partial class EditorDocumentoProductos : Form
    {
        public List<DocumentoProducto> productos;
        public EditorDocumentoProductos()
        {

            InitializeComponent();



            productos = new List<DocumentoProducto>();
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            GridProductos, new object[] { true });
            GridProductos.DataSource = new BindingList<DocumentoProducto>(productos);
        }


        private void exportarExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new Controladores.ConnexionExcel(productos, Modelos.Settings.Config.GetFile());
        }

        private void GridProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3)
            {
                e.Handled = true;

                Buscador form = null;
                switch (GridProductos.CurrentCell.ColumnIndex)
                {
                    case 2: //Familia
                        form = new Buscador("FAMILIA", GridProductos.CurrentCell.RowIndex, GridProductos.CurrentCell.ColumnIndex, GridProductos);
                        break;
                    case 3: //Localidad
                        form = new Buscador("LOCALIDAD", GridProductos.CurrentCell.RowIndex, GridProductos.CurrentCell.ColumnIndex, GridProductos);
                        break;
                    case 4: //Seccion
                        form = new Buscador("SECCION", GridProductos.CurrentCell.RowIndex, GridProductos.CurrentCell.ColumnIndex, GridProductos);
                        break;
                    case 9: //Atributo
                        form = new Buscador("ATRIBUTO", GridProductos.CurrentCell.RowIndex, GridProductos.CurrentCell.ColumnIndex, GridProductos);
                        break;
                    case 10://RelAtributo
                        try
                        {
                            form = new Buscador("RELATRIBUTO", GridProductos.CurrentCell.RowIndex, GridProductos.CurrentCell.ColumnIndex, GridProductos, GridProductos[9, GridProductos.CurrentCell.RowIndex].Value.ToString());
                        }
                        catch{}
                        break;
                }
                if (form != null)
                {
                    form.MdiParent = this.MdiParent;
                    form.Show();
                }
    
            }
        }
        

        private void importarExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Importacion de Excel
            ImportacionDocumentoProductos form = new ImportacionDocumentoProductos(this);
            form.MdiParent = this.MdiParent;
            form.Show();
        }

        private void GridProductos_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
    }
}
