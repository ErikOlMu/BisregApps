using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

//Añado la Capa 2 i 3 para importarlas
using AltasBisreg.Modelos.Capa2;
using AltasBisreg.Modelos.Capa3;

using AltasBisreg.Modelos.Settings;

using System.IO;

namespace AltasBisreg.Controladores

{
    class ConnexionSQL
    {

        //Crear BDD


        public static void Crear(string DBName)
        {
            bool IsDbRecentlyCreated = false;
            if (!File.Exists(Path.GetFullPath(DBName)))
            {
                SQLiteConnection.CreateFile(DBName);
                IsDbRecentlyCreated = true;
            }

            



            using (var ctx = GetInstance())
            {
                if (IsDbRecentlyCreated)
                {
                    using (var reader = new StreamReader(Path.GetFullPath(Directory.GetCurrentDirectory() + "\\Altas.sql")))
                    {
                        var query = "";
                        var line = "";
                        while ((line = reader.ReadLine()) != null)
                        {
                            query += line;
                        }

                        using (var command = new SQLiteCommand(query, ctx))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }


        //Connexion SQL
        public static SQLiteConnection GetInstance()
        {
            try
            {
                SQLiteConnection db = new SQLiteConnection("Data Source=" + Config.RutaBaseDatos + ";Version=3;");
                db.Open();
                Program.ventana.Connexion.ForeColor = System.Drawing.Color.Green;
                Program.ventana.Connexion.Text = "Estado: Conectado";

                return db;

            }
            catch
            {
                SQLiteConnection db = new SQLiteConnection("Data Source=local.db;Version=3;");
                db.Open();
                Program.ventana.Connexion.Text = "Estado: Desconectado (Connexion Local)";
                Program.ventana.Connexion.ForeColor = System.Drawing.Color.Red;

                return db;

            }
        }

        //Obtener nombres de tablas
        public static List<string> GetTables()
        {
            List<string> Lista = new List<string>();

            using (var ctx = GetInstance())
            {
                //Selecciono todas las composiciones de la base 
                var query = "SELECT name FROM sqlite_master WHERE type='table'; ";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Lista.Add(reader["name"].ToString());
                        }
                    }
                }
            }


            return Lista;
        }
        public static List<string> GetColumnas(string Tabla)
        {
            List<string> Lista = new List<string>();

            using (var ctx = GetInstance())
            {
                //Selecciono todas las composiciones de la base 
                var query = "PRAGMA TABLE_INFO("+Tabla+");";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Lista.Add(reader["name"].ToString());
                        }
                    }
                }
            }


            return Lista;
        }

        public static List<List<string>> GetValoresTabla(string Tabla)
        {
            List<List<string>> Lista = new List<List<string>>();

            using (var ctx = GetInstance())
            {
                //Selecciono todas las composiciones de la base 
                var query = "SELECT * FROM "+Tabla;
                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            List<string> linea = new List<string>();
                            foreach(string columna in GetColumnas(Tabla))
                            {
                                linea.Add(reader[columna].ToString());
                            }
                            Lista.Add(linea);
                        }
                    }
                }
            }


            return Lista;
        }

        public static List<string> GetTipos()
        {
            List<string> Lista = new List<string>();
            using (var ctx = GetInstance())
            {
                //Selecciono todas las composiciones de la base 
                var query = "SELECT DISTINCT(TIPO) FROM BASE; ";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Lista.Add(reader["TIPO"].ToString());
                        }
                    }
                }
            }
            

            return Lista;
        }
        //Obtiene los packs
        public static List<string> GetPacks(string TABLA)
        {
            List<string> Lista = new List<string>();
            using (var ctx = GetInstance())
            {
                var query = "SELECT DISTINCT(PACK) FROM " + TABLA + "; ";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Lista.Add(reader["PACK"].ToString());
                        }
                    }
                }
            }


            return Lista;

        }

        //------------------------------------------------------------------------------------------------

        //Capa 2

        //Base
        public static Base GetBase(string ID, string TIPO,string pack = "GENERAL")
        {
            Base @base = null;
            using (var ctx = GetInstance())
            {
                var query = "SELECT * FROM BASE WHERE ID = '" + ID+ "' AND TIPO = '" + TIPO+ "' AND PACK = '" + pack + "'  ; ";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            @base = new Base(
                            reader["ID"].ToString(), 
                            reader["TIPO"].ToString(),
                            reader["DESCRIPCION"].ToString(),
                            reader["FAMILIA"].ToString(),
                            reader["SECCION"].ToString(),
                            Convert.ToDecimal(reader["PV1"]), 
                            Convert.ToDecimal(reader["PV2"]), 
                            Convert.ToDecimal(reader["PV3"]),
                            reader["ATRIBUTO"].ToString(),
                            reader["VALOR_ATRIBUTO"].ToString(),
                            Convert.ToInt32(reader["PEDIDO_MINIMO"]),
                            reader["PACK"].ToString());
                        }
                    }
                }
            }
            return @base;
        }
        public static void SetBase(Base @base, bool Update)
        {
            using (var ctx = GetInstance())
            {
                string query;
                if (Update) query = "UPDATE BASE SET DESCRIPCION = :DESCRIPCION ,FAMILIA = :FAMILIA ,SECCION = :SECCION ,PV1 = :PV1 ,PV2 = :PV2 ,PV3 = :PV3 ,ATRIBUTO = :ATRIBUTO ,VALOR_ATRIBUTO = :VALOR_ATRIBUTO ,PEDIDO_MINIMO = :PEDIDO_MINIMO WHERE ID = :ID AND TIPO = :TIPO AND PACK = :PACK;";
                else query = "INSERT INTO BASE (PACK,ID,TIPO,DESCRIPCION,FAMILIA,SECCION,PV1,PV2,PV3,ATRIBUTO,VALOR_ATRIBUTO,PEDIDO_MINIMO) VALUES (?,?,?,?,?,?,?,?,?,?,?,?) ;";

                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("PACK", @base.Getpack()));
                    command.Parameters.Add(new SQLiteParameter("ID", @base.GetId()));
                    command.Parameters.Add(new SQLiteParameter("TIPO", @base.GetTipo()));
                    command.Parameters.Add(new SQLiteParameter("DESCRIPCION", @base.GetNombre()));
                    command.Parameters.Add(new SQLiteParameter("FAMILIA", @base.GetFamilia()));
                    command.Parameters.Add(new SQLiteParameter("SECCION", @base.GetSeccion()));
                    command.Parameters.Add(new SQLiteParameter("PV1", @base.GetPv1()));
                    command.Parameters.Add(new SQLiteParameter("PV2", @base.GetPv2()));
                    command.Parameters.Add(new SQLiteParameter("PV3", @base.GetPv3()));
                    command.Parameters.Add(new SQLiteParameter("ATRIBUTO", @base.GetAtributo()));
                    command.Parameters.Add(new SQLiteParameter("VALOR_ATRIBUTO", @base.GetRelAtributo()));
                    command.Parameters.Add(new SQLiteParameter("PEDIDO_MINIMO", @base.GetpedidoMinimo()));

                    command.ExecuteNonQuery();
                }

            }
        }
        public static void DeleteBase(Base @base)
        {
            using (var ctx = GetInstance())
            {
                var query = "DELETE FROM BASE WHERE ID = :ID AND TIPO = :TIPO AND PACK = :PACK;";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("ID", @base.GetId()));
                    command.Parameters.Add(new SQLiteParameter("TIPO", @base.GetTipo()));
                    command.Parameters.Add(new SQLiteParameter("PACK", @base.Getpack()));

                    command.ExecuteNonQuery();
                }
            }
        }

        public static List<Base> GetBases(string pack = "GENERAL")
        {
            List<Base> Lista = new List<Base>();

            using (var ctx = GetInstance())
            {
                //Selecciono todas las composiciones de la base 
                var query = "SELECT * FROM BASE WHERE PACK = '" + pack +"'";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Lista.Add(new Base(
                            reader["ID"].ToString(),
                            reader["TIPO"].ToString(),
                            reader["DESCRIPCION"].ToString(),
                            reader["FAMILIA"].ToString(),
                            reader["SECCION"].ToString(),
                            Convert.ToDecimal(reader["PV1"]),
                            Convert.ToDecimal(reader["PV2"]),
                            Convert.ToDecimal(reader["PV3"]),
                            reader["ATRIBUTO"].ToString(),
                            reader["VALOR_ATRIBUTO"].ToString(),
                            Convert.ToInt32(reader["PEDIDO_MINIMO"]),
                            reader["PACK"].ToString()));
                        }
                    }
                }
            }


            return Lista;
        }

        //Compsiciones de Base
        public static List<Composicion> GetComposiciones(Base @base)
        {
            List<Composicion> Lista = new List<Composicion>();

            using (var ctx = GetInstance())
            {
                //Selecciono todas las composiciones de la base 
                var query = "SELECT * FROM COMPOSICION WHERE TIPO = '" + @base.GetTipo() + "' AND BASE = '" + @base.GetId() + "'; ";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Lista.Add(new Composicion(
                            reader["ID"].ToString(),
                            reader["BASE"].ToString(),
                            reader["TIPO"].ToString(),
                            Convert.ToDecimal(reader["CANTIDAD"])));
                        }
                    }
                }
            }


            return Lista;
        }
        //Tarifas de Base
        public static List<Tarifa> GetTarifas(Base @base)
        {
            List<Tarifa> Lista = new List<Tarifa>();

            using (var ctx = GetInstance())
            {
                var query = "SELECT * FROM TARIFA WHERE TIPO = '" + @base.GetTipo() + "' AND BASE = '" + @base.GetId() + "' AND PACK = '"+@base.Getpack()+"'; ";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Lista.Add(new Tarifa(
                            reader["ID"].ToString(),
                            reader["BASE"].ToString(),
                            reader["TIPO"].ToString(),
                            Convert.ToDecimal(reader["PRECIO"]),
                            reader["PACK"].ToString()));
                        }
                    }
                }
            }
            return Lista;
        }
        
        //Composicion
        public static Composicion GetComposicion(string ID, string BASE, string TIPO)
        {
            Composicion composicion = null;
            using (var ctx = GetInstance())
            {
                var query = "SELECT * FROM COMPOSICION WHERE ID = '" + ID + "' AND TIPO = '" + TIPO + "' AND BASE = '" + BASE + "'; ";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            composicion = new Composicion(
                            reader["ID"].ToString(),
                            reader["BASE"].ToString(),
                            reader["TIPO"].ToString(),
                            Convert.ToDecimal(reader["CANTIDAD"]));
                        }
                    }
                }
            }
            return composicion;
        }
        public static void SetComposicion(Composicion composicion, bool Update)
        {
            using (var ctx = GetInstance())
            {
                string query;
                if (Update) query = "UPDATE COMPOSICION SET CANTIDAD = :CANTIDAD  WHERE ID = :ID AND BASE = :BASE  AND TIPO = :TIPO ;";
                else query =  "INSERT INTO COMPOSICION (ID,BASE,TIPO,CANTIDAD) VALUES (?,?,?,?);";

                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("ID", composicion.GetID()));
                    command.Parameters.Add(new SQLiteParameter("BASE", composicion.GetBase()));
                    command.Parameters.Add(new SQLiteParameter("TIPO", composicion.GetTipo()));
                    command.Parameters.Add(new SQLiteParameter("CANTIDAD", composicion.GetCantidad()));

                    command.ExecuteNonQuery();
                }

            }
        }
        public static void DeleteComposicion(Composicion composicion)
        {
            using (var ctx = GetInstance())
            {
                var query = "DELETE FROM COMPOSICION WHERE ID = :ID AND BASE = :BASE  AND TIPO = :TIPO ;";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("ID", composicion.GetID()));
                    command.Parameters.Add(new SQLiteParameter("BASE", composicion.GetBase()));
                    command.Parameters.Add(new SQLiteParameter("TIPO", composicion.GetTipo()));
                    command.ExecuteNonQuery();
                }
            }
        }


        //Diseño
        public static Diseño GetDiseño(string ID,string pack = "GENERAL")
        {
            Diseño diseño = null;
            using (var ctx = GetInstance())
            {
                var query = "SELECT * FROM DISEÑO WHERE ID = '" + ID + "' AND PACK = '"+pack+"'; ";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            diseño = new Diseño(
                            reader["ID"].ToString(),
                            reader["NOMBRE"].ToString(),
                            reader ["PACK"].ToString());
                        }
                    }
                }
            }
            return diseño;
        }
        public static void SetDiseño(Diseño diseño, bool Update)
        {
            using (var ctx = GetInstance())
            {
                string query;
                if (Update) query = "UPDATE DISEÑO SET NOMBRE = :NOMBRE WHERE ID = :ID AND PACK = :PACK ;";
                else query = "INSERT INTO DISEÑO (ID,NOMBRE,PACK) VALUES (?,?,?);";

                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("ID", diseño.GetID()));
                    command.Parameters.Add(new SQLiteParameter("NOMBRE", diseño.GetDescripcion()));
                    command.Parameters.Add(new SQLiteParameter("PACK", diseño.Getpack()));



                    command.ExecuteNonQuery();
                }

            }
        }
        public static void DeleteDiseño(Diseño diseño)
        {
            using (var ctx = GetInstance())
            {
                var query = "DELETE FROM DISEÑO WHERE ID = :ID AND PACK = :PACK ;";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("ID", diseño.GetID()));
                    command.Parameters.Add(new SQLiteParameter("PACK", diseño.Getpack()));

                    command.ExecuteNonQuery();
                }
            }
        }
        public static List<Diseño> GetDiseños(string pack = "GENERAL")
        {
            List<Diseño> Lista = new List<Diseño>();

            using (var ctx = GetInstance())
            {
                //Selecciono todas las composiciones de la base 
                var query = "SELECT * FROM DISEÑO WHERE PACK = '" + pack+"';";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Lista.Add(new Diseño(
                            reader["ID"].ToString(),
                            reader["NOMBRE"].ToString(),
                            reader["PACK"].ToString()));
                        }
                    }
                }
            }


            return Lista;
        }





        //ProdComposicion
        public static Modelos.Capa2.ProdComposicion GetProdComposicion(string ID)
        {
            Modelos.Capa2.ProdComposicion prodcomposicion = null;
            using (var ctx = GetInstance())
            {
                var query = "SELECT * FROM PROD_COMPOSICION WHERE ID = '" + ID + "'; ";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            prodcomposicion = new Modelos.Capa2.ProdComposicion(
                            reader["ID"].ToString(),
                            reader["DESCRIPCION"].ToString(),
                            Convert.ToDecimal(reader["PRECIO"]));
                        }
                    }
                }
            }
            return prodcomposicion;
        }
        public static void SetProdComposicion(Modelos.Capa2.ProdComposicion prodcomposicion, bool Update)
        {
            using (var ctx = GetInstance())
            {
                string query;
                if (Update) query = "UPDATE PROD_COMPOSICION SET DESCRIPCION = :DESCRIPCION ,PRECIO = :PRECIO WHERE ID = :ID ;";
                else query = "INSERT INTO PROD_COMPOSICION (ID,DESCRIPCION,PRECIO) VALUES (?,?,?);";

                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("ID", prodcomposicion.GetId()));
                    command.Parameters.Add(new SQLiteParameter("DESCRIPCION", prodcomposicion.GetDescripcion()));
                    command.Parameters.Add(new SQLiteParameter("PRECIO", prodcomposicion.GetPrecio()));
                    command.ExecuteNonQuery();
                }

            }
        }
        public static void DeleteProdComposicion(Modelos.Capa2.ProdComposicion prodcomposicion)
        {
            using (var ctx = GetInstance())
            {
                var query = "DELETE FROM PROD_COMPOSICION WHERE ID = :ID ;";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("ID", prodcomposicion.GetId()));
                    command.ExecuteNonQuery();
                }
            }
        }
        
        //Pueblo
        public static Pueblo GetPueblo(string ID)
        {
            Pueblo pueblo = null;
            using (var ctx = GetInstance())
            {
                var query = "SELECT * FROM PUEBLO WHERE ID = '" + ID + "'; ";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pueblo = new Pueblo(
                            reader["ID"].ToString(),
                            reader["NOMBRE"].ToString(),
                            reader["LOCALIDAD"].ToString());
                        }
                    }
                }
            }
            return pueblo;

        }
        public static void SetPueblo(Pueblo pueblo, bool Update)
        {
            using (var ctx = GetInstance())
            {
                string query;
                if (Update) query = "UPDATE PUEBLO SET NOMBRE = :NOMBRE ,LOCALIDAD = :LOCALIDAD WHERE ID = :ID ;";
                else query = "INSERT INTO PUEBLO (ID,NOMBRE,LOCALIDAD) VALUES (?,?,?);";

                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("ID", pueblo.GetID()));
                    command.Parameters.Add(new SQLiteParameter("NOMBRE", pueblo.GetNombre()));
                    command.Parameters.Add(new SQLiteParameter("LOCALIDAD", pueblo.GetLocalidad()));



                    command.ExecuteNonQuery();
                }

            }
        }
        public static void DeletePueblo(Pueblo pueblo)
        {
            using (var ctx = GetInstance())
            {
                var query = "DELETE FROM PUEBLO WHERE ID = :ID ;";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("ID", pueblo.GetID()));
                    command.ExecuteNonQuery();
                }
            }
        }

        //------------------------------------------------------------------------------------------------

        //Capa 3

        //Atributo
        public static Atributo GetAtributo(string ID)
        {
            Atributo atributo = null;
            using (var ctx = GetInstance())
            {
                var query = "SELECT * FROM ATRIBUTO WHERE ID = '" + ID+ "'; ";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    try
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                atributo = new Atributo(
                                    reader["ID"].ToString(),
                                    reader["DESCRIPCION"].ToString());
                            }
                        }
                    }
                    catch
                    {
                        return atributo;
                    }
                }
            }

            return atributo;
        }
        public static void SetAtributo(Atributo atributo, bool Update)
        {
            using (var ctx = GetInstance())
            {
                string query;
                if (Update) query = "UPDATE ATRIBUTO SET DESCRIPCION = :DESCRIPCION WHERE ID = :ID ;";
                else query = "INSERT INTO ATRIBUTO (ID,DESCRIPCION) VALUES (?,?);";
                
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("ID", atributo.Getid()));
                    command.Parameters.Add(new SQLiteParameter("DESCRIPCION", atributo.Getdescripcion()));
                    
                    command.ExecuteNonQuery();
                }
            }
        }
        public static void DeleteAtributo(Atributo atributo)
        {
            using (var ctx = GetInstance())
            {
                var query = "DELETE FROM ATRIBUTO WHERE ID = :ID ;";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("ID", atributo.Getid()));
                    command.ExecuteNonQuery();
                }
            }
        }
        public static List<Atributo> BuscarAtributos(string busqueda)
        {
            List<Atributo> Lista = new List<Atributo>();

            using (var ctx = GetInstance())
            {
                //Selecciono todas las composiciones de la base 

                var query = "SELECT * FROM ATRIBUTO WHERE DESCRIPCION LIKE '%" + busqueda + "%'";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Lista.Add(new Atributo(
                                reader["ID"].ToString(),
                                reader["DESCRIPCION"].ToString()));
                        }
                    }
                }
            }
            return Lista;
        }

        //Relaciones del Atributo
        public static List<RelAtributo> GetRelaciones(Atributo atributo)
        {
            List<RelAtributo> Lista = new List<RelAtributo>();

            using (var ctx = GetInstance())
            {
                //Selecciono todas las composiciones de la base 
                var query = "SELECT * FROM REL_ATRIBUTO WHERE ATRIBUTO = '" + atributo.Getid() + "' ;  ";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Lista.Add(new RelAtributo(
                            reader["ID"].ToString(),
                            reader["ATRIBUTO"].ToString(),
                            reader["NOMBRE"].ToString()));
                        }
                    }
                }
            }


            return Lista;
        }

        //Familia
        public static Familia GetFamilia(string ID)
        {
            Familia familia = null;
            using (var ctx = GetInstance())
            {
                var query = "SELECT * FROM FAMILIA WHERE ID = '" + ID + "' ; ";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    try
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                familia = new Familia(
                                reader["ID"].ToString(),
                                reader["DESCRIPCION"].ToString());
                            }
                        }
                    }
                    catch
                    {
                        return familia;
                    }
                }
            }

            return familia;
        }
        public static void SetFamilia(Familia familia, bool Update)
        {
            using (var ctx = GetInstance())
            {
                string query;
                if (Update) query = "UPDATE FAMILIA SET DESCRIPCION = :DESCRIPCION WHERE ID = :ID ;";
                else query = "INSERT INTO FAMILIA (ID,DESCRIPCION) VALUES (?,?);";

                    using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("ID", familia.GetID()));
                    command.Parameters.Add(new SQLiteParameter("DESCRIPCION", familia.GetDescripcion()));
                    command.ExecuteNonQuery();
                }
                
            }
        }
        public static void DeleteFamilia(Familia familia)
        {
            using (var ctx = GetInstance())
            {
                var query = "DELETE FROM FAMILIA WHERE ID = :ID ;";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("ID", familia.GetID()));
                    command.ExecuteNonQuery();
                }
            }
        }
        public static List<Familia> BuscarFamilias(string busqueda)
        {
            List<Familia> Lista = new List<Familia>();

            using (var ctx = GetInstance())
            {
                //Selecciono todas las composiciones de la base 

                var query = "SELECT * FROM FAMILIA WHERE DESCRIPCION LIKE '%" + busqueda + "%'";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Lista.Add(new Familia(
                                reader["ID"].ToString(),
                                reader["DESCRIPCION"].ToString()));
                        }
                    }
                }
            }
            return Lista;
        }

        //Localidad
        public static Localidad GetLocalidad(string ID)
        {
            Localidad localidad = null;
            using (var ctx = GetInstance())
            {
                var query = "SELECT * FROM LOCALIDAD WHERE ID = '" + ID + "' ; ";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    try
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                localidad = new Localidad(
                                reader["ID"].ToString(),
                                reader["NOMBRE"].ToString());
                            }
                        }
                    }
                    catch
                    {
                        return localidad;
                    }
                }
            }

            return localidad;
        }
        public static void SetLocalidad(Localidad localidad, bool Update)
        {
            using (var ctx = GetInstance())
            {
                string query;
                if (Update) query = "UPDATE LOCALIDAD SET NOMBRE = :NOMBRE WHERE ID = :ID ;";
                else query = "INSERT INTO LOCALIDAD (ID,NOMBRE) VALUES (?,?);";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("ID", localidad.GetID()));
                    command.Parameters.Add(new SQLiteParameter("NOMBRE", localidad.GetNombre()));
                    command.ExecuteNonQuery();
                }
            }
        }
        public static void DeleteLocalidad(Localidad localidad)
        {
            using (var ctx = GetInstance())
            {
                var query = "DELETE FROM LOCALIDAD WHERE ID = :ID";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("ID", localidad.GetID()));
                    command.ExecuteNonQuery();
                }
            }
        }
        public static List<Localidad> BuscarLocalidades(string busqueda)
        {
            List<Localidad> Lista = new List<Localidad>();

            using (var ctx = GetInstance())
            {
                //Selecciono todas las composiciones de la base 
                
                var query = "SELECT * FROM LOCALIDAD WHERE NOMBRE LIKE '%"+busqueda+"%'";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Lista.Add(new Localidad(
                                reader["ID"].ToString(),
                                reader["NOMBRE"].ToString()));
                        }
                    }
                }
            }
            return Lista;
        }
        //RelAtributo
        public static RelAtributo GetRelAtributo(string ID, string Atributo)
        {
            RelAtributo relatributo = null;
            using (var ctx = GetInstance())
            {
                
                var query = "SELECT * FROM REL_ATRIBUTO WHERE ID = '" + ID + "' AND ATRIBUTO = '" + Atributo +"' ; ";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    try
                    {

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            relatributo = new RelAtributo(
                            reader["ID"].ToString(),
                            reader["ATRIBUTO"].ToString(),
                            reader["NOMBRE"].ToString());
                        }
                    }
                    }
                    catch
                    {
                        return relatributo;
                    }

                }
            }

            return relatributo;

        }
        public static void SetRelAtributo(RelAtributo relatributo, bool Update)
        {
            using (var ctx = GetInstance())
            {
                string query;
                if (Update) query = "UPDATE REL_ATRIBUTO SET NOMBRE = :NOMBRE WHERE ID = :ID AND ATRIBUTO = :ATRIBUTO ;";
                else query = "INSERT INTO REL_ATRIBUTO (ID,ATRIBUTO,NOMBRE) VALUES (?,?,?);";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("ID", relatributo.Getid()));
                    command.Parameters.Add(new SQLiteParameter("ATRIBUTO", relatributo.Getatributo()));
                    command.Parameters.Add(new SQLiteParameter("NOMBRE", relatributo.GetNombre()));
                    command.ExecuteNonQuery();
                }
            }
        }
        public static void DeleteRelAtributo(RelAtributo relatributo)
        {
            using (var ctx = GetInstance())
            {
                var query = "DELETE FROM REL_ATRIBUTO WHERE ID = :ID AND ATRIBUTO = :ATRIBUTO ;";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("ID", relatributo.Getid()));
                    command.Parameters.Add(new SQLiteParameter("ATRIBUTO", relatributo.Getatributo()));
                    command.ExecuteNonQuery();
                }
            }
        }
        public static List<RelAtributo> BuscarRelAtributos(string busqueda,string Atributo)
        {
            List<RelAtributo> Lista = new List<RelAtributo>();

            using (var ctx = GetInstance())
            {
                //Selecciono todas las composiciones de la base 

                var query = "SELECT * FROM REL_ATRIBUTO WHERE NOMBRE LIKE '%" + busqueda + "%' AND ATRIBUTO = '"+Atributo+"'";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Lista.Add(new RelAtributo(
                                reader["ID"].ToString(),
                                reader["ATRIBUTO"].ToString(),
                                reader["NOMBRE"].ToString()));
                        }
                    }
                }
            }
            return Lista;
        }

        //Seccion
        public static Seccion GetSeccion(string ID)
        {
            Seccion seccion = null;
            using (var ctx = GetInstance())
            {
                var query = "SELECT * FROM SECCION WHERE ID = '" + ID + "'; ";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    try
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                seccion = new Seccion(
                                    reader["ID"].ToString(),
                                    reader["DESCRIPCION"].ToString(),
                                    reader["UBICACION"].ToString());
                            }
                        }
                    }
                    catch
                    {
                        return seccion;
                    }
                }
            }

            return seccion;

        }
        public static void SetSeccion(Seccion seccion, bool Update)
        {
            using (var ctx = GetInstance())
            {
                string query;
                if (Update) query = "UPDATE SECCION SET DESCRIPCION = :DESCRIPCION ,UBICACION = :UBICACION WHERE ID =:ID ;";
                else query = "INSERT INTO SECCION (ID,DESCRIPCION,UBICACION) VALUES (?,?,?);";

                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("ID", seccion.GetID()));
                    command.Parameters.Add(new SQLiteParameter("DESCRIPCION", seccion.GetDescripcion()));
                    command.Parameters.Add(new SQLiteParameter("UBICACION", seccion.GetUbicacion()));

                    command.ExecuteNonQuery();
                }
            }
        }
        public static void DeleteSeccion(Seccion seccion)
        {
            using (var ctx = GetInstance())
            {
                var query = "DELETE FROM SECCION WHERE ID =:ID ;";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("ID", seccion.GetID()));
                    command.ExecuteNonQuery();
                }
            }
        }
        public static List<Seccion> BuscarSecciones(string busqueda)
        {
            List<Seccion> Lista = new List<Seccion>();

            using (var ctx = GetInstance())
            {
                //Selecciono todas las composiciones de la base 

                var query = "SELECT * FROM SECCION WHERE DESCRIPCION LIKE '%" + busqueda + "%'";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Lista.Add(new Seccion(
                                reader["ID"].ToString(),
                                reader["DESCRIPCION"].ToString(),
                                reader["UBICACION"].ToString()));
                        }
                    }
                }
            }
            return Lista;
        }

        //Tarifa
        public static Tarifa GetTarifa(string ID, string BASE, string TIPO, string PACK)
        {
            Tarifa tarifa = null;
            using (var ctx = GetInstance())
            {
                var query = "SELECT * FROM TARIFA WHERE PACK = '"+ PACK + "' AND ID = '" + ID + "' AND TIPO = '" + TIPO + "' AND BASE = '" + BASE + "'; ";
                using (var command = new SQLiteCommand(query, ctx))
                {
                   
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tarifa = new Tarifa(
                            reader["ID"].ToString(),
                            reader["BASE"].ToString(),
                            reader["TIPO"].ToString(),
                            Convert.ToDecimal(reader["PRECIO"]), 
                            reader["PACK"].ToString()) ;
                        }
                    }
                }
            }
            return tarifa;
        }
        public static void SetTarifa(Tarifa tarifa, bool Update)
        {
            using (var ctx = GetInstance())
            {
                string query;
                if (Update) query = "UPDATE TARIFA SET PRECIO = :CANTIDAD  WHERE ID = :ID AND BASE = :BASE  AND TIPO = :TIPO AND PACK = :PACK ;";
                else query = "INSERT INTO TARIFA (PACK,ID,BASE,TIPO,PRECIO) VALUES (?,?,?,?,?);";

                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("PACK", tarifa.Getpack()));
                    command.Parameters.Add(new SQLiteParameter("ID", tarifa.GetID()));
                    command.Parameters.Add(new SQLiteParameter("BASE", tarifa.GetBase()));
                    command.Parameters.Add(new SQLiteParameter("TIPO", tarifa.GetTipo()));
                    command.Parameters.Add(new SQLiteParameter("PRECIO", tarifa.GetPrecio()));

                    command.ExecuteNonQuery();
                }

            }
        }
        public static void DeleteTarifa(Tarifa tarifa)
        {
            using (var ctx = GetInstance())
            {
                var query = "DELETE FROM TARIFA WHERE ID = :ID AND BASE = :BASE  AND TIPO = :TIPO AND PACK = :PACK;";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("PACK", tarifa.Getpack()));
                    command.Parameters.Add(new SQLiteParameter("ID", tarifa.GetID()));
                    command.Parameters.Add(new SQLiteParameter("BASE", tarifa.GetBase()));
                    command.Parameters.Add(new SQLiteParameter("TIPO", tarifa.GetTipo()));
                    command.ExecuteNonQuery();
                }
            }
        }

        //------------------------------------------------------------------------------------------------


    }
}
