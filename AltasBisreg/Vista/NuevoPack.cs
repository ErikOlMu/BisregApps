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
    public partial class NuevoPack : Form
    {
        private EditorPackDiseños padre;
        public NuevoPack(EditorPackDiseños padre)
        {
            this.padre = padre;
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (tbxNombre.Text != null && tbxNombre.Text != "" && tbxNombre.Text != " ")
            {
                new Diseño("", "", tbxNombre.Text).Save();
                this.Close();
                padre.Actualizar();
            }
        }

        private void tbxNombre_TextChanged(object sender, EventArgs e)
        {
        }

        private void tbxNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCrear_Click(sender, e);

            }

        }
    }
}
