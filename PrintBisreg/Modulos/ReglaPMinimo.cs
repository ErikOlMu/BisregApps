using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BisregApi.SQLite;


namespace PrintBisreg.Modulos
{
    internal class ReglaPMinimo
    {
        [CampoSQL(PrimaryKey = true, NotNull = true, Default = "A")]
        public string Tipo { get; set; }

        [CampoSQL(PrimaryKey = true, NotNull = true, Default = "A")]
        public string Pueblo { get; set; }

        [CampoSQL(PrimaryKey = true, NotNull = true, Default = "A")]
        public string Base { get; set; }

        [CampoSQL(PrimaryKey = true, NotNull = true, Default = "A")]
        public string Diseño { get; set; }

        [CampoSQL(PrimaryKey = false, NotNull = true, Default = "1")]
        public Int64? Cantidad { get; set; }


        public int Nivel()
        {
            int nivel = 4;
            if (Tipo == "A") nivel -= 1;
            if (Pueblo == "A") nivel -= 1;
            if (Base == "A") nivel -= 1;
            if (Diseño == "A") nivel -= 1;
            return nivel;
        }
    }
}
