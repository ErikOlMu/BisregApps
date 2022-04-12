using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BisregApi.SQLite;
using BisregApi.Utilidades;
using System.Data.SQLite;


namespace PrintBisreg.Modulos
{
    public class CollecionReglas
    {
        GestorBDD gestor;
        private Settings settings;
        public CollecionReglas()
        {
            
            //Inicializamos Settings
            // Si no existe el fichero config lo creamos
            if (!File.Exists(Settings.DirectorioAppData + Settings.file))
            {
                settings = new Settings();
            }
            else
            {
                settings = (Settings)Config.getConfig(Settings.file, typeof(Settings));
            }
            settings.Save();

            //Obtengo la instancia de la BDD


            if (!File.Exists(settings.rutaBDD))
            {
                gestor = new GestorBDD(settings.rutaBDD);
                GenerarTablas();
            }
            else gestor = new GestorBDD(settings.rutaBDD);



        }

        public bool DBValida()
        {

            List<string> tablas = gestor.GetTables();
            return tablas.Contains("ReglaCantidad") && tablas.Contains("ReglaPMinimo") && tablas.Contains("ReglaAgotados") && tablas.Contains("ReglaPlotter");
        }
        public DataTable GetDataTable(string table)
        {
            return gestor.GetDataTable(table);
        }



        public void SaveDataTable(DataTable table)
        {
            gestor.SaveDataTable(table);
        }

        public void GenerarTablas()
        {
            gestor.AutoGenerarTablasSQL(typeof(ReglaCantidad));
            gestor.AutoGenerarTablasSQL(typeof(ReglaPMinimo));
            gestor.AutoGenerarTablasSQL(typeof(ReglaAgotados));
            gestor.AutoGenerarTablasSQL(typeof(ReglaPlotter));
        }


        //Consulta si le afecta la regla de agotados
        public bool ConsultaAgotado(ItemProduccion item)
        {
            using (var ctx = gestor.GetInstance())
            {
                string query = QueryReglaScalar(item, "ReglaAgotados");   
                return Convert.ToInt32(new SQLiteCommand(query, ctx).ExecuteScalar()) == 0;
            }
        }
        //Obtener la Cantidad de la Regla con mas Nivel
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
                            ReglaCantidad regla = new ReglaCantidad();
                            regla.Tipo = reader["Tipo"].ToString();
                            regla.Pueblo = reader["Pueblo"].ToString();
                            regla.Base = reader["Base"].ToString();
                            regla.Diseño = reader["Diseño"].ToString();
                            regla.Cantidad = Int64.Parse(reader["Cantidad"].ToString());
                            list.Add(regla);
                        }
                        if (list.Count != 0)
                        {
                            var max = list.Max(x => x.Nivel());
                            return (int)list.First(x => x.Nivel() == max).Cantidad;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                }
            }

            
        }


        

        //Obtener la Cantidad de la Regla  ReglaPMinimo con mas Nivel
        public int ConsultaReglaPMinimo(ItemProduccion item)
        {
            List<ReglaPMinimo> list = new List<ReglaPMinimo>();
            using (var ctx = gestor.GetInstance())
            {
                string query = QueryRegla(item, "ReglaPMinimo");
                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ReglaPMinimo regla = new ReglaPMinimo();
                            regla.Tipo = reader["Tipo"].ToString();
                            regla.Pueblo = reader["Pueblo"].ToString();
                            regla.Base = reader["Base"].ToString();
                            regla.Diseño = reader["Diseño"].ToString();
                            regla.Cantidad = Int64.Parse(reader["Cantidad"].ToString());
                            list.Add(regla);
                        }
                        if (list.Count != 0)
                        {
                            var max = list.Max(x => x.Nivel());
                            return (int)list.First(x => x.Nivel() == max).Cantidad;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                }
            }


        }

        //Cpnsulta si le afecta la Regla de No Plotter
        public bool ConsultaPlotter(ItemProduccion item)
        {
            using (var ctx = gestor.GetInstance())
            {
                string query = QueryReglaScalar(item, "ReglaPlotter");
                return Convert.ToInt32(new SQLiteCommand(query, ctx).ExecuteScalar()) == 0;
            }
        }

        public string QueryReglaScalar(ItemProduccion item, string Tabla)
        {
            return "SELECT COUNT() FROM "+Tabla+" WHERE(Tipo = '" + item.Tipo + "' or Tipo = 'A') and (Pueblo = '" + item.Pueblo + "' or Pueblo = 'A') and (Base = '" + item.Base + "' or Base = 'A') and (Diseño = '" + item.Diseño + "' or Diseño = 'A')";
        }
        public string QueryRegla(ItemProduccion item, string Tabla)
        {
            return "SELECT * FROM " + Tabla + " WHERE(Tipo = '" + item.Tipo + "' or Tipo = 'A') and (Pueblo = '" + item.Pueblo + "' or Pueblo = 'A') and (Base = '" + item.Base + "' or Base = 'A') and (Diseño = '" + item.Diseño + "' or Diseño = 'A')";
        }

    }
}
