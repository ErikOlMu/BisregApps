using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AltasBisreg.Modelos.Capa1;
using AltasBisreg.Modelos.Capa2;
using System.Windows.Forms;
using AltasBisreg.Modelos.Settings;
using System.Threading;
using System.Reflection;

namespace AltasBisreg.Vista
{
    public partial class EditorDocument : Form
    {
        private Documento d = new Documento();
        public EditorDocument()
        {
            InitializeComponent();
            
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            GridDocumento, new object[] { true });
            
            cbx_Tipo.DataSource = Controladores.ConnexionSQL.GetTipos();
            chlbx_PackDiseños.DataSource = Diseño.GetPacks();
            chlbx_PackDiseños.Text = "GENERAL";

            Actualizar();
        }
        

        private void Actualizar()
        {
            //Actualizar
            GridDocumento.DataSource = null;
            GridDocumento.DataSource = new BindingList<Item>(d.GetListItems());
            GridDocumento.Columns[1].Width = 300;

            ActualizarNombres();

        }
        private void exportarAExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new Controladores.ConnexionExcel(d,Config.GetFile());
        }

        //resize del Grid
        private void Editor_de_Document_Resize(object sender, EventArgs e)
        {
            GridDocumento.Width = this.Width - 40;
            GridDocumento.Height = this.Height - 300;
        }

        private void GridDocumento_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            //SI NO HAY NINGUN NULL EN EL ULTIMO
            if (!d.GetListItems()[e.RowIndex].Algunnull())
            {
                Actualizar();
            }
        }

        private void GridDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void btn_Añadir_Click(object sender, EventArgs e)
        {
            foreach (string Pueblo in lbx_Pueblos.Items)
            {
                foreach (string Diseño in lbx_Diseños.Items)
                {
                    string Letra = "";

                    if (tbx_Base.Text.Length == 3 && Diseño.Length == 2)
                    {
                        Letra = "B";
                    }
                    if (tbx_Base.Text.Length == 2 && Diseño.Length == 3)
                    {
                        Letra = "D";
                    }
                    Item i = new Item(cbx_Tipo.Text + Pueblo + tbx_Base.Text + Diseño + Letra);
                    d.addItem(i);
                }
            }
            Actualizar();

        }

        private void tbx_Pueblo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Pueblo.GetPueblo(tbx_Pueblo.Text) != null){
                    lbx_Pueblos.Items.Add(tbx_Pueblo.Text);
                    tbx_Pueblo.Text = "";
                }
                else
                {
                    if (MessageBox.Show("Quieres crearlo?", "No existe el Pueblo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                            EditorPueblos form = new EditorPueblos();

                            form.MdiParent = this.MdiParent;

                            form.Show();
                    }
                }
            }
        }

        private void tbx_Diseño_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Modelos.Capa2.Diseño.GetDiseño(tbx_Diseño.Text) != null)
                {

                    lbx_Diseños.Items.Add(tbx_Diseño.Text);
                    tbx_Diseño.Text = "";
                }
                else
                {
                    if(MessageBox.Show("Quieres crearlo?", "No existe el Diseño", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        EditorDiseño form = new EditorDiseño();

                        form.MdiParent = this.MdiParent;

                        form.Show();
                    }
                }
            }
        }

        private void lbx_Pueblos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                lbx_Pueblos.Items.RemoveAt(lbx_Pueblos.SelectedIndex);
            }
    }

        private void lbx_Diseños_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                lbx_Diseños.Items.RemoveAt(lbx_Diseños.SelectedIndex);
            }
        }

        private void alertasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorAlertas form = new EditorAlertas();

            form.MdiParent = this.MdiParent;

            form.Show();
        }

        private void diseñosTemporalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorPackDiseños form = new EditorPackDiseños();
            
            form.MdiParent = this.MdiParent;

            form.Show();
        }

        private void ActualizarNombres()
        {
            //Actualizar Nombres

            d.RecalcularDiseños(chlbx_PackDiseños.Text);
            
        }

        private void chlbx_PackDiseños_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chlbx_PackDiseños_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Actualizar();
            ActualizarAlta();
        }

        private void ActualizarAlta()
        {
            foreach (Item i in d.GetListItems())
            {
                i.recalular();
            }
        }

        private void chlbx_PackDiseños_SelectedValueChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void importacionExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();


            string rutaexcel = openFileDialog1.FileName;




            try
            {
                List<List<string>> listaexcel = Controladores.ConnexionExcel.GetExcel(rutaexcel);


                if (listaexcel.Count == 0)
                {
                    MessageBox.Show("Excel Vacio", "Fallo de importacion");
                }
                else
                {
                    d.addItem(new Item());
                    foreach (List<string> lista in listaexcel)
                    {
                        d.addItem(new Item(lista[0]));
                    }
                }

            }
            catch
            {
                MessageBox.Show("Error Importando Excel");
            }

            Actualizar();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            chlbx_PackDiseños.DataSource = Diseño.GetPacks();
            chlbx_PackDiseños.Text = "GENERAL";


        }

        
    }
}
