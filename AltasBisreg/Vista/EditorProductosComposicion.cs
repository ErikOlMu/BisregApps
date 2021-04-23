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

    public partial class EditorProductosComposicion : Form
    {
        private ProdComposicion prodComposicion;

        public EditorProductosComposicion()
        {
            InitializeComponent();
        }

        private void Mostrar()
        {
            tbx_ID.Text = prodComposicion.GetId();
            tbx_Descripcion.Text = prodComposicion.GetDescripcion();
            tbx_Precio.Text = prodComposicion.GetPrecio().ToString();


        }
        private void Guardar()
        {
            prodComposicion = new ProdComposicion(tbx_ID.Text, tbx_Descripcion.Text, Convert.ToDecimal(tbx_Precio.Text));
            prodComposicion.Save();

            MessageBox.Show("Producto de Composicion Guardado");

        }
        private void Limpiar()
        {
            tbx_ID.Text = "";
            tbx_Descripcion.Text = "";
            tbx_Precio.Text = "";
        }
        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            prodComposicion = ProdComposicion.GetProdComposicion(tbx_ID.Text);
            Limpiar();
            if (prodComposicion != null)
            {
                Mostrar();
            }
            else
            {
                MessageBox.Show("Producto de Composicion no encontrado");
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (prodComposicion != null && prodComposicion.Existe())
            {
                prodComposicion.Existe();
            }
            Limpiar();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }
    }
}
