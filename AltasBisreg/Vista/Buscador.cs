using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AltasBisreg.Modelos.Capa3;
namespace AltasBisreg.Vista
{
    public partial class Buscador : Form
    {
        private string tabla;
        DataGridViewCell celda;
        int row;
        int col;
        DataGridView Grid;
        string atributo;
        public Buscador(string tabla,int row,int col,DataGridView Grid)
        {
            this.row = row;
            this.col = col;
            this.Grid = Grid;
            this.tabla = tabla;
            
            InitializeComponent();
            Actualizar();

        }
        public Buscador(string tabla, int row, int col, DataGridView Grid,string atributo)
        {
            this.atributo = atributo;
            this.row = row;
            this.col = col;
            this.Grid = Grid;
            this.tabla = tabla;

            InitializeComponent();
            Actualizar();

        }

        private void Actualizar()
        {
            switch (tabla)
            {
                case "FAMILIA":
                    dataGridView1.DataSource = Controladores.ConnexionSQL.BuscarFamilias(textBox1.Text);
                    break;
                case "LOCALIDAD":
                    dataGridView1.DataSource = Controladores.ConnexionSQL.BuscarLocalidades(textBox1.Text);

                    break;
                case "SECCION":
                    dataGridView1.DataSource = Controladores.ConnexionSQL.BuscarSecciones(textBox1.Text);

                    break;
                case "ATRIBUTO":
                    dataGridView1.DataSource = Controladores.ConnexionSQL.BuscarAtributos(textBox1.Text);
                    break;
                case "RELATRIBUTO":
                    dataGridView1.DataSource = Controladores.ConnexionSQL.BuscarRelAtributos(textBox1.Text,atributo);
                    break;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Grid[col,row].Value = dataGridView1[0, e.RowIndex].Value;
            this.Close();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3)
            {
                e.Handled = true;
            }

        }
    }
}
