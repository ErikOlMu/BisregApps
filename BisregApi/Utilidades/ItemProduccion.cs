using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BisregApi.Utilidades
{
    //Classe para referencias de Produccion
    public class ItemProduccion
    {
        public string Tipo;
        public string Pueblo;
        public string Base;
        public string Diseño;


        
        public ItemProduccion(string Referencia)
        {
            //Los caracteres 0 y 1 son el TIPO
            Tipo = (Referencia[0]+Referencia[1]).ToString();
            //Los caracteres 2,3 y 4 son el pueblo
            Pueblo = (Referencia[2] + Referencia[3] + Referencia[4]).ToString();

            switch (Referencia.Length)
            {

                //Si el tamaño es 8 es una referencia de primer nivel, tiene dos numeros de diseño y dos de base
                case 9:
                    Base = (Referencia[5] + Referencia[6]).ToString();
                    Diseño = (Referencia[7] + Referencia[8]).ToString();
                    break;
                //Si el tamaño es de 10 es una referencia de segundo nivel, pueden tener hasta 3 numeros la base, el diseño o los dos
                case 11:
                    //Primero compruebo el ultimo caracter
                    char Letra = Referencia[10];
                    switch (Letra)
                    {
                        //Tiene 3 numeros de Base
                        case 'B':
                            Base = (Referencia[5] + Referencia[6] + Referencia[7]).ToString();
                            Diseño = (Referencia[8] + Referencia[9]).ToString();
                            break;
                        //Tiene 3 numeros de Diseño
                        case 'D':
                            Base = (Referencia[5] + Referencia[6]).ToString();
                            Diseño = (Referencia[7] + Referencia[8] + Referencia[9]).ToString();
                            break;
                        //No es ni B ni D entones tiene 3 de diseño y 3 de base
                        default:
                            Base = (Referencia[5] + Referencia[6] + Referencia[7]).ToString();
                            Diseño = (Referencia[8] + Referencia[9] + Referencia[10]).ToString();
                            break;
                    }
                    break;
                //Este es solo para los que tienen mas de 15 caracteres, son referencias de tercer nivel y pueden tener infinitos numeros de diseños y de bases
                default:
                    if (Referencia.Length >= 15)
                    {
                        string[] ReferenciaArray = Referencia.Replace('D', ' ').Replace('B', ' ').Split(' ');
                        int nBase = int.Parse(ReferenciaArray[ReferenciaArray.Length - 2]);
                        int nDisseny = int.Parse(ReferenciaArray[ReferenciaArray.Length - 1]);

                        int i = 5 + nBase;

                        //Por hacer //Falta añadir los rangos

                    }
                    break;
            }

        }


    }
}
