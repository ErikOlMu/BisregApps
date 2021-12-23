using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BisregApi.Utilidades
{
    public class Conversor
    {
        private struct PixelUnitFactor
        {
            public const double Px = 1.0;
            public const double Inch = 96.0;
            public const double Cm = 37.7952755905512;
            public const double Pt = 1.33333333333333;
        }
        //Convierte una cadena de Centimetros ej:"1,0cm" a double
        public static double Cm2Double(string cm)
        {
            return (double)new LengthConverter().ConvertFrom(cm);
        }
        //Convierte un double a una cadena de Centimetros
        public static string Double2Cm(double cm)
        {
            return Math.Round((cm / PixelUnitFactor.Cm), 2) + "cm";
        }
        

    }
}
