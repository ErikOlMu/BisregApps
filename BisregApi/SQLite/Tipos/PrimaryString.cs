using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisregApi.SQLite.Tipos
{
    public class PrimaryString
    {
        public PrimaryString(string valor)
        {
            this.valor = valor;
        }

        public String valor { get; set; }

       
        public static implicit operator String(PrimaryString d)
        {
            try
            {
                return d.valor;
            }
            catch
            {
                return "";
            }
        }
        
        public static implicit operator PrimaryString(String d)
        {
            return new PrimaryString(d);
        }
    }
}
