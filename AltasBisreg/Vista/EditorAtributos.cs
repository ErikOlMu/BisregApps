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
    public partial class EditorAtributos : Form
    {
        private Atributo atributo;
        public EditorAtributos()
        {
            InitializeComponent();
        }
        private void ActualizarRelaciones()
        {
            if (atributo != null && atributo.Existe())
            {
                var ListBinding = new BindingList<RelAtributo>(atributo.GetRelaciones());
                GridRelaciones.DataSource = ListBinding;
                GridRelaciones.Columns[0].Width = 65;
                GridRelaciones.Columns[1].Width = 175;


            }
        }
        private void Mostrar()
        {
            tbx_ID.Text = atributo.Getid();
            tbx_Descripcion.Text = atributo.Getdescripcion();
            ActualizarRelaciones();

        }
        private void Guardar()
        {
            atributo = new Atributo(tbx_ID.Text, tbx_Descripcion.Text);
            atributo.Save();

            MessageBox.Show("Atributo Guardado");
        }
        private void Limpiar()
        {
            tbx_ID.Text = "";
            tbx_Descripcion.Text = "";
        }
        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            atributo = Atributo.GetAtributo(tbx_ID.Text);
            Limpiar();
            if (atributo != null)
            {
                Mostrar();
            }
            else
            {
                MessageBox.Show("Atributo no encontrado");
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (atributo != null && atributo.Existe())
            {
                atributo.Delete();
            }
            Limpiar();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void btn_CrearRel_Click(object sender, EventArgs e)
        {
            if (atributo != null)
            {
                RelAtributo r = new RelAtributo(tbx_RId.Text, tbx_ID.Text, tbx_RDescripcion.Text);
                r.Save();

                tbx_RId.Text = "";
                tbx_RDescripcion.Text = "";

                ActualizarRelaciones();
            }
        }

        private void GridRelaciones_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            atributo.GetRelaciones()[e.Row.Index].Delete();

        }
    }
}
