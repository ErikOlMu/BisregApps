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
        public string file = "Config.conf";
        //Serializar Config
        public void Save()
        {
            //Si no existe crearlo
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + AppDomain.CurrentDomain.FriendlyName.Replace(".exe",""))) Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + AppDomain.CurrentDomain.FriendlyName.Replace(".exe", ""));

            XmlSerializer serializer = new XmlSerializer(GetType());

            StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + AppDomain.CurrentDomain.FriendlyName.Replace(".exe", "") + "\\" +file);
            serializer.Serialize(writer, this);
            writer.Close();

        }
        

        //Deserializar Config
        public static object getConfig(string File, Type type)
        {
            XmlSerializer serializer = new XmlSerializer(type);
            try
            {
                using (FileStream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + AppDomain.CurrentDomain.FriendlyName.Replace(".exe", "") + "\\" + File, FileMode.Open))
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
