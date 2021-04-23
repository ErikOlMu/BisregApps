using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltasBisreg.Modelos.Settings
{
    class TmpDiseño
    {
        public TmpDiseño(string iD, string descripcion)
        {
            ID = iD;
            Descripcion = descripcion;
        }

        public TmpDiseño()
        {

        }

        public string ID { get; set; }
        public string Descripcion { get; set; }
    }

}
