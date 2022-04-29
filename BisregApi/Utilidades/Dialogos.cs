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
        public static string SaveFile()
        {
            string Carpeta = "";
            try
            {
                var dialog = new CommonSaveFileDialog();
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
        public static string SaveFile(string extension)
        {
            string Carpeta = "";
            try
            {
                var dialog = new CommonSaveFileDialog();
                dialog.DefaultExtension = extension;
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

        public static List<string> OpenFiles()
        {
            List<string> Carpeta = new List<string>();
            try
            {
                var dialog = new CommonOpenFileDialog();
                dialog.IsFolderPicker = false;
                dialog.Multiselect = true;
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    Carpeta = dialog.FileNames.ToList();
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
        public static string OpenFile(string predef)
        {
            string Carpeta = "";
            try
            {
                var dialog = new CommonOpenFileDialog();
                dialog.IsFolderPicker = false;
                dialog.Multiselect = false;
                dialog.DefaultFileName = predef;
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
