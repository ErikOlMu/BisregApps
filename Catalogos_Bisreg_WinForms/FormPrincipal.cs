using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Catalogos_Bisreg_WinForms
{
    public partial class FormPrincipal : Form
    {
        public ArrayList Productos = new ArrayList();

        public FormPrincipal()

        {
            InitializeComponent();

            if (!Directory.Exists("Tamaños"))
            {
                Directory.CreateDirectory("Tamaños");
            }
            if (!Directory.Exists("temp"))
            {
                Directory.CreateDirectory("temp");
            }
            
            txb_DirIMG.Text = Settings.Directorio_IMG;
        }


        //Importar datos de Varios Excels
        public void ImportarData()
        {
            TablaProductos.Columns.Clear();
            //Columna numeros
            TablaProductos.Columns.Add("Nº", "Nº");

            //Primera Columna
            TablaProductos.Columns.Add("Referencia", "Referencia");
            foreach (string columna in ListaDeCampos.Items)
            {
                TablaProductos.Columns.Add(columna, columna);
            }


            int contador = 0;

            foreach (Item i in Productos)
            {
                //Creamos la fila
                DataGridViewRow Columna = new DataGridViewRow();
                //Añadimos la Referencia
                if ( File.Exists(Settings.Directorio_IMG+"\\"+i.Referencia+".jpg") || File.Exists(Settings.Directorio_IMG + "\\" + i.Referencia + ".png") || File.Exists(Settings.Directorio_IMG + "\\" + i.Referencia + "_0.jpg") || File.Exists(Settings.Directorio_IMG + "\\" + i.Referencia + "_0.png"))
                {

                    Columna.DefaultCellStyle.BackColor = Color.Green;

                }
                else
                {
                    Columna.DefaultCellStyle.BackColor = Color.Red;
                }
                Columna.Cells.Add(new DataGridViewTextBoxCell { Value = contador.ToString() });
                Columna.Cells.Add(new DataGridViewTextBoxCell { Value = i.Referencia });

                //Añadimos todos los Valores
                foreach (string valor in i.Valores) {

                    Columna.Cells.Add(new DataGridViewTextBoxCell { Value = valor });
                }


                //Añado la columna acabada
                TablaProductos.Rows.Add(Columna);

                contador = contador + 1;

            }
            //Cancelar ordernacion
            foreach (DataGridViewColumn Col in TablaProductos.Columns)
            {
                Col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }

        //Añadir Campo a Lista de Campos
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //Añadir Campo a la Lista

            if (e.KeyCode == Keys.Enter && textBox1.Text != "")
            {
                
                ListaDeCampos.Items.Add(textBox1.Text);
                textBox1.Clear();
            }
        }
        //Eliminar Campos de la Lista
        private void ListaDeCampos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                //Miro si hay cosas seleccionadas
                if (ListaDeCampos.SelectedIndex != -1)
                {
                    //Eliminar el campo seleccionado cuando pressiones Supr
                    
                    ListaDeCampos.Items.RemoveAt(ListaDeCampos.SelectedIndex);

                }
            }
        }


        //Boton Importar excel
        private void btn_Importar_Excel_Click(object sender, EventArgs e)
        {
            ArrayList Campos = new ArrayList();
            foreach (string valor in ListaDeCampos.Items)
            {
                Campos.Add(valor);

            }
            Productos = ImportExcel.getReferenciasExcel(ImportExcel.ListFiles(),Campos);
            ImportarData();
        }

        private void Button_Export_PDF_Click(object sender, EventArgs e)
        {

            ArrayList Campos = new ArrayList();

            //Añado la Imagen (Campo inborrable)
            Campos.Add(new CampoPB("Imagen"));
            ((CampoPB)Campos[0]).Tamaño = Settings.TamañoImagen;
            ((CampoPB)Campos[0]).X = Settings.XImagen;
            ((CampoPB)Campos[0]).Y = Settings.YImagen;
            ((CampoPB)Campos[0]).Rotacion = Settings.RotacionImagen;

            //Añado la referencia
            Campos.Add(new CampoPB("Referencia"));
            ((CampoPB)Campos[1]).X = Settings.XReferencia;
            ((CampoPB)Campos[1]).Y = Settings.YReferencia;
            ((CampoPB)Campos[1]).Rotacion = Settings.RotacionReferencia;
            ((CampoPB)Campos[1]).Tamaño = Settings.TamañoReferencia;


            //Añado el Barcode
            Campos.Add(new CampoPB("Barcode"));
            ((CampoPB)Campos[2]).X = Settings.XBarcode;
            ((CampoPB)Campos[2]).Y = Settings.YBarcode;
            ((CampoPB)Campos[2]).Rotacion = Settings.RotacionBarcode;
            ((CampoPB)Campos[2]).Tamaño = Settings.TamañoBarcode;

            //Añado todos los Items
            foreach (string campo in ListaDeCampos.Items)
            {
               
                Campos.Add(new CampoPB(campo));
            }

            FormPDF frm = new FormPDF(Campos,Productos);
            frm.Show();
        }

        private void txb_DirIMG_TextChanged(object sender, EventArgs e)
        {
            try
            {

                Settings.Directorio_IMG = txb_DirIMG.Text;
                Settings.setSettings();
            }
            catch (Exception ex)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txb_DirIMG.Text = ImportExcel.GetDirectory();

        }

        private void TablaProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DataGridView Tabla = (DataGridView)sender;

                Productos.RemoveAt(Tabla.CurrentRow.Index);

                Tabla.Rows.RemoveAt(Tabla.CurrentRow.Index);
            }
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
