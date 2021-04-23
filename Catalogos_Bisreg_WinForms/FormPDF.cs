using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Collections;
using System.Windows.Input;
using System.IO;
using System.Drawing.Drawing2D;
using System.Threading;

namespace Catalogos_Bisreg_WinForms
{
    public partial class FormPDF : Form
    {
        public ArrayList Campos = new ArrayList();
        public Image Foto = Image.FromFile("Imagen.jpg");
        public ArrayList Productos;
        public ArrayList TamañoHoja;
        private FontFamily BarcodeFont = new FontFamily("3 of 9 Barcode");
        public FormPDF(ArrayList Campos, ArrayList Productos)
        {
            this.Productos = Productos;
            this.Campos = Campos;
            TamañoHoja = new ArrayList();
            InitializeComponent();
            foreach (CampoPB campo in Campos)
            {
                Ltb_Campos.Items.Add(campo.Texto);
            }
            getTamaños();
            txb_DirIMG.Text = Settings.Directorio_IMG;
            txb_Columnas.Text = Settings.Columnas_Pagina.ToString();
            txb_Ruta_Salida.Text = Settings.Directorio_Salida_PDF;

        }

        private void Celda_PDF_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    ((CampoPB)Campos[Ltb_Campos.SelectedIndex]).X = e.Location.X;
                    ((CampoPB)Campos[Ltb_Campos.SelectedIndex]).Y = e.Location.Y;


                    Celda_PDF.Invalidate();
                }
                catch(Exception ex)
                {

                }
            }
            
        }

        static Image FixedSize(Image imgPhoto, int Width, int Height)
        {
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)Width / (float)sourceWidth);
            nPercentH = ((float)Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((Width -
                              (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((Height -
                              (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(Width, Height,
                              PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                             imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.White);
            grPhoto.InterpolationMode =
                    InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }
        public void Celda_PDF_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            try
            { 

                foreach (CampoPB c in Campos)
                {

                   
                        //Campos Normales
                   if ((c.Nombre != "Imagen" && c.Nombre !="Barcode" ) || (c.Nombre == "Barcode" && chbx_Barcode.Checked))
                    {
                        
                        canvas.ResetTransform();

                        SizeF sz = e.Graphics.VisibleClipBounds.Size;

                        canvas.TranslateTransform(sz.Width / 2, sz.Height / 2);

                        canvas.RotateTransform(c.Rotacion);

                        Font fuente = new Font(c.Fuente, c.Tamaño);

                        if (c.Nombre == "Barcode")
                        {
                            fuente = new Font(BarcodeFont, c.Tamaño);

                        }
                        

                        canvas.DrawString(c.Texto, fuente, Brushes.Black, c.X - (sz.Width / 2), c.Y - (sz.Height / 2));

                        canvas.RotateTransform(c.Rotacion - (c.Rotacion * 2));
                    }
                    //Imagen
                    else if (c.Nombre == "Imagen")
                    {

                        canvas.DrawImage(FixedSize(Foto,c.Tamaño,c.Tamaño), c.X , c.Y , c.Tamaño , c.Tamaño);
                    }

                }

            }
            catch (System.Exception ex)
            {
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tbx_Tamaño_TextChanged(object sender, EventArgs e)
        {
            try
            {

                ((CampoPB)Campos[Ltb_Campos.SelectedIndex]).Tamaño = Int32.Parse(tbx_Tamaño.Text);
            }
            catch(Exception ex){

            }
            Celda_PDF.Invalidate();

        }

        //Evento para cuando cambia la seleccion cambiar los datos de la interficie
        private void Ltb_Campos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tbx_Fuente.Text = ((CampoPB)Campos[Ltb_Campos.SelectedIndex]).Fuente;
                tbx_Orientacion.Text = ((CampoPB)Campos[Ltb_Campos.SelectedIndex]).Rotacion.ToString();
                tbx_Tamaño.Text = ((CampoPB)Campos[Ltb_Campos.SelectedIndex]).Tamaño.ToString();

            }
            catch(Exception ex)
            {
                
            }

        }

        private void tbx_Orientacion_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ((CampoPB)Campos[Ltb_Campos.SelectedIndex]).Rotacion = Int32.Parse(tbx_Orientacion.Text);

            }
            catch (Exception ex)
            {

            }
            Celda_PDF.Invalidate();
        }
        private void tbx_Fuente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ((CampoPB)Campos[Ltb_Campos.SelectedIndex]).Fuente = tbx_Fuente.Text;

            }
            catch (Exception ex)
            {

            }
            Celda_PDF.Invalidate();
        }

        private void btn_Guardar_PDF_Click(object sender, EventArgs e)
        {
            string ruta_hoja = (string) cb_sizeSalida.SelectedItem ;

            Tamaño t = new Tamaño();
            t.getTamaño(Settings.DirTamaños + ruta_hoja);


            new PDF(Productos, this, t);


            //Prueba de Thread
            //Thread thread = new Thread(
            //    () =>
            //    new PDF(Productos,this,t)
            //    );
        }


        private void txb_DirIMG_TextChanged(object sender, EventArgs e)
        {
            try
            {

            Settings.Directorio_IMG = txb_DirIMG.Text;
            Settings.setSettings();
            }
            catch(Exception ex)
            {

            }
        }

        private void txb_Columnas_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Settings.Columnas_Pagina = Int32.Parse(txb_Columnas.Text);
                Settings.setSettings();
            }
            catch (Exception ex)
            {

            }
        }

        private void txb_Ruta_Salida_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Settings.Directorio_Salida_PDF = txb_Ruta_Salida.Text;
                Settings.setSettings();
            }
            catch (Exception ex)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txb_DirIMG.Text = ImportExcel.GetDirectory();

        }

        private void btn_Cargar_Salida_Click(object sender, EventArgs e)
        {
            txb_Ruta_Salida.Text = ImportExcel.GetFile();

        }
        private void getTamaños()
        {
            DirectoryInfo D = new DirectoryInfo(Settings.DirTamaños);
            foreach (FileInfo file in D.GetFiles())
            {
                if (file.Extension == ".size")
                {
                    cb_sizeSalida.Items.Add(file.Name);   
                }
                

            }
            cb_sizeSalida.SelectedItem = "Gerard.size";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Añadir_Tamaño frm = new Añadir_Tamaño();
            frm.Show();
        }

        private void btn_Camposdefecto_Click(object sender, EventArgs e)
        {
            //Añado la Imagen (Campo inborrable)
            Settings.TamañoImagen = ((CampoPB)Campos[0]).Tamaño;
            Settings.XImagen = ((CampoPB)Campos[0]).X;
            Settings.YImagen = ((CampoPB)Campos[0]).Y;
            Settings.RotacionImagen = ((CampoPB)Campos[0]).Rotacion;

            //Añado la referencia
            Settings.XReferencia = ((CampoPB)Campos[1]).X;
            Settings.YReferencia = ((CampoPB)Campos[1]).Y;
            Settings.RotacionReferencia = ((CampoPB)Campos[1]).Rotacion;
            Settings.TamañoReferencia = ((CampoPB)Campos[1]).Tamaño;


            //Añado el Barcode
            Settings.XBarcode = ((CampoPB)Campos[2]).X;
            Settings.YBarcode = ((CampoPB)Campos[2]).Y;
            Settings.RotacionBarcode = ((CampoPB)Campos[2]).Rotacion;
            Settings.TamañoBarcode = ((CampoPB)Campos[2]).Tamaño;

            Settings.setSettings();
        }
    }
}
