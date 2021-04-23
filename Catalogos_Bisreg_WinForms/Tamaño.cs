using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using iTextSharp.text;

namespace Catalogos_Bisreg_WinForms
{
    public class Tamaño
    {
        public string Nombre;
        public double Horizontal_CM;
        public double Vertical_CM;

        //Constructor
        public Tamaño()
        {
            //Sin parametros
        }
        public Tamaño(double pH, double pV)
        {
            Horizontal_CM = pH;
            Vertical_CM = pV;
        }

        //Get and Set
        public void setHorizontal(double pH)
        {
            Horizontal_CM = pH;
        }
        public void setVertical(double pV)
        {
            Vertical_CM = pV;
        }
        public double getHorizontal_Centimetros()
        {
            return Horizontal_CM;
        }
        public double getVertical_Centimetros()
        {
            return Vertical_CM;
        }


        //Get en Pixels
        public int getHorizontal_Pixel()
        {
            return (int)Math.Round((Horizontal_CM * 28.36), 2);
        }
        public int getVertical_Pixel()
        {
            return (int)Math.Round((Vertical_CM * 28.36), 2);

        }

        
        //Get Rectangle objeto de PDF
        public Rectangle getRectangle()
        {
            return new Rectangle(0, 0, getHorizontal_Pixel(), getVertical_Pixel());
        }

        public void getTamaño(string ruta)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Tamaño));
            try
            {
                using (FileStream fs = new FileStream(ruta, FileMode.Open))
                {
                    Tamaño S;
                    S = (Tamaño)serializer.Deserialize(fs);

                    Nombre = S.Nombre;
                    Horizontal_CM = S.getHorizontal_Centimetros();
                    Vertical_CM = S.getVertical_Centimetros();

                }

            }
            catch (Exception)
            {
                this.Nombre = "Error";
                this.Horizontal_CM = 0;
                this.Vertical_CM = 0;
            }
        }
        public void setTamaño()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Tamaño));

            StreamWriter writer = new StreamWriter(Settings.DirTamaños + Nombre + ".size");
            serializer.Serialize(writer, this);
            writer.Close();
        }
    }
}
