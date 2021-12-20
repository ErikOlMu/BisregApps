using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BisregApi.Utilidades;

namespace Catalogos_Bisreg.Vista
{
    /// <summary>
    /// Lógica de interacción para PDFView.xaml
    /// </summary>
    public partial class PDFView : Window
    {
        DataTable dataTable;
        public PDFView(DataTable data)
        {
            dataTable = data;
            InitializeComponent();
            
        }

        private void GuardarCanvas()
        {
            WriteToPng(CanvasProducto, "Erik.png");
        }

        //Guardar un elemento a PNG
        public void WriteToPng(UIElement element, string filename)
        {
            var rect = new Rect(element.RenderSize);
            var visual = new DrawingVisual();

            using (var dc = visual.RenderOpen())
            {
                dc.DrawRectangle(new VisualBrush(element), null, rect);
            }

            //var bitmap = new RenderTargetBitmap(
            //    (int)rect.Width, (int)rect.Height, 96, 96, PixelFormats.Default);

            var bitmap = new RenderTargetBitmap(
                1024, 1024, 96, 96, PixelFormats.Default);
            bitmap.Render(visual);

            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmap));

            using (var file = File.OpenWrite(filename))
            {
                encoder.Save(file);
            }
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            GuardarCanvas();
        }
    }
}
