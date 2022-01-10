using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BisregApi.SQLite.Tipos;

namespace BisregApi.SQLite
{
    public class Atributo
    {
        public Atributo(string campo, object valor)
        {
            Campo = campo;
            Valor = valor;
        }

        public string Campo { get; set; }
        public object Valor { get; set; }
    }
    public class GestorBDD
    {
        private string pathDB;
        SQLiteConnection db;

        //Generar las tablas apartir de los objectos
        public void AutoGenerarTablasSQL(params Type[] tipos)
        {
            string query = "";
            string primaryquery = "";

            foreach (Type tipo in tipos)
            {
                primaryquery = "PRIMARY KEY(";
                query += "CREATE TABLE \"" + tipo.Name + "\" ( ";

                foreach (PropertyInfo property in tipo.GetProperties())
                {
                    String Nombre = "";
                    if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                       Nombre = property.PropertyType.GetGenericArguments()[0].Name;
                    }
                    else
                    {
                        Nombre = property.PropertyType.Name;
                    }
                    switch (Nombre)
                    {
                        case nameof(PrimaryInt):
                            query += '"' + property.Name +"\" NUMERIC NOT NULL,";
                            primaryquery += '"' + property.Name + '"' + ",";
                            break;
                        case nameof(PrimaryString):
                            query += '"' + property.Name + "\" TEXT NOT NULL,";
                            primaryquery += '"' + property.Name + '"' + ",";
                            break;
                        case nameof(String):
                            query += '"' + property.Name + "\" TEXT,";
                            break;
                        case nameof(Int64):
                            query += ('"' + property.Name + "\" NUMERIC,");
                            break;
                        default:
                            query += ('"' + property.Name + "\" BLOB,");
                            break;
                    }
                }

                primaryquery = primaryquery.TrimEnd(',');
                primaryquery += "));";
                query += primaryquery;



            }

            EjecutarSQL(query);
        }

        public GestorBDD(string Path)
        {
            pathDB = Path;
            //Creo la base de datos si no existe
            CrearBDD();

            //Obtengo la Instancia a la base de datos
            db = GetInstance();
        }
        
