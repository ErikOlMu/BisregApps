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
    public partial class EditorSeccion : Form
    {

        private Seccion seccion;

        public EditorSeccion()
        {
            InitializeComponent();
        }
        private void Mostrar()
        {
            tbx_ID.Text = seccion.GetID();
            tbx_Descripcion.Text = seccion.GetDescripcion();
            tbx_Ubicacion.Text = seccion.GetUbicacion();


        }
        private void Guardar()
        {
            seccion = new Seccion(tbx_ID.Text, tbx_Descripcion.Text,tbx_Ubicacion.Text);
            seccion.Save();

            MessageBox.Show("Seccion Guardada");

        }
        private void Limpiar()
        {
            tbx_ID.Text = "";
            tbx_Descripcion.Text = "";
            tbx_Ubicacion.Text = "";
        }
        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            seccion = Seccion.GetSeccion(tbx_ID.Text);
            Limpiar();
            if(seccion != null)
            {
                Mostrar();
            }
            else
            {
                MessageBox.Show("Seccion no encontrada");
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (seccion != null && seccion.Existe())
            {
                seccion.Existe();
            }
            Limpiar();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }
    }
}
