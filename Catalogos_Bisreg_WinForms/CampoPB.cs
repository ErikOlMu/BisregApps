using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogos_Bisreg_WinForms
{
    class CampoPB
    {
        //Nombre de Campo
        public string Nombre;
        //Nombre de contenido
        public string Texto;

        //Campos de configuracion
        public int Tamaño;
        public int Rotacion;
        public string Fuente;
        public int X;
        public int Y;


        public CampoPB(string Nombre)
        {
            this.Nombre = Nombre;
            this.Texto = Nombre;

            
            Tamaño = 30;
            Rotacion = 0;
            Fuente = "Arial";
            X = 0;
            Y = 0;
        
        }
    }
}
