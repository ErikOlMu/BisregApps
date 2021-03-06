using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Xml;

namespace BisregApi.Utilidades
{

    public struct CamposCanvas
    {
        public static byte Null = 0;
        public static byte Texto = 1;
        public static byte Imagen = 2;

    }
    public class CampoCanvas : ICloneable
    {



        //Constructores del Campos Canvas
        public CampoCanvas(string valor, Point coordenadas, int tamaño)
        {
            Elemento = new TextBlock();
            Valor = valor;
            Coordenadas = coordenadas;
            Tamaño = tamaño;
            Rotacion = 0;

            //Añadimos Uid al Elemento
            Elemento.Uid = Elemento.GetHashCode().ToString();
        }
        public CampoCanvas(string valor, Point coordenadas, int tamaño, byte Tipo)
        {
            //Creamos el Elemento segun el tipo indicado
            switch (Tipo)
            {
                case 0:
                    Elemento = new UIElement();
                    break;
                case 1:
                    Elemento = new TextBlock();
                    (Elemento as TextBlock).TextAlignment = TextAlignment.Left;
                    (Elemento as TextBlock).TextWrapping = TextWrapping.Wrap;

                    break;
                case 2:
                    Elemento = new Image();
                    break;
                default:
                    //En el caso que no hay ninguno se crea un TextBlock
                    Elemento = new TextBlock();
                    break;
            }

            Valor = valor;
            Coordenadas = coordenadas;
            Tamaño = tamaño;
            Rotacion = 0;

            //Añadimos Uid al Elemento
            Elemento.Uid = Elemento.GetHashCode().ToString();
        }
        public CampoCanvas(string valor, Point coordenadas, int tamaño, double rotacion, byte Tipo)
        {
            //Creamos el Elemento segun el tipo indicado
            switch (Tipo)
            {
                case 0:
                    Elemento = new UIElement();
                    break;
                case 1:
                    Elemento = new TextBlock();
                    break;
                case 2:
                    Elemento = new Image();
                    break;
                default:
                    //En el caso que no hay ninguno se crea un TextBlock
                    Elemento = new TextBlock();
                    break;
            }

            Valor = valor;
            Coordenadas = coordenadas;
            Tamaño = tamaño;
            Rotacion = rotacion;

            //Añadimos Uid al Elemento
            Elemento.Uid = Elemento.GetHashCode().ToString();
        }
        //Constructor que no hace falta indicar el tipo (Por defecto sera un Texto
        public CampoCanvas(string valor, Point coordenadas, int tamaño, double rotacion)
        {
            Elemento = new TextBlock();
            Valor = valor;
            Coordenadas = coordenadas;
            Tamaño = tamaño;
            Rotacion = rotacion;

            //Añadimos Uid al Elemento
            Elemento.Uid = Elemento.GetHashCode().ToString();
        }
        public CampoCanvas(UIElement elemento)
        {

            Elemento = elemento;

            if (elemento != null)
            {
                //Añadimos Uid al Elemento
                Elemento.Uid = Elemento.GetHashCode().ToString();
            }

        }
        public CampoCanvas()
        {
            Elemento = new UIElement();
            //Añadimos Uid al Elemento
            Elemento.Uid = Elemento.GetHashCode().ToString();
        }
        public double Rotacion
        {
            get
            {
                try
                {
                    if (Elemento is TextBlock)
                    {
                        return (Elemento.GetValue(TextBlock.RenderTransformProperty) as RotateTransform).Angle;
                    }
                    if (Elemento is Image)
                    {
                        return (Elemento.GetValue(Image.RenderTransformProperty) as RotateTransform).Angle;
                    }
                    return 0.0;
                }
                catch
                {
                    return 0.0;
                }
            }
            set
            {

                if (Elemento is TextBlock)
                {
                    Elemento.SetValue(TextBlock.RenderTransformProperty, new RotateTransform(value, 0, 0));
                }
                if (Elemento is Image)
                {
                    Elemento.SetValue(Image.RenderTransformProperty, new RotateTransform(value, 0, 0));
                }

            }
        }
        public string Valor
        {
            get
            {
                if (Elemento is TextBlock)
                {
                    return (string)Elemento.GetValue(TextBlock.TextProperty);
                }
                if (Elemento is Image)
                {
                    return (string)Elemento.GetValue(Image.SourceProperty).ToString();
                }
                return null;
            }
            set
            {
                if (Elemento is TextBlock)
                {
                    Elemento.SetValue(TextBlock.TextProperty, value);
                }
                if (Elemento is Image)
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(value);
                    bitmapImage.EndInit();
                    Elemento.SetValue(Image.StretchProperty, Stretch.Fill);
                    Elemento.SetValue(Image.SourceProperty, bitmapImage);
                }
            }
        }
        public int Tamaño
        {
            get
            {
                if (Elemento is TextBlock)
                {
                    return Convert.ToInt32(Elemento.GetValue(TextBlock.FontSizeProperty));
                }
                if (Elemento is Image)
                {
                    return Convert.ToInt32((double)Elemento.GetValue(Image.HeightProperty));
                }
                return 0;
            }
            set
            {
                if (Elemento is TextBlock)
                {
                    Elemento.SetValue(TextBlock.FontSizeProperty, Convert.ToDouble(value));
                }
                if (Elemento is Image)
                {
                    Elemento.SetValue(Image.HeightProperty, Convert.ToDouble(value));
                }
            }
        }

        public string Uid
        {
            get
            {
                if (Elemento == null) return "";
                else return Elemento.Uid;
            }
            set { Elemento.Uid = value; }
        }

        public UIElement Elemento {get; set; }

        public Point Coordenadas
        {
            get
            {
                return new Point((double)Elemento.GetValue(Canvas.TopProperty), (double)Elemento.GetValue(Canvas.LeftProperty));
            }
            set
            {
                Elemento.SetValue(Canvas.TopProperty, value.X);
                Elemento.SetValue(Canvas.LeftProperty, value.Y);
            }
        }

        //Metodo para obtener el tipo que es el Elemento
        public byte getTipo()
        {

            if (Elemento is TextBlock) return CamposCanvas.Texto;
            if (Elemento is Image) return CamposCanvas.Imagen;

            //Si no es ningun tipo devolvemos tipo Null
            return CamposCanvas.Null;

        }

        public object Clone()
        {
            CampoCanvas temp = this.MemberwiseClone() as CampoCanvas;


            if (temp.Elemento == null)
                return (null);
            string s = XamlWriter.Save(temp.Elemento);
            StringReader stringReader = new StringReader(s);
            XmlReader xmlReader = XmlTextReader.Create(stringReader, new XmlReaderSettings());
            temp.Elemento = (UIElement)XamlReader.Load(xmlReader);

            return temp;
        }

        public ContentControl ContentControl
        {
            get
            {
                ContentControl control = new ContentControl();
                control.Content = Elemento;
                return control;
            }

        }

        // Elementos Extras
        public string ColumnaExcel { get; set; } = "";
        public string TextoAnterior { get; set; } = "";
        public string TextoPosterior { get; set; } = "";

    }
}
