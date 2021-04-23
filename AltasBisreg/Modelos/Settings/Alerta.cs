using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AltasBisreg.Modelos.Settings
{
    public class Alerta
    {
  
        public Alerta(string tIPO, string iD, string aLERTA)
        {
           TIPO = tIPO;
           ID = iD;
           ALERTA = aLERTA;
        }
        public Alerta()
        {

        }
        public string TIPO { get; set; } 
        public string ID { get; set;}
        public string ALERTA { get; set; }
        












    }
}
