using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BisregApi.Estructuras
{
    public struct Sizes
    {
        public static LengthConverter lc = new LengthConverter();
        public static Size A0 = new Size((double)lc.ConvertFrom("84,2cm"), (double)lc.ConvertFrom("118,9cm"));
        public static Size A1 = new Size((double)lc.ConvertFrom("59,4cm"), (double)lc.ConvertFrom("84,1cm"));
        public static Size A2 = new Size((double)lc.ConvertFrom("42cm"), (double)lc.ConvertFrom("59,4cm"));
        public static Size A3 = new Size((double)lc.ConvertFrom("29,7cm"), (double)lc.ConvertFrom("42cm"));
        public static Size A4 = new Size((double)lc.ConvertFrom("21cm"), (double)lc.ConvertFrom("29,7cm"));
        public static Size A5 = new Size((double)lc.ConvertFrom("14,8cm"), (double)lc.ConvertFrom("21cm"));
        public static Size A6 = new Size((double)lc.ConvertFrom("10,5cm"), (double)lc.ConvertFrom("14,8cm"));
        public static Size A7 = new Size((double)lc.ConvertFrom("7,4cm"), (double)lc.ConvertFrom("10,5cm"));
        public static Size A8 = new Size((double)lc.ConvertFrom("5,2cm"), (double)lc.ConvertFrom("7,4cm"));
        public static Size A9 = new Size((double)lc.ConvertFrom("3,7cm"), (double)lc.ConvertFrom("5,2cm"));
        public static Size A10 = new Size((double)lc.ConvertFrom("2,6cm"), (double)lc.ConvertFrom("3,7cm"));
    }
}
