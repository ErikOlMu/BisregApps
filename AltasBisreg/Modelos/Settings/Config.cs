using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AltasBisreg.Modelos.Settings
{
    class Config
    {
        public static string ValorPV1;
        public static string ValorPV2;
        public static string ValorPV3;
        public static string ValorCoste;
        public static string ValorAmbito;
        public static string RutaBaseDatos;

        public static string GetDirectory()
        {
            using (FolderBrowserDialog dir = new FolderBrowserDialog())
            {
                //Show the Dialog box to selcet file(s)
                dir.ShowDialog();

                //return input file names
                return dir.SelectedPath;
            }
        }
        public static string GetFile()
        {
            using (SaveFileDialog file = new SaveFileDialog())
            {

                file.Filter = "xlsx | *.xlsx";
                file.FileName = "Export.xlsx";

                //Show the Dialog box to selcet file(s)
                file.ShowDialog();

                //return input file names
                return file.FileName;
            }
        }
        public static string openFile()
        {
            using (OpenFileDialog file = new OpenFileDialog())
            {

                file.Filter = "xlsx | *.xlsx";
                file.FileName = "Export.xlsx";

                //Show the Dialog box to selcet file(s)
                file.ShowDialog();

                //return input file names
                return file.FileName;
            }
        }

        public static void GetConfig()
        {
            Serializardor.GetSettings();
        }
        public static void SaveConfig()
        {
            Serializardor s = new Serializardor();
            s.ValorPV1 = ValorPV1;
            s.ValorPV2 = ValorPV2;
            s.ValorPV3 = ValorPV3;
            s.ValorCoste = ValorCoste;
            s.ValorAmbito = ValorAmbito;
            s.RutaBaseDatos = RutaBaseDatos;

            s.Save();
        }
    }
}
