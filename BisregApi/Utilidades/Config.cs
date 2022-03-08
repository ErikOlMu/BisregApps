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
    public class Config : XmlDocument
    {


        //Nombre del Archivo por defecto Config.conf
        public string file = "Config.conf";

        private string DirectorioAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + AppDomain.CurrentDomain.FriendlyName.Replace(".exe", "") + "\\";
        //Serializar Config

        

        public void Save()
        {
            Save(DirectorioAppData + file);

        }
        
        
        

       
       

    }
}
