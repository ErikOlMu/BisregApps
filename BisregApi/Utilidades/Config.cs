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
        public string File = "Config.conf";

        //Serializar Config
        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(GetType());

            StreamWriter writer = new StreamWriter(File);
            serializer.Serialize(writer, this);
            writer.Close();
        }


        //Deserializar Config
        public static object getConfig(string File, Type type)
        {
            XmlSerializer serializer = new XmlSerializer(type);
            try
            {
                using (FileStream fs = new FileStream(File, FileMode.Open))
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
