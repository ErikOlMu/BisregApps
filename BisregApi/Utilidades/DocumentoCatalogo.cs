using BisregApi.ControlesWPF;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Threading;

namespace BisregApi.Utilidades
{

    static class Extensions
    {
        public static List<T> Clone<T>(this List<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }
    public class DocumentoCatalogo
    {
        public static FlowDocument GetFlowDocument(DataTable dataTable, PerfilCatalogo perfil, string rutaimg)
        {

            //Inicialicamos el flowdocument
            FlowDocument flowDocument = new FlowDocument();
            flowDocument.PageHeight = perfil.Alto;
            flowDocument.PageWidth = perfil.Ancho;
            flowDocument.PagePadding = new Thickness(0);
            flowDocument.Background = Brushes.White;

            //Bucle Tabla
            Table table = new Table();
            table.CellSpacing = 0;

            TableRowGroup tableRowGroup = new TableRowGroup();

            int cont = 0;
            int contcopia = 1;

            while (cont < (dataTable.Rows.Count))
            {
                for (int i = 0; i < perfil.Filas; i++)
                {
                    TableRow rowDefinition = new TableRow();

                    for (int y = 0; y < perfil.Columnas; y++)
                    {
                        TableCell tableCell = new TableCell();
                        BlockUIContainer contenedor = new BlockUIContainer();
                        try
                        {
                            contenedor.Child = getCanvas(dataTable.Rows[cont], perfil, rutaimg);
                            if (contcopia >= perfil.Copias)
                            {
                                contcopia = 0;
                                cont++;
                            }
                        }
                        catch
                        {
                            contenedor.Child = getCanvas(perfil);
                            contcopia = 0;
                            cont++;
                        }
                        contcopia++;
                        tableCell.Blocks.Add(contenedor);
                        rowDefinition.Cells.Add(tableCell);

                    }
                    tableRowGroup.Rows.Add(rowDefinition);
                }
            }
            table.RowGroups.Add(tableRowGroup);
            flowDocument.Blocks.Add(table);

            return flowDocument;
        }
        public static BisregCanvas getCanvas(PerfilCatalogo perfil)
        {
            BisregCanvas canvas = new BisregCanvas();

            canvas.Height = (perfil.Alto / perfil.Filas);
            canvas.Width = (perfil.Ancho / perfil.Columnas);
            canvas.CamposList.Clear();

            return canvas;
        }
        public static BisregCanvas getCanvas(DataRow datarow, PerfilCatalogo perfil, string rutaimg)
        {

            List<CampoCanvas> campos = perfil.CamposPerfil.Clone();
            BisregCanvas canvas = new BisregCanvas();

            canvas.Height = (perfil.Alto / perfil.Filas);
            canvas.Width = (perfil.Ancho / perfil.Columnas);
            canvas.CamposList.Clear();

            foreach (CampoCanvas c in campos)
            {
                if (c.ColumnaExcel != "")
                {
                    if (c.getTipo() == CamposCanvas.Imagen)
                    {
                        try
                        {
                            string str = Directory.GetFiles(rutaimg, c.TextoAnterior + datarow[c.ColumnaExcel].ToString() + c.TextoPosterior + "_0.*", SearchOption.TopDirectoryOnly)[0];
                            c.Valor = str;
                        }
                        catch
                        {
                            try
                            {
                                c.Valor = Directory.GetFiles(rutaimg, c.TextoAnterior + datarow[c.ColumnaExcel].ToString() + c.TextoPosterior + ".*", SearchOption.TopDirectoryOnly)[0];
                            }
                            catch
                            {
                            }
                        }
                    }
                    else
                    {
                        c.Valor = c.TextoAnterior + datarow[c.ColumnaExcel].ToString() + c.TextoPosterior;

                    }
                }
                canvas.CamposList.Add(c);
            }
            canvas.UpdateCampos();
            return canvas;
        }
    }
}
