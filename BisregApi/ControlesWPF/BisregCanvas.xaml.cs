using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BisregApi.Utilidades;
namespace BisregApi.ControlesWPF
{
    /// <summary>
    /// Lógica de interacción para BisregCanvas.xaml
    /// </summary>
    public partial class BisregCanvas : UserControl
    {


        // El desplazamiento de la posición del mouse del control seleccionado
        Point targetPoint;

        //Campo de lista
        private List<CampoCanvas> _CamposList = new List<CampoCanvas>();

        //Get y set para no borrar nunca la lista
        public List<CampoCanvas> CamposList {
            get
            {
                return _CamposList;
            }
            set
            {
                CamposList.Clear();
                CamposList.AddRange(value);
            }
        }


        public BisregCanvas()
        {
            InitializeComponent();

            UpdateCampos();
        }

        
        private void CanvasPrincipal_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var targetElement = e.Source as IInputElement;
            if (targetElement != null)
            {
                targetPoint = e.GetPosition(targetElement);
                // Comienza a capturar el mouse
                targetElement.CaptureMouse();
            }
        }

        private void CanvasPrincipal_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // Cancelar captura del mouse
            Mouse.Capture(null);
        }

        private void CanvasPrincipal_MouseMove(object sender, MouseEventArgs e)
        {
            // Asegúrese de presionar el botón izquierdo del mouse y de seleccionar un elemento
            var targetElement = Mouse.Captured as UIElement;
            if (e.LeftButton == MouseButtonState.Pressed && targetElement != null)
            {
                var pCanvas = e.GetPosition(CanvasPrincipal);
                // Establecer la posición final
                Canvas.SetLeft(targetElement, pCanvas.X - targetPoint.X);
                Canvas.SetTop(targetElement, pCanvas.Y - targetPoint.Y);
            }
        }

        public void UpdateCampos()
        {
            CanvasPrincipal.Children.Clear();
            foreach(CampoCanvas campo in CamposList)
            {
                CanvasPrincipal.Children.Add(campo.Elemento);
            }
        }



    }
}
