using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BisregApi.SQLite
{
    

    //Clase Atributo para la Base de datos
    public class CampoSQL
    {
        public CampoSQL(string campo, object valor)
        {
            this.campo = campo;
            Valor = valor;
        }

        public string campo { get; set; }
        public object Valor { get; set; }
    }
    public class GestorBDD
    {
        private string pathDB;
        //Metodo para clonar objetos genericos
        public static T Clone<T>(T original)
        {
            T newObject = (T)Activator.CreateInstance(original.GetType());

            foreach (var originalProp in original.GetType().GetProperties())
            {
                originalProp.SetValue(newObject, originalProp.GetValue(original));
            }

            return newObject;
        }
        //Constructor gestor
        public GestorBDD(string Path)
        {
            pathDB = Path;
            //Creo la base de datos si no existe
            CrearBDD();

        }
        //Obtener campos
        private List<CampoSQL> GetCampos<T>(T Item)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            List<CampoSQL> Campos = new List<CampoSQL>();
            foreach (PropertyInfo property in properties)
            {
                //Obtengo el atributo SQLAtribute para comprobar si el campo es un campo SQL
                CampoSQLAttribute Atributo = (CampoSQLAttribute)Attribute.GetCustomAttribute(property, typeof(CampoSQLAttribute));
                if (Atributo != null) Campos.Add(new CampoSQL(property.Name, property.GetValue(Item)));
            }
            return Campos;
        }
        private List<CampoSQL> GetCamposNoNull<T>(T Item)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            List<CampoSQL> Campos = new List<CampoSQL>();
            foreach (PropertyInfo property in properties)
            {
                //Obtengo el atributo SQLAtribute para comprobar si el campo es un campo SQL
                CampoSQLAttribute Atributo = (CampoSQLAttribute)Attribute.GetCustomAttribute(property, typeof(CampoSQLAttribute));
                if (Atributo != null && property.GetValue(Item)!= null) Campos.Add(new CampoSQL(property.Name, property.GetValue(Item)));
            }
            return Campos;
        }
        //Obtener campos primarios
        private List<CampoSQL> GetCamposPrimarios<T>(T Item)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            List<CampoSQL> Campos = new List<CampoSQL>();
            foreach (PropertyInfo property in properties)
            {
                //Obtengo el atributo SQLAtribute para comprobar si el campo es un campo SQL
                CampoSQLAttribute Atributo = (CampoSQLAttribute)Attribute.GetCustomAttribute(property, typeof(CampoSQLAttribute));
                if (Atributo != null && Atributo.PrimaryKey) Campos.Add(new CampoSQL(property.Name, property.GetValue(Item)));
            }
            return Campos;
        }
        //Obtener campos no primarios
        private List<CampoSQL> GetCamposNoPrimarios<T>(T Item)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            List<CampoSQL> Campos = new List<CampoSQL>();
            foreach (PropertyInfo property in properties)
            {
                //Obtengo el atributo SQLAtribute para comprobar si el campo es un campo SQL
                CampoSQLAttribute Atributo = (CampoSQLAttribute)Attribute.GetCustomAttribute(property, typeof(CampoSQLAttribute));
                if (Atributo != null && !Atributo.PrimaryKey) Campos.Add(new CampoSQL(property.Name, property.GetValue(Item)));
            }
            return Campos;
        }
        //Agregar Parametros al query
        private void EjecutarQueryConParametrosSQL(List<CampoSQL> campos, string query, SQLiteConnection ctx)
        {
            //Agregar parametros al query
            using (var command = new SQLiteCommand(query, ctx))
            {
                foreach (CampoSQL atributo in campos)
                {
                    command.Parameters.Add(new SQLiteParameter(atributo.campo, atributo.Valor));
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
        //Generar las tablas apartir de los objectos
        public void AutoGenerarTablasSQL(params Type[] tipos)
        {
            string query = "";
            string primaryquery = "";
            string foreginquery = "";

            //Bucle de Tipos que hay que añadir tablas
            foreach (Type tipo in tipos)
            {
                //Iniciacion de los query
                primaryquery = "PRIMARY KEY(";
                query += "CREATE TABLE \"" + tipo.Name + "\" ( ";

                //Query Foregin Key por si añado alguna clave Foranea
                foreginquery = "";

                //Bucle de propiedades de cada tipo
                foreach (PropertyInfo property in tipo.GetProperties())
                {
                    //Obtengo el atributo SQLAtribute para comprobar si el campo es un campo SQL
                    CampoSQLAttribute Atributo = (CampoSQLAttribute)Attribute.GetCustomAttribute(property, typeof(CampoSQLAttribute));

                    //Compruebo que no sea null, en ese caso paso al siguiente campo
                    if (Atributo != null)
                    {
                        //Obtengo el Nombre del tipo de campo, en caso que sea un int, tiene que ser notNull por las busquedas
                        String Nombre = "";
                        if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        {
                            Nombre = property.PropertyType.GetGenericArguments()[0].Name;
                        }
                        else
                        {
                            Nombre = property.PropertyType.Name;
                        }


                        //Miro si es ClavePrimaria
                        if (Atributo.PrimaryKey)
                        {
                            //Y añado a la query de clave primaria
                            primaryquery += '"' + property.Name + '"' + ",";

                        }

                        //Miro que tipo de campo es
                        switch (Nombre)
                        {
                            case nameof(String):
                                query += '"' + property.Name + "\" TEXT ";
                                break;
                            case nameof(Int64):
                                query += '"' + property.Name + "\" NUMERIC ";
                                break;
                            default:
                                //En caso que no sea ni int ni String intento añadirlo como blob
                                query += '"' + property.Name + "\" BLOB ";
                                break;
                        }

                        //Miro si tiene la opcion UNIQUE, NOTNULL, DEFAULT o CHECK
                        if (Atributo.NotNull) query += "NOT NULL ";
                        if (Atributo.Default != null) query += "DEFAULT " + Atributo.Default + " ";
                        if (Atributo.Check != null) query += "CHECK(" + Atributo.Check + ") ";
                        if (Atributo.Unique) query += "UNIQUE ";



                        //Y añado la coma del final
                        query += ",";


                        //Compruebo que sea una clave Foranea
                        if (Atributo.ForeginKey && Atributo.ForeginTable != null && Atributo.ForeginCampo != null)
                        {
                            //Si es una clave foranea añado el query ForeignKey
                            foreginquery += "FOREIGN KEY(\"" + property.Name + "\") REFERENCES \"" + Atributo.ForeginTable.Name + "\"(\"" + Atributo.ForeginCampo + "\"), ";
                        }
                    }
                }

                    //Quito el final sobrante y concateno los dos query

                    primaryquery = primaryquery.TrimEnd(',');
                    primaryquery += "));";
                    query += foreginquery;
                    query += primaryquery;
                
            }

            EjecutarSQL(query);
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
            new SQLiteCommand(query, GetInstance()).ExecuteNonQuery();
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
        public List<T> SelectDatabaseItem<T>(T ItemSelect)
        {
            List<T> SelectList = new List<T>();

            //Obtengo el nombre de la tabla y de los campos
            string NombreTabla = typeof(T).Name;
            List<CampoSQL> CamposSelect = GetCamposNoNull(ItemSelect);


            //Crear Query
            using (var ctx = GetInstance())
            {
                //Creo el query de insert
                string query = "SELECT * FROM " + NombreTabla + " WHERE ";

                //bool para controlar el primer AND
                bool primerAND = true;
                foreach (CampoSQL atributo in CamposSelect)
                {
                    if (!primerAND) query += " AND ";
                    query += atributo.campo + " = :" + atributo.campo;
                    if (primerAND) primerAND = false;
                }

                //Quito el WHERE por si no hay atributos y queremos toda la tabla
                query = query.TrimEnd("WHERE ".ToCharArray());

                query += ";";


                using (var command = new SQLiteCommand(query, ctx))
                {
                    foreach (CampoSQL atributo in CamposSelect)
                    {
                        command.Parameters.Add(new SQLiteParameter(atributo.campo, atributo.Valor));
                    }
                    try
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //Clono el ItemSelect para tener las caracteristicas de su herencia
                                T item = Clone<T>(ItemSelect);
                                foreach (PropertyInfo property in typeof(T).GetProperties())
                                {
                                    //Obtengo el atributo SQLAtribute para comprobar si el campo es un campo SQL
                                    CampoSQLAttribute Atributo = (CampoSQLAttribute)Attribute.GetCustomAttribute(property, typeof(CampoSQLAttribute));
                                    if (Atributo != null) property.SetValue(item, reader[property.Name]);   
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
        public void DeleteDatabaseItem<T>(T Item)
        {
            //Obtengo los campos primarios y el nombre de la tabla
            string NombreTabla = typeof(T).Name;
            List<CampoSQL> CamposPrimarios = GetCamposPrimarios(Item);

            //Crear Query
            using (var ctx = GetInstance())
            {
                //Creo el query de insert
                string query = "DELETE FROM " + NombreTabla + " WHERE ";

                //bool para controlar el primer AND
                bool primerAND = true;
                foreach (CampoSQL atributo in CamposPrimarios)
                {
                    if (!primerAND) query += " AND ";
                    query += atributo.campo + " = :" + atributo.campo;
                    if (primerAND) primerAND = false;
                }
                query += ";";


                EjecutarQueryConParametrosSQL(CamposPrimarios, query, ctx);

            }
        }
        //Insert de un ObjetoDatabase
        public void InsertDatabaseItem<T>(T Item)
        {

            string NombreTabla = typeof(T).Name;
            List<CampoSQL> Campos = GetCampos(Item);


            using (var ctx = GetInstance())
            {
                //Creo el query de insert
                string query = "INSERT INTO " + NombreTabla + " (";
                string queryaux = "VALUES (";
                foreach (CampoSQL atributo in Campos)
                {
                    query += atributo.campo + ",";
                    queryaux += "?,";
                }

                //Elimino la ultima "," y añado un ")"
                query = query.TrimEnd(',');
                query += ") ";
                queryaux = queryaux.TrimEnd(',');
                queryaux += ") ;";

                //Y las concateno
                query += queryaux;

                EjecutarQueryConParametrosSQL(Campos, query, ctx);
               
            }

        }
        public void InsertDatabaseItem<T>(List<T> Items)
        {
            foreach(T t in Items)
            {
                UpdateDatabaseItem(t);
            }
        }      
        //Update de un ObjetoDatabase
        public void UpdateDatabaseItem<T>(T Item)
        {

            //Obtengo los nombre de la tabla y de los campos primarios y no primarios
            string NombreTabla = typeof(T).Name;
            List<CampoSQL> CamposPrimarios = GetCamposPrimarios(Item);
            List<CampoSQL> Campos = GetCamposNoPrimarios(Item);

                                
            //Crear Query Update
            using (var ctx = GetInstance())
            {
                //Creo el query de Update
                string query = "UPDATE " + NombreTabla + " SET ";
                foreach (CampoSQL atributo in Campos)
                {
                    query += atributo.campo + " = :" + atributo.campo + " ,";
                }

                query = query.TrimEnd(',');
                query += " WHERE ";

                //bool para controlar el primer AND
                bool primerAND = true;
                foreach (CampoSQL atributo in CamposPrimarios)
                {
                    if (!primerAND) query += " AND ";
                    query += atributo.campo + " = :" + atributo.campo;
                    if (primerAND) primerAND = false;
                }

                query += ";";

                //Añado los campos y ejecuto el query
                EjecutarQueryConParametrosSQL(GetCampos(Item),query,ctx);
            }
        }
        //Bucle update DatabaseItemLista
        public void UpdateDatabaseItem<T>(List<T> items)
        {
            foreach(T t in items)
            {
                UpdateDatabaseItem(t);
            }
        }
        //Comprobar si existe
        public bool ExistItem<T>(T item)
        {
            bool algunnull = false;

            //Comporuebo que no haya valores null
            foreach (CampoSQL campo in GetCamposPrimarios(item))
            {
                if (campo.Valor == null) algunnull = true;
            }

            return SelectDatabaseItem(item).Count <= 0 && !algunnull;

        }
        //Obtener nombres de tablas
        public List<string> GetTables()
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
        //Obtener Columnas de una tabla
        public List<string> GetColumnas(string Tabla)
        {
            List<string> Lista = new List<string>();
            using (var ctx = GetInstance())
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

            using (var ctx = GetInstance())
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
