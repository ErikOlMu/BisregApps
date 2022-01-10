using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BisregApi.Utilidades
{
    public class XmlDocument
    {
        //Nombre del Archivo por defecto Config.conf
        public string file = "file.xml";
        //Serializar Config
        public void Save()
        {
            //Si no existe crearlo
            if (!File.Exists(file));

            XmlSerializer serializer = new XmlSerializer(GetType());

            StreamWriter writer = new StreamWriter(file);
            serializer.Serialize(writer, this);
            writer.Close();

        }

        //Deserializar Config
        public static object getDocument(string File, Type type)
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
                return new XmlDocument();
            }
        }
    }
}
