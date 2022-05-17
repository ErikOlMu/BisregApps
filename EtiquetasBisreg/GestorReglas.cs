using BisregApi.Diseño;
using BisregApi.SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EtiquetasBisreg
{
    public class GestorReglas
    {
        GestorBDD gestor;
        public GestorReglas()
        {
            string datos = BisregApi.Utilidades.Config.DirectorioAppData + "Datos.bdd";
            if (!File.Exists(datos)) 
            {
                MessageBox.Show("Sin datos, se crearan unos nuevos");
                Directory.CreateDirectory(Path.GetDirectoryName(datos));
                gestor = new GestorBDD(datos);

                GenerarTabla();
            }
            else
            {
                gestor = new GestorBDD(datos);

            }



        }
        public DataTable GetDataTable(string table)
        {
            return gestor.GetDataTable(table);
        }
        public bool DBValida()
        {

            List<string> tablas = gestor.GetTables();
            return tablas.Contains("ReglaCantidad");
        }
        public void SaveDataTable(DataTable table)
        {
            gestor.SaveDataTable(table);
        }
            public void GenerarTabla()
        {
            gestor.AutoGenerarTablasSQL(typeof(ReglaCantidad));
        }

        public string QueryRegla(ItemProduccion item, string Tabla)
        {
            return "SELECT * FROM " + Tabla + " WHERE(Tipo = '" + item.Tipo + "' or Tipo = 'A') and (Base = '" + item.Base + "' or Base = 'A')";
        }

        public int ConsultaReglaCantidad(ItemProduccion item)
        {
            List<ReglaCantidad> list = new List<ReglaCantidad>();
            using (var ctx = gestor.GetInstance())
            {
                string query = QueryRegla(item, "ReglaCantidad");
                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ReglaCantidad regla = new ReglaCantidad(
                            reader["Tipo"].ToString() ?? "",
                            reader["Base"].ToString() ?? "",
                            Int64.Parse(reader["Cantidad"].ToString() ?? "0"));
                            list.Add(regla);
                        }
                        if (list.Count != 0)
                        {
                            var max = list.Max(x => x.Nivel());
                            int cantidad = ((int?)list.First(x => x.Nivel() == max).Cantidad) ?? 1;
                            return cantidad;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                }
            }


        }
    }
}
