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
    public partial class EditorFamilias : Form
    {
        private Familia familia;
        public EditorFamilias()
        {
            InitializeComponent();
        }
        private void Mostrar()
        {
            tbx_ID.Text = familia.GetID();
            tbx_Descripcion.Text = familia.GetDescripcion();


        }
        private void Guardar()
        {
            familia = new Familia(tbx_ID.Text, tbx_Descripcion.Text);
            familia.Save();

            MessageBox.Show("Familia Guardada");

        }
        private void Limpiar()
        {
            tbx_ID.Text = "";
            tbx_Descripcion.Text = "";
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            familia = Familia.GetFamilia(tbx_ID.Text);
            Limpiar();
            if (familia != null)
            {
                Mostrar();
            }
            else
            {
                MessageBox.Show("Familia no encontrada");
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (familia != null && familia.Existe())
            {
                familia.Delete();
            }
            Limpiar();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }
    }
}
