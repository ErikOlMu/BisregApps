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
        //Serializar XML
        public void Save(string file)
        {
            //Si no existe crearlo
            if (!File.Exists(file)) File.Create(file);

            XmlSerializer serializer = new XmlSerializer(GetType());

            StreamWriter writer = new StreamWriter(file);
            serializer.Serialize(writer, this);
            writer.Close();

        }

        //Deserializar XML
        public object getDocument(string File, Type type)
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
