using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AltasBisreg.Modelos.Settings;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using AltasBisreg.Modelos.Capa1;
using AltasBisreg.Modelos.Capa2;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace AltasBisreg.Controladores
{
    class ConnexionExcel
    {
        private string ruta = "";
        private Documento documento = new Documento();
        private List<DocumentoProducto> documentoProducto = new List<DocumentoProducto>();
        int ultimaFilaArticulosPrecios = 2;
        int ultimaFilaComposicion = 2;
        int ultimafila = 2;
        int ultimaFilaAlmacen = 2;
        public ConnexionExcel(Documento documento, string ruta)
        {
            this.documento = documento;
            this.ruta = ruta;

            GenerarExcel();
        }
        public ConnexionExcel(List<DocumentoProducto> documentoProducto, string ruta)
        {
            this.documentoProducto = documentoProducto;
            this.ruta = ruta;

            GenerarExcelProductos();
        }
        public void GenerarExcel()
        {
            try
            {
                Application App = new Application();

                //Optimicacion
                App.ScreenUpdating = false;
                Workbook Libro = App.Workbooks.Open(Directory.GetCurrentDirectory() + "\\template.xlsx");
                foreach (Item i in documento.GetListItems())
                {
                    if (!i.Algunnull())
                    {
                        InsertarArticulos(Libro, i);
                        InsertarArticulosPrecios(Libro, i);
                        InsertarAtributos(Libro, i);
                        InsertarPRCMETO(Libro, i);
                        InsertarPRMMETO(Libro, i);
                        InsertarPRMETODO(Libro, i);
                        InsertarComposicion(Libro, i);
                        InsertarAlmacen(Libro, i);
                        ultimafila = ultimafila + 1;

                    }
                }



                App.Visible = false;
                App.UserControl = true;

                Libro.SaveAs(ruta);


                Libro.Close(0);
                App.Quit();
                App = null;

            }
            catch
            {
                
            }
        }
        public void GenerarExcelProductos()
        {
            
                Application App = new Application();

                //Optimicacion
                App.ScreenUpdating = false;
                Workbook Libro = App.Workbooks.Open(Directory.GetCurrentDirectory() + "\\template.xlsx");
                foreach (DocumentoProducto p in documentoProducto)
                {

                    if (p.REFERENCIA != null && p.REFERENCIA != "")
                    {

                        InsertarArticulos(Libro, p);
                        InsertarArticulosPrecios(Libro, p);
                        InsertarAtributos(Libro, p);
                        InsertarPRCMETO(Libro, p);
                        InsertarPRMMETO(Libro, p);
                        InsertarPRMETODO(Libro, p);
                        InsertarAlmacen(Libro, p);
                        ultimafila = ultimafila + 1;

                    }

                }



                App.Visible = false;
                App.UserControl = true;

                Libro.SaveAs(ruta);


                Libro.Close(0);
                App.Quit();
                App = null;

            }
        public void InsertarArticulos(Workbook Libro, DocumentoProducto item)
        {
            
            Excel._Worksheet Articulos = Libro.Sheets["ARTICULOS"];
            //Referencia 
            //A
            Articulos.Cells[ultimafila, 1] = item.REFERENCIA;
            //Descripcion
            //B
            Articulos.Cells[ultimafila, 2] = item.DESCRIPCION;
            //Familia
            //C
            Articulos.Cells[ultimafila, 3] = item.FAMILIA;
            //Estaticos
            //D
            Articulos.Cells[ultimafila, 4] = "'00000000";
            //E
            Articulos.Cells[ultimafila, 5] = "'0000";
            //F
            Articulos.Cells[ultimafila, 6] = "'000000";
            //G
            Articulos.Cells[ultimafila, 7] = "1";
            //H
            Articulos.Cells[ultimafila, 8] = "C";
            //I
            Articulos.Cells[ultimafila, 9] = "3";
            //Pedido Minimo
            //J
            Articulos.Cells[ultimafila, 10] = item.PEDIDO_MINIMO;
            //K
            Articulos.Cells[ultimafila, 11] = "1";
            //L
            Articulos.Cells[ultimafila, 12] = "0";
            //M
            Articulos.Cells[ultimafila, 13] = "C";
            //N
            Articulos.Cells[ultimafila, 14] = "1";
            //O
            Articulos.Cells[ultimafila, 15] = "1";
            //P
            Articulos.Cells[ultimafila, 16] = "";
            //Q
            Articulos.Cells[ultimafila, 17] = "01";
            //R
            Articulos.Cells[ultimafila, 18] = "0";
            //Localidad
            //S
            Articulos.Cells[ultimafila, 19] = item.LOCALIDAD;
            //Ambito
            //T
            Articulos.Cells[ultimafila, 20] = Config.ValorAmbito;
            //Seccion
            //U
            Articulos.Cells[ultimafila, 21] = item.SECCION;
            //V
            Articulos.Cells[ultimafila, 22] = "2";
            //W
            Articulos.Cells[ultimafila, 23] = "1";
            //X
            Articulos.Cells[ultimafila, 24] = "0";
            //Y




        }
        public void InsertarArticulos(Workbook Libro, Item item)
        {
            Excel._Worksheet Articulos = Libro.Sheets["ARTICULOS"];
            //Referencia 
            //A
            Articulos.Cells[ultimafila, 1] = item.GetReferencia();
            //Descripcion
            //B
            Articulos.Cells[ultimafila, 2] = item.GetDescripcion();
            //Familia
            //C
            Articulos.Cells[ultimafila, 3] = item.GetBase().GetFamilia();
            //Estaticos
            //D
            Articulos.Cells[ultimafila, 4] = "'00000000";
            //E
            Articulos.Cells[ultimafila, 5] = "'0000";
            //F
            Articulos.Cells[ultimafila, 6] = "'000000";
            //G
            Articulos.Cells[ultimafila, 7] = "1";
            //H
            Articulos.Cells[ultimafila, 8] = "C";
            //I
            Articulos.Cells[ultimafila, 9] = "3";
            //Pedido Minimo
            //J
            Articulos.Cells[ultimafila, 10] = item.GetBase().GetpedidoMinimo(); 
            //K
            Articulos.Cells[ultimafila, 11] = "1";
            //L
            Articulos.Cells[ultimafila, 12] = "0";
            //M
            Articulos.Cells[ultimafila, 13] = "C";
            //N
            Articulos.Cells[ultimafila, 14] = "1";
            //O
            Articulos.Cells[ultimafila, 15] = "1";
            //P
            Articulos.Cells[ultimafila, 16] = "";
            //Q
            Articulos.Cells[ultimafila, 17] = "01";
            //R
            Articulos.Cells[ultimafila, 18] = "1";
            //Localidad
            //S
            Articulos.Cells[ultimafila, 19] = item.GetPueblo().GetLocalidad(); ;
            //Ambito
            //T
            Articulos.Cells[ultimafila, 20] = Config.ValorAmbito;
            //Seccion
            //U
            Articulos.Cells[ultimafila, 21] = item.GetBase().GetSeccion();
            //V
            Articulos.Cells[ultimafila, 22] = "2";
            //W
            Articulos.Cells[ultimafila, 23] = "1";
            //X
            Articulos.Cells[ultimafila, 24] = "1";



        }
        public void InsertarArticulosPrecios(Workbook Libro, Item item)
        {

            Excel._Worksheet ArticulosPrecio = Libro.Sheets["ARTICULOS PRECIOS"];
            for (int i = 0; i <= 3; i++)
            {
                //Referencia
                ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 1] = item.GetReferencia();

                //Estatico
                ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 3] = "1";

                //Estatico
                ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 9] = "1";

                switch (i)
                {
                    case 0:

                        //Codigo tarifa
                        ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 2] = Config.ValorPV1;
                        ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 10] = Config.ValorPV1;

                        //Precio PV1
                        ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 4] = item.GetBase().GetPv1();
                        ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 8] = item.GetBase().GetPv1();

                        break;
                    case 1:

                        //Codigo tarifa
                        ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 2] = Config.ValorPV2;
                        ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 10] = Config.ValorPV2;

                        //Precio PV2
                        ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 4] = item.GetBase().GetPv2();
                        ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 8] = item.GetBase().GetPv2();

                        break;
                    case 2:

                        //Codigo tarifa
                        ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 2] = Config.ValorPV3;
                        ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 10] = Config.ValorPV3;

                        //Precio PV3
                        ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 4] = item.GetBase().GetPv3();
                        ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 8] = item.GetBase().GetPv3();


                        break;
                    case 3:

                        //Codigo tarifa
                        ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 2] = Config.ValorCoste;
                        ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 10] = Config.ValorCoste;

                        //Precio Cpste
                        ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 4] = item.GetBase().GetCoste();
                        ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 8] = item.GetBase().GetCoste();

                        break;

                }

                ultimaFilaArticulosPrecios = ultimaFilaArticulosPrecios + 1;

                



            }

            foreach (Modelos.Capa3.Tarifa t in ConnexionSQL.GetTarifas(item.GetBase()))
            {
                // Referencia
                ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 1] = item.GetReferencia();

                //Estatico
                ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 3] = "1";

                ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 2] = t.GetID();
                ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 10] = t.GetID();

                //Precio PV1
                ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 4] = t.GetPrecio();
                ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 8] = t.GetPrecio();

                ultimaFilaArticulosPrecios = ultimaFilaArticulosPrecios + 1;

            }
        }
        public void InsertarArticulosPrecios(Workbook Libro, DocumentoProducto item)
        {

            Excel._Worksheet ArticulosPrecio = Libro.Sheets["ARTICULOS PRECIOS"];
            for (int i = 0; i <= 3; i++)
            {
                //Referencia
                ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 1] = item.REFERENCIA;

                //Estatico
                ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 3] = "1";
                //Estatico
                ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 9] = "1";

                switch (i)
                {
                    case 0:

                        //Codigo tarifa
                        ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 2] = Config.ValorPV1;
                        ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 10] = Config.ValorPV1;

                        //Precio PV1
                        ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 4] = item.TARIFA_1;
                        ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 8] = item.TARIFA_1;

                        break;
                    case 1:

                        //Codigo tarifa
                        ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 2] = Config.ValorPV2;
                        ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 10] = Config.ValorPV2;

                        //Precio PV2
                        ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 4] = item.TARIFA_2;
                        ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 8] = item.TARIFA_2;

                        break;
                    case 2:

                        //Codigo tarifa
                        ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 2] = Config.ValorPV3;
                        ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 10] = Config.ValorPV3;

                        //Precio PV3
                        ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 4] = item.TARIFA_3;
                        ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 8] = item.TARIFA_3;


                        break;
                    case 3:

                        //Codigo tarifa
                        ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 2] = Config.ValorCoste;
                        ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 10] = Config.ValorCoste;

                        //Precio Cpste
                        ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 4] = item.TARIFA_COSTE;
                        ArticulosPrecio.Cells[ultimaFilaArticulosPrecios, 8] = item.TARIFA_COSTE;

                        break;

                }

                ultimaFilaArticulosPrecios = ultimaFilaArticulosPrecios + 1;





            }

            
        }
        public void InsertarAtributos(Workbook Libro, Item item)
        {
            Excel._Worksheet Atributos = Libro.Sheets["Atributos"];
            //Ambito
            Atributos.Cells[ultimafila, 1] = "3";
            //Codigo atributo
            Atributos.Cells[ultimafila, 2] = item.GetBase().GetAtributo();
            //Codigo Articulo
            Atributos.Cells[ultimafila, 3] = item.GetReferencia();
            //Valor Atributo
            Atributos.Cells[ultimafila, 4] = item.GetBase().GetRelAtributo();
            //Campo estatico
            Atributos.Cells[ultimafila, 5] = "1";

        }
        public void InsertarAtributos(Workbook Libro, DocumentoProducto item)
        {
            Excel._Worksheet Atributos = Libro.Sheets["Atributos"];
            //Ambito
            Atributos.Cells[ultimafila, 1] = "3";
            //Codigo atributo
            Atributos.Cells[ultimafila, 2] = item.ATRIBUTO;
            //Codigo Articulo
            Atributos.Cells[ultimafila, 3] = item.REFERENCIA;
            //Valor Atributo
            Atributos.Cells[ultimafila, 4] = item.RELACION_ATRIBUTO;
            //Campo estatico
            Atributos.Cells[ultimafila, 5] = "1";

        }
        public void InsertarPRCMETO(Workbook Libro, Item item)
        {
            Excel._Worksheet PRCMETO = Libro.Sheets["PRCMETO"];

            //Referencia
            PRCMETO.Cells[ultimafila, 1] = item.GetReferencia();
            //Descripcion
            PRCMETO.Cells[ultimafila, 2] = item.GetDescripcion();

        }
        public void InsertarPRCMETO(Workbook Libro, DocumentoProducto item)
        {
            Excel._Worksheet PRCMETO = Libro.Sheets["PRCMETO"];

            //Referencia
            PRCMETO.Cells[ultimafila, 1] = item.REFERENCIA;
            //Descripcion
            PRCMETO.Cells[ultimafila, 2] = item.DESCRIPCION;

        }
        public void InsertarPRMMETO(Workbook Libro, Item item)
        {
            Excel._Worksheet PRMMETO = Libro.Sheets["PRMMETO"];

            //Referencia
            PRMMETO.Cells[ultimafila, 1] = item.GetReferencia();
            //Estatico
            PRMMETO.Cells[ultimafila, 2] = "'0001";
        }
        public void InsertarPRMMETO(Workbook Libro, DocumentoProducto item)
        {
            Excel._Worksheet PRMMETO = Libro.Sheets["PRMMETO"];

            //Referencia
            PRMMETO.Cells[ultimafila, 1] = item.REFERENCIA;
            //Estatico
            PRMMETO.Cells[ultimafila, 2] = "'0001";
        }
        public void InsertarPRMETODO(Workbook Libro, Item item)
        {
            Excel._Worksheet PRMETODO = Libro.Sheets["PRMETODO"];

            //Referencia
            PRMETODO.Cells[ultimafila, 1] = item.GetReferencia();
            //Estaticos
            PRMETODO.Cells[ultimafila, 2] = "'0001";
            PRMETODO.Cells[ultimafila, 3] = "ALTA AUTOMATICA";
            PRMETODO.Cells[ultimafila, 4] = "'000";

        }
        public void InsertarPRMETODO(Workbook Libro, DocumentoProducto item)
        {
            Excel._Worksheet PRMETODO = Libro.Sheets["PRMETODO"];

            //Referencia
            PRMETODO.Cells[ultimafila, 1] = item.REFERENCIA;
            //Estaticos
            PRMETODO.Cells[ultimafila, 2] = "'0001";
            PRMETODO.Cells[ultimafila, 3] = "ALTA AUTOMATICA";
            PRMETODO.Cells[ultimafila, 4] = "'000";

        }
        public void InsertarComposicion(Workbook Libro, Item item)
        {
            Excel._Worksheet composicion = Libro.Sheets["COMPOSICION"];

            int contador = 1;
            foreach (Composicion c in item.GetBase().GetComposiciones())
            {
                //Referencia
                composicion.Cells[ultimaFilaComposicion, 1] = item.GetReferencia();
                //Estatico
                composicion.Cells[ultimaFilaComposicion, 2] = "'0001";
                //Linea
                composicion.Cells[ultimaFilaComposicion, 3] = "'" + contador.ToString("D4");
                //Codigo Articulo
                composicion.Cells[ultimaFilaComposicion, 4] = c.GetID();
                //Cantidad
                composicion.Cells[ultimaFilaComposicion, 5] = c.GetCantidad();
                //Descripcion
                composicion.Cells[ultimaFilaComposicion, 6] = c.GetProdComposicion().GetDescripcion();



                contador = contador + 1;
                ultimaFilaComposicion = ultimaFilaComposicion + 1;
            }
            

            }
        public void InsertarAlmacen(Workbook Libro, Item item)
        {
            _Worksheet almacen = Libro.Sheets["ALMACEN"];

            for (int i = 1; i <= 2; i++)
            {
                //Referencia
                almacen.Cells[ultimaFilaAlmacen, 1] = item.GetReferencia();
                if (i == 1)
                {
                    //01 
                    almacen.Cells[ultimaFilaAlmacen, 2] = "01";

                    //Ubicacion de la seccion
                    almacen.Cells[ultimaFilaAlmacen, 3] = Modelos.Capa3.Seccion.GetSeccion(item.GetBase().GetSeccion()).GetUbicacion();
                }
                else
                {
                    //02
                    almacen.Cells[ultimaFilaAlmacen, 2] = "02";
                }
                ultimaFilaAlmacen = ultimaFilaAlmacen + 1;

            }


        }
        public void InsertarAlmacen(Workbook Libro, DocumentoProducto item)
        {
            _Worksheet almacen = Libro.Sheets["ALMACEN"];

            for (int i = 1; i <= 2; i++)
            {
                //Referencia
                almacen.Cells[ultimaFilaAlmacen, 1] = item.REFERENCIA;
                if (i == 1)
                {
                    //01 
                    almacen.Cells[ultimaFilaAlmacen, 2] = "01";

                    //Ubicacion de la seccion
                    if (Modelos.Capa3.Seccion.GetSeccion(item.SECCION)== null)
                    {
                        almacen.Cells[ultimaFilaAlmacen, 3] = "";

                    }
                    else
                    {
                        almacen.Cells[ultimaFilaAlmacen, 3] = Modelos.Capa3.Seccion.GetSeccion(item.SECCION).GetUbicacion();
                    }
                }
                else
                {
                    //02
                    almacen.Cells[ultimaFilaAlmacen, 2] = "02";
                }
                ultimaFilaAlmacen = ultimaFilaAlmacen + 1;

            }


        }
        //[FILA][COLUMNA]
        public static List<List<string>> GetExcel(string rutaexcel)
        {
            List<List<string>> listaexcel = new List<List<string>>();

            Application App = new Application();

            //Optimicacion
            App.ScreenUpdating = false;
            Workbook Libro = App.Workbooks.Open(rutaexcel);


            _Worksheet Hoja = Libro.Sheets[1];
            Range Rango = Hoja.UsedRange;

            for (int i = 1; i <= Rango.Rows.Count; i++)
            {
                List<string> Columna = new List<string>();
                for (int j = 1; j <= Rango.Columns.Count; j++)
                {
                    if (Rango.Cells[i, j] != null && Rango.Cells[i, j].Value2 != null && Rango.Cells[i, j].Value2.ToString() != "")
                    {
                        Columna.Add(Rango.Cells[i, j].Value2.ToString());
                    }
                    else
                    {
                        Columna.Add("");
                    }
                }
                if (!Estavacia(Columna))
                {
                    listaexcel.Add(Columna);
                }

            }


            Libro.Close(0);
            App.Quit();
            App = null;
            return listaexcel;
            
        }
        public static bool Estavacia(List<string> lista)
        {
            foreach(string l in lista)
            {
                if (l != "") { return false; }
            }
            return true;
        }

    }
}
