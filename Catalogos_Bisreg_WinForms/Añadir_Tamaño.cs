using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catalogos_Bisreg_WinForms
{
    public partial class Añadir_Tamaño : Form
    {
        public Añadir_Tamaño()
        {
            InitializeComponent();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            Tamaño t = new Tamaño();
            t.Nombre = txb_Nombre.Text;
            t.Horizontal_CM = double.Parse(txb_Horizontal.Text);
            t.Vertical_CM = double.Parse(txb_Vertical.Text);
            t.setTamaño();
        }
    }
}
