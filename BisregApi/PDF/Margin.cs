using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisregApi.PDF
{
    public class Margin
    {
        public Margin(double marginHeight, double marginWidth)
        {
            MarginHeight = marginHeight;
            MarginWidth = marginWidth;
        }

      


        public double MarginHeight  {get; set; }
        public double MarginWidth   {get; set; }  
    }
}
