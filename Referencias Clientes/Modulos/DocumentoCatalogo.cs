using BisregApi.ControlesWPF;
using BisregApi.Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Referencias_Clientes.Modulos
{
    public class DocumentoCatalogo
    {
        private Settings settings;
        private string SettingsFile = "Config.conf";
        private DataTable datos;
        private FlowDocument flowDoc;
        private void getSettings()
        {
            //Si no existe el fichero config lo creamos
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + AppDomain.CurrentDomain.FriendlyName.Replace(".exe", "") + "\\" + SettingsFile))
            {
                settings = new Settings();
                settings.file = SettingsFile;
            }
            else
            {
                settings = (Settings)Config.getConfig(SettingsFile, typeof(Settings));
            }

            settings.Save();

        }

        public DocumentoCatalogo()
        {

        }

        public FlowDocument GetFlowDocument(DataTable dataTable)
        {
            getSettings();
            datos = dataTable;
            flowDoc = new FlowDocument();

            IniciarFlowDocument();
            BucleTabla();
            return flowDoc;
        }

        public BisregCanvas getCanvas(string Referencia, string ReferenciaCliente, string Pueblo,string Cantidad)
        {

            

            BisregCanvas canvas = new BisregCanvas();

            canvas.Width = (settings.TamañosPagina[settings.TamañoSeleccionado].size.Width / settings.Columnas) * 0.99;
            canvas.Height = (settings.TamañosPagina[settings.TamañoSeleccionado].size.Height / settings.Filas) * 0.99;



            //Creo los campos
            CampoCanvas CampoReferencia = new CampoCanvas(Referencia, settings.CordReferencia, settings.TamañoReferencia);
            //CampoCanvas CampoReferenciaCliente = new CampoCanvas("CLIENTE", settings.CordReferenciaCliente, settings.TamañoReferenciaCliente);
            CampoCanvas CampoReferenciaCliente = new CampoCanvas(ReferenciaCliente, settings.CordReferenciaCliente, settings.TamañoReferenciaCliente);
            CampoCanvas CampoPueblo = new CampoCanvas(Pueblo, settings.CordPueblo, settings.TamañoPueblo);
            CampoCanvas CampoCantidad = new CampoCanvas(Cantidad, settings.CordCantidad, settings.TamañoCantidad);

            //Pongo la Fuente
            try
            {
                CampoReferencia.Elemento.SetValue(TextBlock.FontFamilyProperty, new FontFamily(settings.FuenteReferencia));
                CampoReferenciaCliente.Elemento.SetValue(TextBlock.FontFamilyProperty, new FontFamily(settings.FuenteReferenciaCliente));
                CampoPueblo.Elemento.SetValue(TextBlock.FontFamilyProperty, new FontFamily(settings.FuentePueblo));
                CampoCantidad.Elemento.SetValue(TextBlock.FontFamilyProperty, new FontFamily(settings.FuenteCantidad));
            }
            catch
            {
                //Excepcion en caso de que no encuentre la fuente
            }

            canvas.CamposList.Clear();
            //Añado los dos campos
            canvas.CamposList.Add(CampoReferencia);
            canvas.CamposList.Add(CampoReferenciaCliente);
            canvas.CamposList.Add(CampoPueblo);
            canvas.CamposList.Add(CampoCantidad);

            canvas.UpdateCampos();
            return canvas;
        }

        public void BucleTabla()
        {
            Table table = new Table();

            TableRowGroup tableRowGroup = new TableRowGroup();

            int cont = 0;
            int contcopia = 1;

            while (cont <= (datos.Rows.Count))
            {

                for (int i = 0; i < (settings.Filas); i++)
                {
                    TableRow rowDefinition = new TableRow();
                    for (int y = 0; y < settings.Columnas; y++)
                    {
                        TableCell tableCell = new TableCell();

                        
                        BlockUIContainer contenedor = new BlockUIContainer();

                        try
                        {
                            contenedor.Child = getCanvas(datos.Rows[cont][1].ToString(), datos.Rows[cont][0].ToString(),datos.Rows[cont][2].ToString(),"Uds.");
                        }
                        catch
                        {
                            contenedor.Child = getCanvas("", "","","");
                        }

                        if (contcopia >= settings.Copias)
                        {
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
            flowDoc.Blocks.Add(table);
        }
        public void IniciarFlowDocument()
        {

            flowDoc.PageHeight = settings.TamañosPagina[settings.TamañoSeleccionado].size.Height;
            flowDoc.PageWidth = settings.TamañosPagina[settings.TamañoSeleccionado].size.Width;
            flowDoc.PagePadding = new Thickness(0);
            flowDoc.ColumnWidth = 999999;
            flowDoc.Background = Brushes.White;

        }
    }
}