        //Ejecutar un Archivo SQL insertando la ruta 
        public void EjecutarArchivoSQL(string FilePath)
        {
            using (var reader = new StreamReader(FilePath))
            {
                var query = "";
                var line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    query += line;
                }

                //Ejecutar el Archivo
                EjecutarSQL(query);
            }
        }
        //Ejecutar Cadena SQL
        public void EjecutarSQL(string query)
        {
            new SQLiteCommand(query, db).ExecuteNonQuery();
        }
        //Crear el fichero sqlite
        public void CrearBDD()
        {
            //Compruebo si la Base de Datos existe en caso que no exista creo la base de datos
            if (!File.Exists(pathDB))
            {
                SQLiteConnection.CreateFile(pathDB);
                //EjecutarArchivoSQL(SQLInicio);
            }
        }
        //Connexion SQL
        public SQLiteConnection GetInstance()
        {
            try
            {
                SQLiteConnection db = new SQLiteConnection("Data Source=" + pathDB + ";Version=3;");
                db.Open();
                return db;
            }
            catch
            {
                //Excepcion no encuentra la Base de Datos
                return null;
            }
        }
        //Select a partir de un objeto database con los parametros de busqueda claves primarias
        public List<DatabaseItem> SelectDatabaseItem(DatabaseItem ItemSelect)
        {
            List<DatabaseItem> SelectList = new List<DatabaseItem>();

            Type type = ItemSelect.GetType();

            DatabaseItem instance = (DatabaseItem)Activator.CreateInstance(type);

            string NombreTabla = instance.GetType().Name;
            List<Atributo> AtributosSelect = new List<Atributo>();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                //Recojo los valores que no sean null
                if (property.GetValue(ItemSelect) != null)
                {
                    //Si el tipo es una de las claves primarias recojo el valor
                    switch (property.PropertyType.Name)
                    {
                        case nameof(PrimaryInt):
                            AtributosSelect.Add(new Atributo(property.Name, (property.GetValue(ItemSelect) as PrimaryInt).valor));
                            break;
                        case nameof(PrimaryString):
                            AtributosSelect.Add(new Atributo(property.Name, (property.GetValue(ItemSelect) as PrimaryString).valor));
                            break;
                        //Si es cualquier otro lo añado como atributos normales
                        default:
                            AtributosSelect.Add(new Atributo(property.Name, property.GetValue(ItemSelect)));
                            break;
                    }
                }
            }

            //Crear Query
            using (var ctx = db)
            {
                //Creo el query de insert
                string query = "SELECT * FROM " + NombreTabla + " WHERE ";

                //bool para controlar el primer AND
                bool primerAND = true;
                foreach (Atributo atributo in AtributosSelect)
                {
                    if (!primerAND) query += " AND ";
                    query += atributo.Campo + " = :"+atributo.Campo;
                    if (primerAND) primerAND = false;
                }
                query += ";";


                using (var command = new SQLiteCommand(query, ctx))
                {
                    foreach (Atributo atributo in AtributosSelect)
                    {
                        command.Parameters.Add(new SQLiteParameter(atributo.Campo, atributo.Valor));
                    }
                    try
                    {
                        using(var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //Clono el ItemSelect para tener las caracteristicas de su herencia
                                DatabaseItem item = ItemSelect.Clone() as DatabaseItem;
                                foreach(PropertyInfo property in properties)
                                {
                                    switch (property.PropertyType.Name)
                                    {
                                        case nameof(PrimaryInt):
                                            property.SetValue(item, new PrimaryInt(Convert.ToInt32(reader[property.Name])));
                                            break;
                                        case nameof(PrimaryString):
                                            property.SetValue(item, new PrimaryString(reader[property.Name].ToString()));
                                            break;
                                        default:
                                            property.SetValue(item, reader[property.Name]);
                                            break;
                                    }
                                }
                                SelectList.Add(item);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //Excpcion por si no funciona el insert

                        MessageBox.Show("Error de compatibilidad con Base de Datos:" + Environment.NewLine + ex.Message);
                    }

                }
            }


            return SelectList;
           
        }
        //Eliminar un ObjetoDatabase
        public void DeleteDatabaseItem(DatabaseItem ItemSelect)
        {

            Type type = ItemSelect.GetType();

            DatabaseItem instance = (DatabaseItem)Activator.CreateInstance(type);

            string NombreTabla = instance.GetType().Name;
            List<Atributo> AtributosPrimarios = new List<Atributo>();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                //Recojo los valores que no sean null
                if (property.GetValue(ItemSelect) != null)
                {
                    //Si el tipo es una de las claves primarias recojo el valor
                    switch (property.PropertyType.Name)
                    {
                        case nameof(PrimaryInt):
                            AtributosPrimarios.Add(new Atributo(property.Name, (property.GetValue(ItemSelect) as PrimaryInt).valor));
                            break;
                        case nameof(PrimaryString):
                            AtributosPrimarios.Add(new Atributo(property.Name, (property.GetValue(ItemSelect) as PrimaryString).valor));
                            break;
                        //Si es cualquier otro no lo añado
                        default:
                            break;
                    }
                }
            }

            //Crear Query
            using (var ctx = db)
            {
                //Creo el query de insert
                string query = "DELETE FROM " + NombreTabla + " WHERE ";

                //bool para controlar el primer AND
                bool primerAND = true;
                foreach (Atributo atributo in AtributosPrimarios)
                {
                    if (!primerAND) query += " AND ";
                    query += atributo.Campo + " = :" + atributo.Campo;
                    if (primerAND) primerAND = false;
                }
                query += ";";


                using (var command = new SQLiteCommand(query, ctx))
                {
                    foreach (Atributo atributo in AtributosPrimarios)
                    {
                        command.Parameters.Add(new SQLiteParameter(atributo.Campo, atributo.Valor));
                    }
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        //Excpcion por si no funciona el insert

                        MessageBox.Show("Error de compatibilidad con Base de Datos:" + Environment.NewLine + ex.Message);
                    }

                }
            }



        }
        //Insert de un ObjetoDatabase
        public void InsertDatabaseItem(DatabaseItem Item)
        {
            Type type = Item.GetType();
            DatabaseItem instance = (DatabaseItem)Activator.CreateInstance(type);

            string NombreTabla = instance.GetType().Name;
            List<Atributo> Atributos = new List<Atributo>();


            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                //Si el tipo es una de las claves primarias recojo el valor
                switch (property.PropertyType.Name)
                {
                    case nameof(PrimaryInt):
                        Atributos.Add(new Atributo(property.Name, (property.GetValue(Item) as PrimaryInt).valor));
                        break;
                    case nameof(PrimaryString):
                        Atributos.Add(new Atributo(property.Name, (property.GetValue(Item) as PrimaryString).valor));
                        break;
                //Si es cualquier otro lo añado como atributos normales
                    default:
                        Atributos.Add(new Atributo(property.Name, property.GetValue(Item)));
                        break;
                }
            }


            using(var ctx = db)
            {
                //Creo el query de insert
                string query = "INSERT INTO " + NombreTabla + " (";
                string queryaux = "VALUES (";
                foreach (Atributo atributo in Atributos)
                {
                    query += atributo.Campo + ",";
                    queryaux += "?,";
                }

                //Elimino la ultima "," y añado un ")"
                query = query.TrimEnd(',');
                query += ") ";
                queryaux = queryaux.TrimEnd(',');
                queryaux += ") ;";

                //Y las concateno
                query += queryaux;

                using (var command = new SQLiteCommand(query, ctx))
                {
                    foreach (Atributo atributo in Atributos)
                    {
                        command.Parameters.Add(new SQLiteParameter(atributo.Campo, atributo.Valor));
                    }
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                        //Excpcion por si no funciona el insert

                        MessageBox.Show("Error de compatibilidad con Base de Datos:"+ Environment.NewLine + ex.Message);
                    }

                }
            }

        }
        //Update de un ObjetoDatabase
        public void UpdateDatabaseItem(DatabaseItem Item)
        {
            Type type = Item.GetType();
            DatabaseItem instance = (DatabaseItem)Activator.CreateInstance(type);

            string NombreTabla = instance.GetType().Name;
            List<Atributo> AtributosPrimarios = new List<Atributo>();

            List<Atributo> Atributos = new List<Atributo>();


            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                //Si el tipo es una de las claves primarias lo añado a AtributosPrimarios
                switch (property.PropertyType.Name)
                {
                    case nameof(PrimaryInt):
                        AtributosPrimarios.Add(new Atributo(property.Name, (property.GetValue(Item) as PrimaryInt).valor));
                        break;
                    case nameof(PrimaryString):
                        AtributosPrimarios.Add(new Atributo(property.Name, (property.GetValue(Item) as PrimaryString).valor));
                        break;
                    //Si es cualquier otro lo añado como atributos normales
                    default:
                        Atributos.Add(new Atributo(property.Name, property.GetValue(Item)));
                        break;
                }
            }


            using (var ctx = db)
            {
                //Creo el query de Update
                string query = "UPDATE " + NombreTabla + " SET ";
                foreach (Atributo atributo in Atributos)
                {
                    query += atributo.Campo + " = :"+atributo.Campo+" ,";
                }

                query = query.TrimEnd(',');
                query += " WHERE ";

                //bool para controlar el primer AND
                bool primerAND = true;
                foreach (Atributo atributo in AtributosPrimarios)
                {
                    if (!primerAND) query += " AND ";
                    query += atributo.Campo + " = :" + atributo.Campo;
                    if (primerAND) primerAND = false;
                }

                query += ";";




                using (var command = new SQLiteCommand(query, ctx))
                {
                    foreach (Atributo atributo in Atributos)
                    {
                        command.Parameters.Add(new SQLiteParameter(atributo.Campo, atributo.Valor));
                    }
                    foreach (Atributo atributo in AtributosPrimarios)
                    {
                        command.Parameters.Add(new SQLiteParameter(atributo.Campo, atributo.Valor));
                    }
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        //Excpcion por si no funciona el insert

                        MessageBox.Show("Error de compatibilidad con Base de Datos:" + Environment.NewLine + ex.Message);
                    }

                }
            }
        }
        //Obtener nombres de tablas
        public List<string> GetTables()
        {
            List<string> Lista = new List<string>();

            using (var ctx = db)
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
        //Obtener Columnas de una tabla
        public List<string> GetColumnas(string Tabla)
        {
            List<string> Lista = new List<string>();
            using (var ctx = db)
            {
                //Selecciono todas las composiciones de la base 
                var query = "PRAGMA TABLE_INFO(" + Tabla + ");";
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
        //Obtener valores de una Tabla
        public List<List<string>> GetValoresTabla(string Tabla)
        {
            List<List<string>> Lista = new List<List<string>>();

            using (var ctx = db)
            {
                //Selecciono todas las composiciones de la base 
                var query = "SELECT * FROM " + Tabla;
                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            List<string> linea = new List<string>();
                            foreach (string columna in GetColumnas(Tabla))
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
        
    }
}
