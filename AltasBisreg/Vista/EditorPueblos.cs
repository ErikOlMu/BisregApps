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
    public partial class EditorPueblos : Form
    {
        private Pueblo pueblo;
        public EditorPueblos()
        {
            InitializeComponent();

            ListaLocalidades.DataSource = MostarLocalidades();
        }

        


        private void Mostrar()
        {
            tbx_ID.Text = pueblo.GetID();
            tbx_Nombre.Text = pueblo.GetNombre();
            tbx_Localidad.Text = pueblo.GetLocalidad();
            ListaLocalidades.DataSource = MostarLocalidades();


        }

        private List<string> MostarLocalidades()
        {
            List <string> lista =  new List<string>();

            List<List<string>> tabla = Controladores.ConnexionSQL.GetValoresTabla("LOCALIDAD");

            foreach (List<string> l in tabla)
            {
                lista.Add( l[0] + " - " + l[1] );                
            }

            return lista;


        }

        private void Guardar()
        {
            pueblo = new Pueblo(tbx_ID.Text, tbx_Nombre.Text, tbx_Localidad.Text);

            pueblo.Save();

            MessageBox.Show("Pueblo Guardado");

        }
        private void Limpiar()
        {
            tbx_ID.Text = "";
            tbx_Nombre.Text = "";
            tbx_Localidad.Text = "";
        }
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (pueblo != null && pueblo.Existe())
            {
                pueblo.Delete();
            }
            Limpiar();
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            pueblo = Pueblo.GetPueblo(tbx_ID.Text);
            Limpiar();
            if (pueblo != null)
            {
                Mostrar();
            }
            else
            {
                MessageBox.Show("Pueblo no encontrado");
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            Modelos.Capa3.Localidad l = Modelos.Capa3.Localidad.GetLocalidad(tbx_Localidad.Text);

            if (l != null)
            {
                Guardar();
            }
            else
            {
                MessageBox.Show("Localidad no encontrada");
            }

        }

        private void tbx_Localidad_TextChanged(object sender, EventArgs e)
        {
            Modelos.Capa3.Localidad l = Modelos.Capa3.Localidad.GetLocalidad(tbx_Localidad.Text);

            if (l != null)
            {
                txb_NombreLocalidad.Text = l.GetNombre();

            }
            else
            {
                txb_NombreLocalidad.Text = "";

            }
        }

        private void ListaLocalidades_SelectedIndexChanged(object sender, EventArgs e)
        {

            tbx_Localidad.Text = Controladores.ConnexionSQL.GetValoresTabla("LOCALIDAD")[ListaLocalidades.SelectedIndex][0];


        }

        private void packsBasesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pueblo != null)
            {
                Listado form = new Listado(Base.GetBases(pueblo.GetID()));
                form.MdiParent = this.MdiParent;
                form.Show();
            }
            
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pueblo != null && pueblo.Existe())
            {
                EditorBase form = new EditorBase(pueblo.GetID());
                form.MdiParent = this.MdiParent;
                form.Show();
            }
        }
    }
}
