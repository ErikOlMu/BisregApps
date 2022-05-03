using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorPCF.Objetos
{
   
    public class Tamaño 
    {
        public string Nombre { get; set; }
        public double Alto { get; set; }
        public double Ancho { get; set; }
    }

    public class ColeccionTamaños : BisregApi.Utilidades.Config
    {
        public List<Tamaño> Tamaños { get; set; } = new List<Tamaño>();
    }
}
