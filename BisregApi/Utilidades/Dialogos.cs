using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Dialogs;
namespace BisregApi.Utilidades
{
    public static class Dialogos
    {
        public static string OpenFolder()
        {
            string Carpeta = "";
            try
            {
                var dialog = new CommonOpenFileDialog();
                dialog.Title = "Selecciona un Directorio";
                dialog.IsFolderPicker = true;
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    Carpeta = dialog.FileName;
                }
                return Carpeta;
            }
            catch (Exception)
            {
                return Carpeta;
            }
            
        }
        public static string OpenFile()
        {
            string Carpeta = "";
            try
            {
                var dialog = new CommonOpenFileDialog();
                dialog.IsFolderPicker = false;
                dialog.Multiselect = false;
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    Carpeta = dialog.FileName;
                }
                return Carpeta;
            }
            catch (Exception)
            {
                return Carpeta;
            }

        }
    }
}
