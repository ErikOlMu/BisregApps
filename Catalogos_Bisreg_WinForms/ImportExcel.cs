using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace Catalogos_Bisreg_WinForms
{
    class ImportExcel
    {
        public static string[] ListFiles()
        {
            using (OpenFileDialog file = new OpenFileDialog())
            {
                //Allow to select multiple files
                file.Multiselect = true;

                //Allow to select only *.txt Files
                file.Filter = "Solo Excel | *.xlsx";

                //Show the Dialog box to selcet file(s)
                file.ShowDialog();

                //return input file names
                return file.FileNames;
            }
        
        }
        public static string GetFile()
        {
            using (SaveFileDialog file = new SaveFileDialog())
            {
                
                file.Filter = "pdf | *.pdf";
                file.FileName = "Export.pdf";

                //Show the Dialog box to selcet file(s)
                file.ShowDialog();

                //return input file names
                return file.FileName;
            }
        }
        public static string GetDirectory()
        {
            using (FolderBrowserDialog dir = new FolderBrowserDialog())
            {
                
                
                //Show the Dialog box to selcet file(s)
                dir.ShowDialog();

                //return input file names
                return dir.SelectedPath;
            }
        }
            public ArrayList GetProductes()
        {
            ArrayList Productos = new ArrayList();


            return null;
        }

        public static ArrayList getReferenciasExcel(string[] Rutas,ArrayList Campos)
        {
            ArrayList Referencias = new ArrayList();
            foreach (string ruta in Rutas)
            {


                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(ruta);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

                //Miro si hay mas campos que Columnas
                if (Campos.Count > xlRange.Columns.Count)
                {
                    MessageBox.Show("Hay mas campos que Columnas en el Excel: "+ruta, "Fallo importacion Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    for (int i = 1; i <= xlRange.Rows.Count; i++)
                    {
                        Item Producto = new Item();

                        for (int j = 1; j <= Campos.Count+1; j++)
                        {

                            //MIRA QUE LOS VALORES NO SEAN NULL
                            if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null && xlRange.Cells[i, j].Value2.ToString() != "")
                            {

                                string ValorCelda = xlRange.Cells[i, j].Value2.ToString();
                                
                                if (j == 1)
                                {
                                    //Pongo los valores de la columna 1 en este campo // Pendiente de Hacer por nombres de Campos
                                    Producto.Referencia = ValorCelda;
                                    
                                }
                                else
                                {
                                    Producto.addCampo(ValorCelda);
                                }

                                

                            }

                        }
                        //Añado el producto 
                        if (Producto.Referencia != null)
                        {
                            Referencias.Add(Producto);

                        }
                        


                    }
                }
                xlWorkbook.Close(0);

            }
            return Referencias;
        }
        
    }
}
