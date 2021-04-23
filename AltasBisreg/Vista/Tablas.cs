using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AltasBisreg.Vista
{
    public partial class Tablas : Form
    {
        public Tablas()
        {
            InitializeComponent();
            cbx_Tablas.DataSource = Controladores.ConnexionSQL.GetTables();
        }

        public void LLenarGrid()
        {
            List<List<string>> ListaBDD;

            List<string> l = Controladores.ConnexionSQL.GetColumnas(cbx_Tablas.SelectedItem.ToString());
            GridDatos.Columns.Clear();
            foreach (string columna in l)
            {
                GridDatos.Columns.Add(columna,columna);
            }

            ListaBDD = Controladores.ConnexionSQL.GetValoresTabla(cbx_Tablas.SelectedItem.ToString());

            foreach (List<string> lista in ListaBDD)
            {
                DataGridViewRow fila = new DataGridViewRow();
                foreach (string s in lista)
                {
                    fila.Cells.Add(new DataGridViewTextBoxCell { Value = s });
                }
                GridDatos.Rows.Add(fila);
            }
        }

        private void cbx_Tablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            LLenarGrid();
        }

        private void Tablas_Resize(object sender, EventArgs e)
        {
            GridDatos.Width = this.Width - 40;
            GridDatos.Height = this.Height - 160;

            Point local = cbx_Tablas.Location;
            local.X = this.Width - 149;

            cbx_Tablas.Location = local ;

            local = cbx_Tablas.Location;
            local.X = this.Width - 192;

            label1.Location = local; 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LLenarGrid();
        }

        private void Tablas_Load(object sender, EventArgs e)
        {

        }
    }
}
