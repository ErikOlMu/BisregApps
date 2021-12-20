using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;

namespace BisregApi.Utilidades
{
    public class Excel
    {

        //Obtener DataTable de Fichero excel
        public static DataTable GetDataTable(string ruta, List<string> Campos, int LimiteFilas)
        {   
                //Añado una fila mas al limite para despues controlar si se ha pasado
                LimiteFilas = LimiteFilas + 1;
                //Obtengo la Datatable
                Workbook workbook = new Workbook(ruta);
                Worksheet worksheet = workbook.Worksheets[0];
                DataTable dt = worksheet.Cells.ExportDataTable(0, 0, LimiteFilas, Campos.Count, false);


                //Añado los titulos
                int index = 0;
                foreach (string campo in Campos)
                {
                    dt.Columns[index].ColumnName = campo;
                    index = index + 1;
                }

                //Quito las filas Vacias
                var dtResultado = dt.Rows.Cast<DataRow>().Where(row => !Array.TrueForAll(row.ItemArray, value => { return value.ToString().Length == 0; }));
                
                
                dt = dtResultado.CopyToDataTable();

                //Compruebo si se a pasado el limite de filas en ese caso retorno null
                if (dt.Rows.Count >= LimiteFilas) return null;
                else return dt;



        }
        }


    }


