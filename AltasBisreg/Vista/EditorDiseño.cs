using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AltasBisreg.Modelos.Capa2;
namespace AltasBisreg.Vista
{
    public partial class EditorDiseño : Form
    {
        private Diseño diseño;
        private string pack;
        public EditorDiseño( string pack ="GENERAL")
        {
            this.pack = pack;
            InitializeComponent();
        }

        private void Mostrardiseño()
        {
            txb_ID.Text = diseño.GetID();
            txb_Descripcion.Text = diseño.GetDescripcion();
        }

        private void Guardardiseño()
        {
            diseño = new Diseño(txb_ID.Text,txb_Descripcion.Text,pack);
            diseño.Save();

            MessageBox.Show("Diseño Guardado");

        }
        private void Limpiar()
        {
            txb_ID.Text = "";
            txb_Descripcion.Text = "";
        }
        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            diseño = Diseño.GetDiseño(txb_ID.Text,pack);
            Limpiar();

            if (diseño != null)
            {
                Mostrardiseño();
            }
            else
            {
                MessageBox.Show("Diseño no encontrado");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Guardardiseño();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (diseño != null && diseño.Existe())
            {
                diseño.Delete();
            }
            Limpiar();
        }
    }
}
