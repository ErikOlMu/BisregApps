using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltasBisreg.Modelos.Settings
{
    class ListaDiseño
    {
        public ListaDiseño(string nombre)
        {
            Nombre = nombre;
            diseños = new List<TmpDiseño>();
        }

        public string Nombre { get; set; }
        public List<TmpDiseño> diseños { get; set; }

        public string GetNombre(string id)
        {
            foreach (TmpDiseño d in diseños)
            {
                if (d.ID == id) { return d.Descripcion; }
            }
            return null;
        }

        
    }
}
