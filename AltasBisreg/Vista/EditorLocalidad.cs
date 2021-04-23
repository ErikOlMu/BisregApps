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
    public partial class EditorLocalidad : Form
    {
        private Localidad localidad;
        public EditorLocalidad()
        {
            InitializeComponent();
        }

        private void Mostrar()
        {
            tbx_ID.Text = localidad.GetID();
            tbx_Descripcion.Text = localidad.GetNombre();


        }
        private void Guardar()
        {
            localidad = new Localidad(tbx_ID.Text, tbx_Descripcion.Text);
            localidad.Save();

            MessageBox.Show("Localidad Guardada");

        }
        private void Limpiar()
        {
            tbx_ID.Text = "";
            tbx_Descripcion.Text = "";
        }
        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            localidad = Localidad.GetLocalidad(tbx_ID.Text);
            Limpiar();
            if (localidad != null)
            {
                Mostrar();
            }
            else
            {
                MessageBox.Show("Localidad no encontrada");
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (localidad != null && localidad.Existe())
            {
                localidad.Delete();
            }
            Limpiar();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }
    }
}
