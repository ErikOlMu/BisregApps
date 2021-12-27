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
    public class Tamaño
    {
        public string Nombre { get; set; }
        public Size size;

        
        public Tamaño(string nombre, Size size)
        {
            Nombre = nombre;
            this.size = size;
        }
        public Tamaño()
        {
            Nombre = "Null";
            this.size = new Size();
        }
    }
    public class Settings : Config
    {
        public int Limite_Excel = 2000;

        public int Copias = 1;

        //Configuracion Pegatina
        public int TamañoReferencia = 50;
        public int TamañoReferenciaCliente = 50;
        public int TamañoPueblo = 50;
        public int TamañoCantidad = 50;

        public Point CordReferencia = new Point(0,15);
        public Point CordReferenciaCliente = new Point(55,15);
        public Point CordPueblo = new Point(110,15);
        public Point CordCantidad = new Point(165,15);

        public string FuenteReferencia = "Segoe UI";
        public string FuenteReferenciaCliente = "Segoe UI";
        public string FuentePueblo = "Segoe UI";
        public string FuenteCantidad = "Segoe UI";

        public double RotacionReferencia = 0;
        public double RotacionReferenciaCliente = 0;
        public double RotacionPueblo  = 0;
        public double RotacionCantidad =  0;

        public int Columnas = 2;
        public int Filas = 4;


        public int TamañoSeleccionado = 0;

        public List<Tamaño> TamañosPagina = new List<Tamaño>();

        public Settings()
        {

        }
        public void SettingsReload()
        {
            

            //Configuracion Pegatina
            TamañoReferencia = 50;
            TamañoReferenciaCliente = 50;

            CordReferencia = new Point(0, 15);
            CordReferenciaCliente = new Point(55, 15);

            FuenteReferencia = "Segoe UI";
            FuenteReferenciaCliente = "Segoe UI";

            Columnas = 2;
            Filas = 4;

            TamañoSeleccionado = 0;
            if (TamañosPagina.Count == 0) TamañosPagina.Add(new Tamaño("A4", Sizes.A4));
            Save();
    }
 
    }
}
