using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AltasBisreg.Modelos.Settings;

namespace AltasBisreg.Vista
{
    public partial class EditorAlertas : Form
    {
        List<Alerta> lista;
        public EditorAlertas()
        {
            InitializeComponent();
        }

        private void EditorAlertas_Load(object sender, EventArgs e)
        {
            Actualizar();
        }
        private void Actualizar()
        {
            Controladores.SerlizadorAlertas s = new Controladores.SerlizadorAlertas();
            s.GetAlertas();
            lista = s.alertas;
            GridAlertas.DataSource = null;
            GridAlertas.DataSource = new BindingList<Alerta>(lista);
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Controladores.SerlizadorAlertas s = new Controladores.SerlizadorAlertas();
            s.alertas = lista;
            s.Save();
            Actualizar();
        }
    }
}
