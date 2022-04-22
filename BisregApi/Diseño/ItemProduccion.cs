using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisregApi.Diseño
{
    public class ItemProduccion
    {
        public ItemProduccion(string tipo, string pueblo, string @base, string diseño)
        {
            Tipo = tipo;
            Pueblo = pueblo;
            Base = @base;
            Diseño = diseño;
        }

        public string Tipo { get; set; }
        public string Pueblo { get; set; }
        public string Base { get; set; }
        public string Diseño { get; set; }
        public int Copias { get; set; }
        public string Pedido { get; set; }
        public int CopiasXArchivo { get; set; } = 1;

        public bool Valido = false;

        public ItemProduccion(string codigo, int copias)
        {
            Codigo = codigo.ToUpper();
            Copias = copias;
            Pedido = "";
        }

        public ItemProduccion(string codigo, int copias, string pedido)
        {
            Codigo = codigo.ToUpper();
            Copias = copias;
            Pedido = pedido;
        }

        private string Code;

        private void Validar()
        {
            if (!Tipo.All(char.IsDigit) && Pueblo.All(char.IsDigit) && Base.All(char.IsDigit) && Diseño.All(char.IsDigit))
            {
                Valido = true;

            }
            else
            {
                CodigoNoValido();
            }
        }
        private void CodigoNoValido()
        {
            Tipo = "";
            Pueblo = "";
            Base = "";
            Diseño = "";
            Valido = false;
        }

        public string Codigo
        {
            get
            {


                return Code;

            }
            set
            {
                try
                {
                    Code = value;
                    if (value.Length > 8)
                    {
                        Code = value;

                        Tipo = new string(value.ToCharArray(0, 2)).ToUpper();
                        int CodeLen = value.Length;
                        if (CodeLen == 9)
                        {
                            Pueblo = new string(value.ToCharArray(2, 3));
                            Base = new string(value.ToCharArray(5, 2));
                            Diseño = new string(value.ToCharArray(7, 2));

                        }
                        if (CodeLen == 11)
                        {

                            Pueblo = new string(value.ToCharArray(2, 3));
                            char UltimoCaracter = value.ToCharArray(CodeLen - 1, 1)[0];

                            switch (UltimoCaracter)
                            {
                                case 'B':
                                    //La Base tiene 3 Numeros
                                    Base = new string(value.ToCharArray(5, 3));
                                    Diseño = new string(value.ToCharArray(8, 2));
                                    break;
                                case 'D':
                                    //El Diseño tiene 3 Numeros
                                    Base = new string(value.ToCharArray(5, 2));
                                    Diseño = new string(value.ToCharArray(7, 3));
                                    break;
                                default:
                                    //La Base y el Diseño tienen 3 Caracteres
                                    Base = new string(value.ToCharArray(5, 3));
                                    Diseño = new string(value.ToCharArray(8, 3));
                                    break;

                            }





                        }
                        if (CodeLen >= 12)
                        {

                            bool letra = false;
                            int Seleccion = 0;

                            //0 Pueblo
                            //1 Base
                            //2 Diseño

                            int NPueblo = 3;
                            int NBase = 2;
                            int NDiseño = 2;

                            string tempNum = "";

                            //Bucle Para obtener numeros de cada Campo
                            foreach (char c in value.ToCharArray(2, CodeLen - 2))
                            {
                                if (letra)
                                {
                                    if (char.IsNumber(c))
                                    {
                                        tempNum = tempNum + c;
                                        if (Seleccion == 0) NPueblo = int.Parse(tempNum);
                                        if (Seleccion == 1) NBase = int.Parse(tempNum);
                                        if (Seleccion == 2) NDiseño = int.Parse(tempNum);
                                    }
                                    else
                                    {
                                        tempNum = "";
                                        letra = false;
                                    }
                                }

                                if (!char.IsNumber(c))
                                {
                                    letra = true;

                                    switch (c)
                                    {
                                        case 'P':
                                            Seleccion = 0;
                                            break;
                                        case 'B':
                                            Seleccion = 1;
                                            break;
                                        case 'D':
                                            Seleccion = 2;
                                            break;
                                        default:
                                            letra = false;
                                            break;
                                    }

                                }
                            }

                            int i = 2;
                            Pueblo = new string(value.ToCharArray(i, NPueblo));
                            i += NPueblo;
                            Base = new string(value.ToCharArray(i, NBase));
                            i += NBase;
                            Diseño = new string(value.ToCharArray(i, NDiseño));


                        }

                        //Validamos la referencia 
                        Validar();
                    }
                }
                catch
                {
                    CodigoNoValido();
                }

            }
        }

        public string GetRutaDiseño(string ruta)
        {
            try
            {
                string Carpeta = Directory.GetDirectories(Directory.GetDirectories(ruta, Pueblo + "*")[0], Tipo + Pueblo + Base)[0];
                string[] file = Directory.GetFiles(Carpeta, Code + ".pdf");
                if (file.Length != 0)
                {
                    return file[0];
                }
                else
                {

                    string filecantidad = Directory.GetFiles(Carpeta, Code + " *.pdf")[0];
                    if (filecantidad.Length != 0)
                    {
                        bool caracter_ = false;
                        string cantidad = "";
                        foreach (char c in Path.GetFileName(filecantidad))
                        {
                            if (caracter_)
                            {
                                if (Char.IsDigit(c))
                                {
                                    cantidad = cantidad + c;
                                }
                                else caracter_ = false;
                            }
                            else
                            {
                                caracter_ = c == ' ';
                            }

                        }

                        CopiasXArchivo = int.Parse(cantidad);
                        return filecantidad;
                    }
                    else return "";

                }
            }
            catch
            {
                return "";
            }
        }
    }
}
