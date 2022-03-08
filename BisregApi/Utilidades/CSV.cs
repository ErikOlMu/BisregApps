using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisregApi.Utilidades
{
    public class CSV
    {
        public static DataTable GetDataTable(string filePath,bool header = false)
        {
            //Leemos todo el archivo
            string[] rows = File.ReadAllLines(filePath);

            //Creamos la dtatable
            DataTable dtData = new DataTable();
            string[] rowValues = null;
            DataRow dr = dtData.NewRow();

            //Creamos las columnas segun la primera fila
            if (rows.Length > 0)
            {
                //Ponemos el nombre de la primera fila en los titulos en el caso que este header activado
                foreach (string columnName in rows[0].Split(','))
                    if (header) dtData.Columns.Add(columnName);
                    else dtData.Columns.Add();
            }


            //Empezara a leer desde la fila 0 si no tiene header o desde la uno si la 0 es el header
            int startrow;

            if (header) startrow = 1;
            else startrow = 0;

            //Creamos las filas
            for (int row = startrow; row < rows.Length; row++)
            {
                rowValues = rows[row].Split(',');

                //En el caso que haya mas columnas en la fila que en datatable, las añadimos en blanco
                while (rowValues.Count() > dtData.Columns.Count)
                {
                    dtData.Columns.Add();
                }
                dr = dtData.NewRow(); 
                dr.ItemArray = rowValues;
                dtData.Rows.Add(dr);
            }

            return dtData;
        }

    }
}
