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
    public partial class Importacion : Form
    {
        public int contadorcolumnas = 1;
        public Importacion()
        {
            
            InitializeComponent();
            cbx_Tablas.DataSource = Controladores.ConnexionSQL.GetTables();
            
        }

        private void ActualizarColumnas()
        {
            List<string> l = Controladores.ConnexionSQL.GetColumnas(cbx_Tablas.SelectedItem.ToString());
            GridColumnas.Rows.Clear();
            int contador = 1;
            foreach (string columna in l)
            {
                GridColumnas.Rows.Add(columna,contador.ToString());
                contador = contador + 1;
            }

        }

        private void cbx_Tablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarColumnas();
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

            try
            {
               switch (cbx_Tablas.SelectedItem.ToString())
                {
                case "ATRIBUTO":
                    ImportAtributos();
                    break;
                case "BASE":
                    ImportBase();
                    break;
                case "COMPOSICION":
                    ImportComposicion();
                    break;
                case "DISEÑO":
                    ImportDiseño();
                    break;
                case "FAMILIA":
                    ImportFamilia();
                    break;
                case "LOCALIDAD":
                    ImportLocalidad();
                    break;
                case "PROD_COMPOSICION":
                    ImportProdComposicion();
                    break;
                case "PUEBLO":
                    ImportPueblo();
                    break;
                case "REL_ATRIBUTO":
                    ImportRelAtributo();
                    break;
                case "SECCION":
                    ImportSeccion();
                    break;
                case "TARIFA":
                        ImportTarifa();
                        break;
                }
                MessageBox.Show("Importado con Exito");
            }
            catch
            {
                MessageBox.Show("Fallo la Importacion de Datos");
            }
        }


        //La columna que ira a la columna del sql
        public int GetColumna(int row)
        {
            return Convert.ToInt32(GridColumnas.Rows[row].Cells[1].Value)-1;
        }

        public void ImportAtributos()
        {
            Atributo a;

            int Cid = GetColumna(0);
            int Cdescripcion = GetColumna(1);

            for(int i = 0; i < GridExcel.Rows.Count-1;i++)
            {
                a = new Atributo(
                    //ID
                    GridExcel.Rows[i].Cells[Cid].Value.ToString() ,
                    //Descripcion
                    GridExcel.Rows[i].Cells[Cdescripcion].Value.ToString());
                a.Save();
            }

        }
        public void ImportBase()
        {
            Base b;

            int CPack = GetColumna(0);
            int Cid = GetColumna(1);
            int Ctipo = GetColumna(2);
            int Cdescripcion = GetColumna(3);
            int CFamilia = GetColumna(4);
            int CSeccion = GetColumna(5);
            int CPv1 = GetColumna(6);
            int CPv2 = GetColumna(7);
            int CPv3 = GetColumna(8);
            int CPcoste = GetColumna(9);

            int CAtributo = GetColumna(10);
            int CValorAtributo = GetColumna(11);
            int CPedidoMinimo = GetColumna(12);

            for (int i = 0; i < GridExcel.Rows.Count - 1; i++)
            {
                b = new Base(
                    //ID
                    GridExcel.Rows[i].Cells[Cid].Value.ToString(),
                    //TIPO
                    GridExcel.Rows[i].Cells[Ctipo].Value.ToString(),
                    //Descripcion
                    GridExcel.Rows[i].Cells[Cdescripcion].Value.ToString(),
                    //Familia
                    GridExcel.Rows[i].Cells[CFamilia].Value.ToString(),
                    //Seccion
                    GridExcel.Rows[i].Cells[CSeccion].Value.ToString(),
                    //PV1
                    Convert.ToDecimal(GridExcel.Rows[i].Cells[CPv1].Value),
                    //PV2
                    Convert.ToDecimal(GridExcel.Rows[i].Cells[CPv2].Value),
                    //PV3
                    Convert.ToDecimal(GridExcel.Rows[i].Cells[CPv3].Value),
                    //PCOSTE
                    Convert.ToDecimal(GridExcel.Rows[i].Cells[CPcoste].Value),
                    //Atributo
                    GridExcel.Rows[i].Cells[CAtributo].Value.ToString(),
                    //Valor Atributo
                    GridExcel.Rows[i].Cells[CValorAtributo].Value.ToString(),
                    //Pedido Minimo
                    Convert.ToInt32(GridExcel.Rows[i].Cells[CPedidoMinimo].Value),
                    //PACK
                    GridExcel.Rows[i].Cells[CPack].Value.ToString()
                    );
                b.Save();
            }
        }
        public void ImportComposicion()
        {
            Composicion c;

            int Cid = GetColumna(0);
            int CBase = GetColumna(1);
            int Ctipo = GetColumna(2);
            int Ccantidad = GetColumna(3);


            for (int i = 0; i < GridExcel.Rows.Count - 1; i++)
            {
                c = new Composicion(
                    //ID
                    GridExcel.Rows[i].Cells[Cid].Value.ToString(),
                    //Base
                    GridExcel.Rows[i].Cells[CBase].Value.ToString(),
                    //Tipo
                    GridExcel.Rows[i].Cells[Ctipo].Value.ToString(),
                    //Cantidad
                    Convert.ToDecimal(GridExcel.Rows[i].Cells[Ccantidad].Value.ToString())
                    );
                c.Save();
            }
        }
        public void ImportDiseño()
        {
            Diseño d;

            int CPack = GetColumna(0);
            int Cid = GetColumna(1);
            int Cdescripcion = GetColumna(2);


            for (int i = 0; i < GridExcel.Rows.Count - 1; i++)
            {
                d = new Diseño(
                    //ID
                    GridExcel.Rows[i].Cells[Cid].Value.ToString(),
                    //Descripcion
                    GridExcel.Rows[i].Cells[Cdescripcion].Value.ToString(),
                    GridExcel.Rows[i].Cells[CPack].Value.ToString()
                    );
                d.Save();
            }
        }
        public void ImportFamilia()
        {
            Familia f;

            int Cid = GetColumna(0);
            int Cdescripcion = GetColumna(1);

            for (int i = 0; i < GridExcel.Rows.Count - 1; i++)
            {
                f = new Familia(
                    //ID
                    GridExcel.Rows[i].Cells[Cid].Value.ToString(),
                    //Descripcion
                    GridExcel.Rows[i].Cells[Cdescripcion].Value.ToString());
                f.Save();
            }
        }
        public void ImportLocalidad()
        {
            Localidad l;

            int Cid = GetColumna(0);
            int Cdescripcion = GetColumna(1);

            for (int i = 0; i < GridExcel.Rows.Count - 1; i++)
            {
                l = new Localidad(
                    //ID
                    GridExcel.Rows[i].Cells[Cid].Value.ToString(),
                    //Descripcion
                    GridExcel.Rows[i].Cells[Cdescripcion].Value.ToString());
                l.Save();
            }
        }
        public void ImportProdComposicion()
        {
            Modelos.Capa2.ProdComposicion p;

            int Cid = GetColumna(0);
            int Cdescripcion = GetColumna(1);
            int CPrecio = GetColumna(2);


            for (int i = 0; i < GridExcel.Rows.Count - 1; i++)
            {
                p = new Modelos.Capa2.ProdComposicion(
                    //ID
                    GridExcel.Rows[i].Cells[Cid].Value.ToString(),
                    //Descripcion
                    GridExcel.Rows[i].Cells[Cdescripcion].Value.ToString(),
                    //Precio
                    Convert.ToDecimal(GridExcel.Rows[i].Cells[CPrecio].Value.ToString()));
                p.Save();
            }
        }
        public void ImportPueblo()
        {
            Pueblo p;

            int Cid = GetColumna(0);
            int Cdescripcion = GetColumna(1);
            int CLocalidad = GetColumna(2);


            for (int i = 0; i < GridExcel.Rows.Count - 1; i++)
            {
                p = new Pueblo(
                    //ID
                    GridExcel.Rows[i].Cells[Cid].Value.ToString(),
                    //Descripcion
                    GridExcel.Rows[i].Cells[Cdescripcion].Value.ToString(),
                    //Localidad
                    GridExcel.Rows[i].Cells[CLocalidad].Value.ToString());
                p.Save();
            }
        }
        public void ImportRelAtributo()
        {
            RelAtributo r;

            int Cid = GetColumna(0);
            int Cdescripcion = GetColumna(1);
            int CNombre = GetColumna(2);


            for (int i = 0; i < GridExcel.Rows.Count - 1; i++)
            {
                r = new RelAtributo(
                    //ID
                    GridExcel.Rows[i].Cells[Cid].Value.ToString(),
                    //Descripcion
                    GridExcel.Rows[i].Cells[Cdescripcion].Value.ToString(),
                    //Nombre
                    GridExcel.Rows[i].Cells[CNombre].Value.ToString());
                r.Save();
            }
        }
        public void ImportSeccion()
        {
            Modelos.Capa3.Seccion s;

            int Cid = GetColumna(0);
            int Cdescripcion = GetColumna(1);
            int CUbicacion = GetColumna(2);


            for (int i = 0; i < GridExcel.Rows.Count - 1; i++)
            {
                s = new Modelos.Capa3.Seccion(
                    //ID
                    GridExcel.Rows[i].Cells[Cid].Value.ToString(),
                    //Descripcion
                    GridExcel.Rows[i].Cells[Cdescripcion].Value.ToString(),
                    //Ubicacion
                    GridExcel.Rows[i].Cells[CUbicacion].Value.ToString());
                s.Save();
            }
        }
        public void ImportTarifa()
        {
            Tarifa t;
            int CPack = GetColumna(0);
            int Cid = GetColumna(1);
            int CBase = GetColumna(2);
            int Ctipo = GetColumna(3);
            int CPrecio = GetColumna(4);


            for (int i = 0; i < GridExcel.Rows.Count - 1; i++)
            {
                t = new Tarifa(
                    //ID
                    GridExcel.Rows[i].Cells[Cid].Value.ToString(),
                    //Base
                    GridExcel.Rows[i].Cells[CBase].Value.ToString(),
                    //Tipo
                    GridExcel.Rows[i].Cells[Ctipo].Value.ToString(),
                    //Cantidad
                    Convert.ToDecimal(GridExcel.Rows[i].Cells[CPrecio].Value.ToString()),
                    //PACK
                    GridExcel.Rows[i].Cells[CPack].Value.ToString()
                    );
                t.Save();
            }
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
