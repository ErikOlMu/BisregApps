using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AltasBisreg.Modelos.Settings;
namespace AltasBisreg.Controladores
{
    class SerlizadorAlertas
    {
        public List<Alerta> alertas;
        
        

        public static bool ExisteAlerta(string id, string tipo)
        {
            var alertas = new SerlizadorAlertas();
            foreach (Alerta a in alertas.alertas)
            {
                if (a.ID == id && a.TIPO == tipo)
                {
                    return true;
                }
            }

            return false;

        }
        public static Alerta GetAlerta(string id, string tipo)
        {
                var alertas = new SerlizadorAlertas();
                foreach (Alerta a in alertas.alertas)
                {
                    if (a.ID == id && a.TIPO == tipo)
                    {
                        return a;
                    }
                }
            return null;


        }
        public SerlizadorAlertas()
        {
            GetAlertas();
        }
        public void GetAlertas()
        {
            alertas = new List<Alerta>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Alerta>));
            try
            {

                    using (FileStream fs = new FileStream("Alertas.alert", FileMode.Open))
                    {
                        alertas = (List<Alerta>)serializer.Deserialize(fs);
                    }

            }
            catch (Exception)
            {

            }
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Alerta>));
            StreamWriter writer = new StreamWriter("Alertas.alert");
            serializer.Serialize(writer, alertas);
            writer.Close();
        }



    }
}
