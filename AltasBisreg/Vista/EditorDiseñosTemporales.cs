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
using System.IO;

namespace AltasBisreg.Vista
{
    public partial class EditorPackDiseños : Form
    {
        public EditorPackDiseños()
        {

            InitializeComponent();
            Actualizar();
        }
        public void Actualizar()
        {
            ImageList listaimagenes = new ImageList();

            listaimagenes.ImageSize = new Size(98, 96);
            listViewDiseños.Items.Clear();
            listViewDiseños.LargeImageList = listaimagenes;
            listViewDiseños.LargeImageList.Images.Add("DiseñoFolder", Bitmap.FromFile(Directory.GetCurrentDirectory()+"\\folderdiseños.png"));

            foreach (string pack in Diseño.GetPacks())
            {
                if (pack != "GENERAL")
                {
                    ListViewItem item = new ListViewItem(pack, "DiseñoFolder");

                    listViewDiseños.Items.Add(item);
                }

            }
        }

        private void MostrarEditor(string pack)
        {
            EditorDiseño form = new EditorDiseño(pack);
            form.MdiParent = this.MdiParent;

            form.Show();

        }

        private void listViewDiseños_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            string texto = listViewDiseños.SelectedItems[0].Text;

            MostrarEditor(texto);


        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void mostarListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewDiseños.SelectedItems.Count != 0)
            {
                string texto = listViewDiseños.SelectedItems[0].Text;
                Listado form = new Listado(Diseño.GetDiseños(texto));
                form.MdiParent = this.MdiParent;

                form.Show();
            }

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewDiseños.SelectedItems.Count != 0)
            {
                string texto = listViewDiseños.SelectedItems[0].Text;
                MostrarEditor(texto);

            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewDiseños.SelectedItems.Count != 0)
            {
                if (MessageBox.Show(" Se eliminaran Todos los diseños del Pack", "¿Estas Seguro?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string texto = listViewDiseños.SelectedItems[0].Text;

                    foreach (Diseño d in Diseño.GetDiseños(texto))
                    {
                        d.Delete();
                    }
                    Actualizar();
                }



            }
        }

        private void listViewDiseños_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDiseños.SelectedItems.Count != 0)
            {
                listViewDiseños.ContextMenuStrip = contextMenuStrip1;
            }
            else
            {
                listViewDiseños.ContextMenuStrip = contextMenuStrip2;

            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevoPack form = new NuevoPack(this);
            form.MdiParent = this.MdiParent;
            form.Show();
            
        }
    }
}