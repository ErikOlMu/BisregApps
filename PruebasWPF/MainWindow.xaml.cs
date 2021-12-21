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
using System.Windows.Documents;
using System.Printing;

namespace PruebasWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

           

           

            flowDoc.Background = Brushes.White;
            

            Table table = new Table();
            TableRowGroup tableRowGroup = new TableRowGroup();
            
            for (int i = 0; i < 5; i++)
            {
                TableRow rowDefinition = new TableRow();
                
                for (int y = 0; y < 2; y++)
                {
                    TableCell tableCell = new TableCell();
                    BlockUIContainer contenedor = new BlockUIContainer();

                    Border border = new Border();
                    border.BorderBrush = Brushes.Black;
                    Canvas canvas = new Canvas();
                    border.BorderThickness = new Thickness(2);

                    LengthConverter lc = new LengthConverter();
                    double convertedw = (double)new LengthConverter().ConvertFrom("10,5cm");
                    double convertedh = (double)new LengthConverter().ConvertFrom("7,2cm");

                    canvas.Width = convertedw;
                    canvas.Height = convertedh;
                    

                    TextBlock textBlock = new TextBlock();
                    textBlock.Text = i + "erik" + y;
                    textBlock.FontWeight = FontWeights.Bold;
                    textBlock.FontSize = 75;
                    Canvas.SetLeft(textBlock, 100);
                    Canvas.SetTop(textBlock, 100);
                    canvas.Children.Add(textBlock);

                    border.Child = canvas;


                    contenedor.Child = border;
                    tableCell.Blocks.Add(contenedor);
                    rowDefinition.Cells.Add(tableCell);
                }
                
                tableRowGroup.Rows.Add(rowDefinition);

            }



            table.RowGroups.Add(tableRowGroup);

            flowDoc.Blocks.Add(table);
            flowDoc.Name = "Erik";


            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog().Value)
            {

                flowDoc.PageHeight = printDialog.PrintableAreaHeight;
                flowDoc.PageWidth = printDialog.PrintableAreaWidth;
                IDocumentPaginatorSource idocument = flowDoc as IDocumentPaginatorSource;

                printDialog.PrintDocument(idocument.DocumentPaginator, "Printing FlowDocument");
            }

        }


    }
}
