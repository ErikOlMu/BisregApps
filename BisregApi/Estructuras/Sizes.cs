using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BisregApi.Utilidades;
namespace BisregApi.Estructuras
{
    public struct Sizes
    {
        public static Size A0 = new Size(Conversor.Cm2Double("84,2cm"), Conversor.Cm2Double("118,9cm"));
        public static Size A1 = new Size(Conversor.Cm2Double("59,4cm"), Conversor.Cm2Double("84,1cm"));
        public static Size A2 = new Size(Conversor.Cm2Double("42cm"), Conversor.Cm2Double("59,4cm"));
        public static Size A3 = new Size(Conversor.Cm2Double("29,7cm"), Conversor.Cm2Double("42cm"));
        public static Size A4 = new Size(Conversor.Cm2Double("21cm"), Conversor.Cm2Double("29,7cm"));
        public static Size A5 = new Size(Conversor.Cm2Double("14,8cm"), Conversor.Cm2Double("21cm"));
        public static Size A6 = new Size(Conversor.Cm2Double("10,5cm"), Conversor.Cm2Double("14,8cm"));
        public static Size A7 = new Size(Conversor.Cm2Double("7,4cm"), Conversor.Cm2Double("10,5cm"));
        public static Size A8 = new Size(Conversor.Cm2Double("5,2cm"), Conversor.Cm2Double("7,4cm"));
        public static Size A9 = new Size(Conversor.Cm2Double("3,7cm"), Conversor.Cm2Double("5,2cm"));
        public static Size A10 = new Size(Conversor.Cm2Double("2,6cm"), Conversor.Cm2Double("3,7cm"));
    }
}
