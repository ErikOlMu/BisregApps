using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AltasBisreg.Modelos.Capa1;
using AltasBisreg.Modelos.Capa2;
using AltasBisreg.Modelos.Capa3;


namespace AltasBisreg.Vista
{
    public partial class ImportacionDocumentoProductos : Form
    {
        private EditorDocumentoProductos VentanaImportacion;
        public int contadorcolumnas = 1;
        public ImportacionDocumentoProductos(EditorDocumentoProductos VentanaImportacion)
        {
            this.VentanaImportacion = VentanaImportacion;
            InitializeComponent();
            MostrarColumnas();
        }

        private void MostrarColumnas()
        {
            GridColumnas.Rows.Clear();

            int contador = 1;
            foreach (DataGridViewColumn columna in VentanaImportacion.GridProductos.Columns)
            {
                GridColumnas.Rows.Add(columna.HeaderText, contador.ToString());
                contador = contador + 1;
            }

        }




        private void btn_ImportarExcel_Click(object sender, EventArgs e)
        {

            openFileDialog1.ShowDialog();


            string rutaexcel = openFileDialog1.FileName;



            GridExcel.Columns.Clear();
            GridExcel.Rows.Clear();
            try
            {
                List<List<string>> listaexcel = Controladores.ConnexionExcel.GetExcel(rutaexcel);

            
            if (listaexcel.Count == 0)
            {
                MessageBox.Show("Excel Vacio", "Fallo de importacion");
            }
            else
            {
                //Columnas
                for(int i = 1; i <= listaexcel[0].Count();i++)
                {
                    GridExcel.Columns.Add(i.ToString(), i.ToString());
                    contadorcolumnas = i+1;


                }
                    foreach (List<string> lista in listaexcel)
                {
                    DataGridViewRow fila = new DataGridViewRow();
                    foreach (string s in lista)
                    {
                        fila.Cells.Add(new DataGridViewTextBoxCell {Value = s });
                    }
                    GridExcel.Rows.Add(fila);
                }
            }

            }
            catch
            {
                MessageBox.Show("Error Importando Excel");
            }
        }

        private void btn_ImportarDatos_Click(object sender, EventArgs e)
        {

            int CREFERENCIA = GetColumna(0);
            int CDESCRIPCION = GetColumna(1);
            int CFAMILIA = GetColumna(2);
            int CLOCALIDAD = GetColumna(3);
            int CSECCION = GetColumna(4);
            int CTARIFA_1 = GetColumna(5);
            int CTARIFA_2 = GetColumna(6);
            int CTARIFA_3 = GetColumna(7);
            int CTARIFA_COSTE = GetColumna(8);
            int CATRIBUTO = GetColumna(9);
            int CRELACION_ATRIBUTO = GetColumna(10);
            int CPEDIDO_MINIMO = GetColumna(11);

            foreach (DataGridViewRow r in GridExcel.Rows)
            {
                DocumentoProducto producto = new DocumentoProducto();

                //Referencia
                try { producto.REFERENCIA = r.Cells[CREFERENCIA].Value.ToString(); }
                catch (Exception ex) { producto.REFERENCIA = ""; }

                //Descripcion
                try { producto.DESCRIPCION = r.Cells[CDESCRIPCION].Value.ToString(); }
                catch(Exception ex) { producto.DESCRIPCION = ""; }
                
                //Familia
                try { producto.FAMILIA = r.Cells[CFAMILIA].Value.ToString(); }
                catch (Exception ex) { producto.FAMILIA = ""; }
                
                //Localidad
                try { producto.LOCALIDAD = r.Cells[CLOCALIDAD].Value.ToString(); }
                catch (Exception ex) { producto.LOCALIDAD = ""; }
                
                //Seccion
                try { producto.SECCION = r.Cells[CSECCION].Value.ToString(); }
                catch (Exception ex) { producto.SECCION = ""; }
                
                //Tarifa 1
                try { producto.TARIFA_1 = r.Cells[CTARIFA_1].Value.ToString(); }
                catch (Exception ex) { producto.TARIFA_1 = ""; }

                //Tarifa 2
                try { producto.TARIFA_2 = r.Cells[CTARIFA_2].Value.ToString(); }
                catch (Exception ex) { producto.TARIFA_2 = ""; }

                //Tarifa 3
                try { producto.TARIFA_3 = r.Cells[CTARIFA_3].Value.ToString(); }
                catch (Exception ex) { producto.TARIFA_3 = ""; }

                //Tarifa Coste
                try { producto.TARIFA_COSTE = r.Cells[CTARIFA_COSTE].Value.ToString(); }
                catch (Exception ex) { producto.TARIFA_COSTE = ""; }

                //Atributo
                try { producto.ATRIBUTO = r.Cells[CATRIBUTO].Value.ToString(); }
                catch (Exception ex) { producto.ATRIBUTO = ""; }

                //Relacion Atributo
                try { producto.RELACION_ATRIBUTO = r.Cells[CRELACION_ATRIBUTO].Value.ToString(); }
                catch (Exception ex) { producto.RELACION_ATRIBUTO = ""; }

                //Pedido Minimo
                try { producto.PEDIDO_MINIMO = r.Cells[CPEDIDO_MINIMO].Value.ToString(); }
                catch (Exception ex) { producto.PEDIDO_MINIMO = ""; }
               

                VentanaImportacion.productos.Add(producto);
            }
            VentanaImportacion.GridProductos.DataSource = new BindingList<DocumentoProducto>(VentanaImportacion.productos);
        }


        //La columna que ira a la columna del sql
        public int GetColumna(int row)
        {
            return Convert.ToInt32(GridColumnas.Rows[row].Cells[1].Value)-1;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            GridExcel.Columns.Add(contadorcolumnas.ToString(), contadorcolumnas.ToString());
            contadorcolumnas = contadorcolumnas + 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GridExcel.Columns.Clear();
            contadorcolumnas = 1;
        }
    }
}
