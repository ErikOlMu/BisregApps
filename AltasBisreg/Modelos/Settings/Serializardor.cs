using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AltasBisreg.Modelos.Settings
{
    public class Serializardor
    {
        public string ValorPV1;
        public string ValorPV2;
        public string ValorPV3;
        public string ValorCoste;
        public string ValorAmbito;
        public string RutaBaseDatos;

        public static void GetSettings()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Serializardor));
            try
            {
                using (FileStream fs = new FileStream("Config.conf", FileMode.Open))
                {
                    Serializardor S;
                    S = (Serializardor)serializer.Deserialize(fs);


                    Config.ValorPV1 = S.ValorPV1;
                    Config.ValorPV2 = S.ValorPV2;
                    Config.ValorPV3 = S.ValorPV3;
                    Config.ValorCoste = S.ValorCoste;
                    Config.ValorAmbito = S.ValorAmbito;
                    Config.RutaBaseDatos = S.RutaBaseDatos;

                }

            }
            catch (Exception)
            {
                Config.ValorPV1 = "";
                Config.ValorPV2 = "";
                Config.ValorPV3 = "";
                Config.ValorCoste = "";
                Config.ValorAmbito = "";
                Config.RutaBaseDatos = "";
            }
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Serializardor));

            StreamWriter writer = new StreamWriter("Config.conf");
            serializer.Serialize(writer, this);
            writer.Close();
        }

    }
}
