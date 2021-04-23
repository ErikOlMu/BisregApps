using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Drawing;
using System.Xml.Serialization; 
using System.Threading.Tasks;


//Serializar y deserializar
//Hacer como en snake para poder entrar desde todos los sitios

namespace Catalogos_Bisreg_WinForms
{
    public class Settings
    {
        public static string File = "Settings.conf";
        public static string Directorio_IMG;
        public static int Columnas_Pagina ;
        public static string Directorio_Salida_PDF;
        public static string DirTamaños = "Tamaños\\";
        //Valores posiciones i tamaño por defecto

        //Imagen
        public static int TamañoImagen;
        public static int XImagen;
        public static int YImagen;
        public static int RotacionImagen;

        //Referencia
        public static int TamañoReferencia;
        public static int XReferencia;
        public static int YReferencia;
        public static int RotacionReferencia;

        //Barcode
        public static int TamañoBarcode;
        public static int XBarcode;
        public static int YBarcode;
        public static int RotacionBarcode;


        public Settings()
        { 
             getSettings();
        }
        public static void getSettings()
        {
            //Importacion a la classe Settings
            ImportacionSettings Importados = new ImportacionSettings();
            Importados.getSettings();
            File = Importados.File;
            Directorio_IMG = Importados.Directorio_IMG;
            Columnas_Pagina = Importados.Columnas_Pagina;
            Directorio_Salida_PDF = Importados.Directorio_Salida_PDF;



            TamañoImagen = Importados.TamañoImagen;
            XImagen = Importados.XImagen;
            YImagen = Importados.YImagen;
            RotacionImagen = Importados.RotacionImagen;

            TamañoReferencia = Importados.TamañoReferencia;
            XReferencia = Importados.XReferencia;
            YReferencia = Importados.YReferencia;
            RotacionReferencia = Importados.RotacionReferencia;

            TamañoBarcode = Importados.TamañoBarcode;
            XBarcode = Importados.XBarcode;
            YBarcode = Importados.YBarcode;
            RotacionBarcode = Importados.RotacionBarcode;
        }

        public static void setSettings()
        {
            ImportacionSettings i = new ImportacionSettings();
            i.File = File;
            i.Directorio_IMG = Directorio_IMG;
            i.Columnas_Pagina = Columnas_Pagina;
            i.Directorio_Salida_PDF = Directorio_Salida_PDF;



            i.TamañoImagen = TamañoImagen;
            i.XImagen = XImagen;
            i.YImagen = YImagen;
            i.RotacionImagen = RotacionImagen;

            i.TamañoReferencia = TamañoReferencia;
            i.XReferencia = XReferencia;
            i.YReferencia = YReferencia;
            i.RotacionReferencia = RotacionReferencia;

            i.TamañoBarcode = TamañoBarcode;
            i.XBarcode = XBarcode;
            i.YBarcode = YBarcode;
            i.RotacionBarcode = RotacionBarcode;
            i.setSettings();
        }

    }



    //Classe Solo para importar la configuracion
    public class ImportacionSettings
    {
        public string File = "Settings.conf";
        public string Directorio_IMG;
        public int Columnas_Pagina;
        public string Directorio_Salida_PDF;
        public static string DirTamaños = "Tamaños\\";


        //Imagen
        public int TamañoImagen;
        public int XImagen;
        public int YImagen;
        public int RotacionImagen;

        //Referencia
        public int TamañoReferencia;
        public int XReferencia;
        public int YReferencia;
        public int RotacionReferencia;

        //Barcode
        public int TamañoBarcode;
        public int XBarcode;
        public int YBarcode;
        public int RotacionBarcode;

        public void getSettings()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportacionSettings));
            try
            {
                using (FileStream fs = new FileStream(File, FileMode.Open))
                {
                    ImportacionSettings S;
                    S = (ImportacionSettings)serializer.Deserialize(fs);


                    File = S.File;
                    Directorio_IMG = S.Directorio_IMG;
                    Columnas_Pagina = S.Columnas_Pagina;
                    Directorio_Salida_PDF = S.Directorio_Salida_PDF;

                    TamañoImagen = S.TamañoImagen;
                    XImagen = S.XImagen;
                    YImagen = S.YImagen;
                    RotacionImagen = S.RotacionImagen;

                    TamañoReferencia = S.TamañoReferencia;
                    XReferencia = S.XReferencia;
                    YReferencia = S.YReferencia;
                    RotacionReferencia = S.RotacionReferencia;

                    TamañoBarcode = S.TamañoBarcode;
                    XBarcode = S.XBarcode;
                    YBarcode = S.YBarcode;
                    RotacionBarcode = S.RotacionBarcode;

                }

            }
            catch (Exception)
            {
                this.File = "Settings.conf";
                this.Directorio_IMG = null;
                this.Columnas_Pagina = 0;
            }
        }
        public void setSettings()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportacionSettings));

            StreamWriter writer = new StreamWriter(File);
            serializer.Serialize(writer, this);
            writer.Close();
        }

    }
}
