using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AltasBisreg.Controladores;
using AltasBisreg.Modelos.Capa1;
using AltasBisreg.Modelos.Capa2;
using AltasBisreg.Modelos.Capa3;
using AltasBisreg.Vista;
using AltasBisreg.Modelos.Settings;

namespace AltasBisreg
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        /// 
        public static VentanaPrincipal ventana;
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Get Settings
            Config.GetConfig();
            ventana = new VentanaPrincipal();
            Application.Run(ventana);
        }
    }
}
