using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;


namespace BisregApi.Utilidades
{
    public class PrintDoc
    {
        public static void Print(FlowDocument doc)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.UserPageRangeEnabled = true;
                
                 IDocumentPaginatorSource idocument = doc as IDocumentPaginatorSource;
               

                DocumentPaginator paginator = idocument.DocumentPaginator;
                paginator.ComputePageCount();
                MessageBox.Show(paginator.PageCount+""); 
                if (printDialog.PageRangeSelection == PageRangeSelection.UserPages)
                {
                   paginator = new PageRangeDocumentPaginator(idocument.DocumentPaginator, printDialog.PageRange);
                }


                if (printDialog.ShowDialog().Value) printDialog.PrintDocument(paginator, "File");
                
            
        }
    }


    public class PageRangeDocumentPaginator : DocumentPaginator
    {
        private int _startIndex;
        private int _endIndex;
        private DocumentPaginator _paginator;
        public PageRangeDocumentPaginator(
          DocumentPaginator paginator,
          PageRange pageRange)
        {
            _startIndex = pageRange.PageFrom - 1;
            _endIndex = pageRange.PageTo - 1;
            _paginator = paginator;

            // Adjust the _endIndex
            _endIndex = Math.Min(_endIndex, _paginator.PageCount - 1);
        }
        public override DocumentPage GetPage(int pageNumber)
        {
            // Just return the page from the original
            // paginator by using the "startIndex"
            return _paginator.GetPage(pageNumber + _startIndex);
        }

        public override bool IsPageCountValid
        {
            get { return true; }
        }

        public override int PageCount
        {
            get
            {
                if (_startIndex > _paginator.PageCount - 1)
                    return 0;
                if (_startIndex > _endIndex)
                    return 0;

                return _endIndex - _startIndex + 1;
            }
        }

        public override Size PageSize
        {
            get { return _paginator.PageSize; }
            set { _paginator.PageSize = value; }
        }

        public override IDocumentPaginatorSource Source
        {
            get { return _paginator.Source; }
        }
    }
}

