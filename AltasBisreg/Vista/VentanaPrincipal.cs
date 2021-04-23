using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AltasBisreg.Modelos.Capa1;

namespace AltasBisreg.Vista
{
    public partial class VentanaPrincipal : Form
    {
        public VentanaPrincipal()
        {

            InitializeComponent();
            
        }


        private void VentanaPrincipal_Load(object sender, EventArgs e)
        {
            SQLiteConnection p = Controladores.ConnexionSQL.GetInstance();
            p.Close();
            p = null;

            

        }



        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void nuevoDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorDocument form = new EditorDocument();

            form.MdiParent = this;

            form.Show();
        }
        private void tablasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tablas form = new Tablas();

            form.MdiParent = this;

            form.Show();

        }

        private void importacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Importacion form = new Importacion();

            form.MdiParent = this;

            form.Show();
        }
        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuracion form = new Configuracion();

            form.MdiParent = this;

            form.Show();
        }
        private void basesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorBase form = new EditorBase();

            form.MdiParent = this;

            form.Show();
        }

        private void pueblosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorPueblos form = new EditorPueblos();

            form.MdiParent = this;

            form.Show();
        }

        private void diseñosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorDiseño form = new EditorDiseño();

            form.MdiParent = this;

            form.Show();
        }

        private void atributosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorAtributos form = new EditorAtributos();

            form.MdiParent = this;

            form.Show();
        }
        private void familiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorFamilias form = new EditorFamilias();

            form.MdiParent = this;

            form.Show();
        }
        private void localidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorLocalidad form = new EditorLocalidad();

            form.MdiParent = this;

            form.Show();
        }

        private void seccionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorSeccion form = new EditorSeccion();

            form.MdiParent = this;

            form.Show();
        }

        private void MenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void productosDeComposicionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorProductosComposicion form = new EditorProductosComposicion();

            form.MdiParent = this;

            form.Show();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorDocumentoProductos form = new EditorDocumentoProductos();

            form.MdiParent = this;

            form.Show();
        }
    }
}
