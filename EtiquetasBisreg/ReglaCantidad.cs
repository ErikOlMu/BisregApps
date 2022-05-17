using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BisregApi.SQLite;
namespace EtiquetasBisreg
{
    public class ReglaCantidad
    {
        public ReglaCantidad(string tipo, string @base, long? cantidad)
        {
            Tipo = tipo;
            Base = @base;
            Cantidad = cantidad;
        }

        [CampoSQL(PrimaryKey = true, NotNull = true, Default = "A")]
        public string Tipo { get; set; }

        [CampoSQL(PrimaryKey = true, NotNull = true, Default = "A")]
        public string Base { get; set; }

        [CampoSQL(PrimaryKey = false, NotNull = true, Default = "1")]
        public Int64? Cantidad { get; set; }

        public int Nivel()
        {
            int nivel = 2;
            if (Tipo == "A") nivel -= 1;
            if (Base == "A") nivel -= 1;
            return nivel;
        }
    }
}
