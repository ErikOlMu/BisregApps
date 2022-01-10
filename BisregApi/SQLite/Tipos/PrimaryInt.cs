using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisregApi.SQLite.Tipos
{
    public class PrimaryInt
    {
        public PrimaryInt(int valor)
        {
            this.valor = valor;
        }

        public int valor { get; set; }

        public static implicit operator int(PrimaryInt d)
        {
            try
            {
                return d.valor;
            }
            catch
            {
                return 0;
            }
        }

        public static implicit operator PrimaryInt(int d)
        {
            return new PrimaryInt(d);
        }

    }
}
