using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BisregApi.Utilidades;
namespace PrintBisreg
{
    public class Settings: Config
    {
        
        public string rutaBDD = "Reglas.db";
        public string CarpetaDiseños = "";
        public string CarpetaSalida = "";
        public double AltoMaximo = 0.0;
        public double AnchoMaximo = 0.0;
        public double PaddingAlto = 0.0;
        public double PaddingAncho = 0.0;
        public double MargenAlto = 0.0;
        public double MargenAncho = 0.0;
        public bool Sentido = true;
        public bool Info = true;
    }
}
