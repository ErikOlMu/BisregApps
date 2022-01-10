using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BisregApi.Utilidades;
namespace Referencias_CSV.Modulos
{
    public class Relacion
    {
        public string Referencia_Bisuta { get; set; }
        public string Referencia_Produccion { get; set; }
        public Relacion() {}
        public Relacion(string refBisuta, string refPrduccion)
        {
            Referencia_Bisuta = refBisuta;
            Referencia_Produccion = refPrduccion;
        }
    }

    public class ListaRelacion : XmlDocument
    {
        public List<Relacion> relaciones;

        public ListaRelacion() { }
        public ListaRelacion(string file)
        {
            this.file = file;
        }
    }
}
