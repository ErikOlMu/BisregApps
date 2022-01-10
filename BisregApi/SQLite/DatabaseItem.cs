using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisregApi.SQLite
{   
    public class DatabaseItem : ICloneable
    {
        public void SaveItem()
        {
            //Guardar Item

        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
