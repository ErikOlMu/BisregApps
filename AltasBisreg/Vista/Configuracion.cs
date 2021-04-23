using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AltasBisreg.Modelos.Settings;

namespace AltasBisreg.Vista
{
    public partial class Configuracion : Form
    {
        public Configuracion()
        {
            InitializeComponent();

            txb_pv1.Text = Config.ValorPV1;
            txb_pv2.Text = Config.ValorPV2;
            txb_pv3.Text = Config.ValorPV3;
            txb_pcoste.Text = Config.ValorCoste;
            txb_RutaSql.Text = Config.RutaBaseDatos;
            cbx_Ambito.Text = Config.ValorAmbito;



        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            Config.ValorPV1 = txb_pv1.Text;
            Config.ValorPV2 = txb_pv2.Text;
            Config.ValorPV3 = txb_pv3.Text;
            Config.ValorCoste = txb_pcoste.Text;
            Config.RutaBaseDatos = txb_RutaSql.Text;
            Config.ValorAmbito = cbx_Ambito.Text;
            Config.SaveConfig();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFixero.ShowDialog();
            txb_RutaSql.Text = AbrirFixero.FileName;

        }

        private void btn_CrearBDD_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            Config.RutaBaseDatos = saveFileDialog1.FileName;
            txb_RutaSql.Text = saveFileDialog1.FileName;

            Controladores.ConnexionSQL.Crear(saveFileDialog1.FileName);




        }

        private void cbx_Ambito_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
