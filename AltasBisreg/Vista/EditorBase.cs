using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AltasBisreg.Modelos.Capa1;
using System.Windows.Forms;
using AltasBisreg.Modelos.Capa2;
using AltasBisreg.Modelos.Capa3;

namespace AltasBisreg.Vista
{
    public partial class EditorBase : Form
    {
        private Base @base;
        private string pack;
        public EditorBase(string pack ="GENERAL")
        {
            this.pack = pack;
            InitializeComponent();
            cbx_Tipo.DataSource = Controladores.ConnexionSQL.GetTipos();
        }

        public void PonerValores()
        {
            tbx_ID.Text = @base.GetId();
            cbx_Tipo.Text = @base.GetTipo();
            tbx_Nombre.Text = @base.GetNombre();
            tbx_Familia.Text = @base.GetFamilia();
            tbx_Seccion.Text = @base.GetSeccion();
            tbx_pv1.Text = @base.GetPv1().ToString();
            tbx_pv2.Text = @base.GetPv2().ToString();
            tbx_pv3.Text = @base.GetPv3().ToString();
            tbx_pCoste.Text = @base.GetPcoste().ToString();
            tbx_Atributo.Text = @base.GetAtributo();
            cbx_RelAributo.Text = @base.GetRelAtributo();
            tbx_PedidoMinimo.Text = @base.GetpedidoMinimo().ToString();


            //Tarifas
            ActualizarTarifas();

        }

        public void Limpiar()
        {
            tbx_ID.Text = "";
            cbx_Tipo.Text = "";
            tbx_Nombre.Text = "";
            tbx_Familia.Text = "";
            tbx_Seccion.Text = "";
            tbx_pv1.Text = "";
            tbx_pv2.Text = "";
            tbx_pv3.Text = "";
            tbx_pCoste.Text = "";
            tbx_Atributo.Text = "";
            tbx_PedidoMinimo.Text = "";

            cbx_RelAributo.DataSource = null;
            GridTarifas.DataSource = null;

        }
        public void GuardarValores()
        {
            Base b = new Base(tbx_ID.Text, cbx_Tipo.Text, tbx_Nombre.Text, tbx_Familia.Text, tbx_Seccion.Text, Convert.ToDecimal(tbx_pv1.Text), Convert.ToDecimal(tbx_pv2.Text), Convert.ToDecimal(tbx_pv3.Text),Convert.ToDecimal(tbx_pCoste.Text), tbx_Atributo.Text, cbx_RelAributo.Text, Convert.ToInt32(tbx_PedidoMinimo.Text),pack);
            b.Save();

            MessageBox.Show("Base Guardada");

        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            @base = Base.GetBase(tbx_ID.Text, cbx_Tipo.Text,pack);
            Limpiar();

            if (@base != null)
            {
                PonerValores();
            }
            else
            {
                MessageBox.Show("Referencia no encontrada");

            }
        }


        
 
        private void ActualizarTarifas()
        {
            var ListBinding = new BindingList<Tarifa>(@base.GetTarifas());
            

            GridTarifas.DataSource = ListBinding;
            int Tamaño = 117;
            GridTarifas.Columns[0].Width = Tamaño;
            GridTarifas.Columns[1].Width = Tamaño;
        }
        private void ActualizarRelAtributos()
        {
            Atributo a = Atributo.GetAtributo(tbx_Atributo.Text);

            if (a != null)
            {
                List<string> lista = new List<string>();
                foreach (RelAtributo r in a.GetRelaciones())
                {
                    lista.Add(r.Getid());
                }

                

                cbx_RelAributo.DataSource = lista;
            }
            else
            {
                cbx_RelAributo.DataSource = null;
            }
            
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            Familia f = Familia.GetFamilia(tbx_Familia.Text);
            Modelos.Capa3.Seccion s = Modelos.Capa3.Seccion.GetSeccion(tbx_Seccion.Text);
            Atributo a = Atributo.GetAtributo(tbx_Atributo.Text);
            RelAtributo r = RelAtributo.GetRelAtributo(cbx_RelAributo.Text, tbx_Atributo.Text);

            if (f != null && s !=null && a != null && r != null)
            {
                GuardarValores();

            }
            else
            {
                MessageBox.Show("No existe una o mas de las Referencias");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GridTarifas_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            @base.GetTarifas()[e.Row.Index].Delete();
        }

        private void btn_CrearTarifa_Click(object sender, EventArgs e)
        {
            if (@base != null)
            {
                Tarifa t = new Tarifa(txb_TarifaID.Text, @base.GetId(), @base.GetTipo(), Convert.ToDecimal(txb_TarifaPrecio.Text),@base.Getpack());

                t.Save();
                txb_TarifaID.Text = "";
                txb_TarifaPrecio.Text = "";
                ActualizarTarifas();


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (@base != null && @base.Existe())
            {
                @base.Delete();
            }
            Limpiar();
        }

        private void tbx_Familia_TextChanged(object sender, EventArgs e)
        {
            Familia f = Familia.GetFamilia(tbx_Familia.Text);

            if (f != null)
            {
                try
                {
                    tbx_Mfamilia.Text = f.GetDescripcion();
                }
                catch 
                {
                }
            }
            else
            {
                tbx_Mfamilia.Text = "";
            }
        }

        private void tbx_Seccion_TextChanged(object sender, EventArgs e)
        {
            Modelos.Capa3.Seccion s = Modelos.Capa3.Seccion.GetSeccion(tbx_Seccion.Text);
            if(s != null)
            {
                try
                {
                    tbx_MSeccion.Text = s.GetDescripcion();
                }
                catch
                {
                }
            }
            else
            {
                tbx_MSeccion.Text = "";
            }
        }

        private void tbx_Atributo_TextChanged(object sender, EventArgs e)
        {
            Atributo a = Atributo.GetAtributo(tbx_Atributo.Text);

            if (a != null)
            {
                try
                {
                    ActualizarRelAtributos();
                    tbx_MAtributo.Text = a.Getdescripcion();
                }
                catch
                {
                }
                
            }
            else
            {
                cbx_RelAributo.DataSource = null;
                tbx_MAtributo.Text = "";

            }


        }

        private void tbx_RelAributo_TextChanged(object sender, EventArgs e)
        {
            RelAtributo r = RelAtributo.GetRelAtributo(cbx_RelAributo.Text, tbx_Atributo.Text);

            if (r != null)
            {
                tbx_MRelatributos.Text = r.GetNombre();
            }
            else
            {
                tbx_MRelatributos.Text = "";
            }
        }
    }
}
