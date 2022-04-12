using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace BisregApi.Utilidades
{
    //Classe para crear configuraciones y guardarlas
    public class Config
    {


        //Nombre del Archivo por defecto Config.conf
        public static string file = "Config.conf";

        public static string DirectorioAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + AppDomain.CurrentDomain.FriendlyName.Replace(".exe", "") + "\\";
        //Serializar Config
     
        public void Save()
        {
            string tmp = DirectorioAppData + file;
            //Si no existe crearlo
            if (!File.Exists(tmp)) File.Create(tmp).Close();

            XmlSerializer serializer = new XmlSerializer(GetType());

            StreamWriter writer = new StreamWriter(tmp);
            serializer.Serialize(writer, this);
            writer.Close();

        }

        


        //Deserializar Config
        public static object getConfig(string File, Type type)
        {
            XmlSerializer serializer = new XmlSerializer(type);
            try
            {
                using (FileStream fs = new FileStream(DirectorioAppData + file, FileMode.Open))
                {
                    return serializer.Deserialize(fs);
                }
            }
            catch (Exception)
            {
                return new Config();
            }
        }



    }
}
