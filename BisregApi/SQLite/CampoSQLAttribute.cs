using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BisregApi.SQLite
{
    [AttributeUsage(AttributeTargets.Property |
                       AttributeTargets.Struct)
]
    public class CampoSQLAttribute : Attribute
    {
        public bool PrimaryKey = false;
        public bool ForeginKey = false;
        public Type ForeginTable = null;
        public string ForeginCampo = null;
        public string Default = null;
        public string Check = null;
        public bool NotNull = false;
        public bool Unique = false;
        
    }
}
