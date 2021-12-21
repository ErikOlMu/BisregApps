using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BisregApi.Utilidades;
using BisregApi.Estructuras;

namespace Referencias_Clientes.Modulos
{
    public class Settings : Config
    {
        public int Limite_Excel = 2000;

        //Configuracion Pegatina
        public int TamañoReferencia = 50;
        public int TamañoReferenciaCliente = 50;

        public Point CordReferencia = new Point();
        public Point CordReferenciaCliente = new Point();

        //Configuracion Pagina
        public Size TamañoPagina = Sizes.A4;

        public int Columnas = 2;
        public int Filas = 4;

    }
}
