using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace EtiquetasBisreg
{
    public class PrintObject
    {
        public static bool PrintPdf(string file, string printer)
        {
            try
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = Registry.LocalMachine.OpenSubKey(
                        @"SOFTWARE\Microsoft\Windows\CurrentVersion" +
                        @"\App Paths\AcroRd32.exe").GetValue("").ToString();
                info.Arguments = string.Format("/h /t \"{0}\" \"{1}\"", file, printer);
                info.CreateNoWindow = true;
                info.WindowStyle = ProcessWindowStyle.Hidden;

                Process p = new Process();
                p.StartInfo = info;
                p.Start();
                p.WaitForInputIdle();
                System.Threading.Thread.Sleep(3000);
                if (false == p.CloseMainWindow())
                    p.Kill();

                return true;
                File.Delete(file);
            }
            catch { }
            return false;
        }
       
    } 
}
