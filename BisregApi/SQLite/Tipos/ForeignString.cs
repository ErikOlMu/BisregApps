using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisregApi.SQLite.Tipos
{
    public class ForeignString
    {
        public string valor { get; set; }

        public ForeignString(string value)
        {
            valor = value;
        }
        public static implicit operator string(ForeignString d)
        {
            return d.valor;
        }
        public static implicit operator ForeignString(string d)
        {
            return new ForeignString(d);
        }
    }
}
