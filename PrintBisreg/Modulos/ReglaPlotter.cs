using BisregApi.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintBisreg.Modulos
{
    internal class ReglaPlotter
    {
        public ReglaPlotter(string tipo, string pueblo, string @base, string diseño)
        {
            Tipo = tipo;
            Pueblo = pueblo;
            Base = @base;
            Diseño = diseño;
        }

        [CampoSQL(PrimaryKey = true, NotNull = true, Default = "A")]
        public string Tipo { get; set; }

        [CampoSQL(PrimaryKey = true, NotNull = true, Default = "A")]
        public string Pueblo { get; set; }

        [CampoSQL(PrimaryKey = true, NotNull = true, Default = "A")]
        public string Base { get; set; }

        [CampoSQL(PrimaryKey = true, NotNull = true, Default = "A")]
        public string Diseño { get; set; }


    }
}
