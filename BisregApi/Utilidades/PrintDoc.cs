using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace BisregApi.Utilidades
{
    public class PrintDoc
    {
        public static void Print(FlowDocument doc)
        {
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog().Value)
            {

                doc.PageHeight = printDialog.PrintableAreaHeight;
                doc.PageWidth = printDialog.PrintableAreaWidth;
                IDocumentPaginatorSource idocument = doc as IDocumentPaginatorSource;

                printDialog.PrintDocument(idocument.DocumentPaginator, "Printing FlowDocument");
            }
        }
    }
}
