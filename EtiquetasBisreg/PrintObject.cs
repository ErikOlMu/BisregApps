using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ghostscript.NET.Processor;
using Microsoft.Win32;

namespace EtiquetasBisreg
{
    public class PrintObject
    {

        public static void Start(string file)
        {
            // YOU NEED TO HAVE ADMINISTRATOR RIGHTS TO RUN THIS CODE

            string printerName = "Godex G500";
            string inputFile = file;

            using (GhostscriptProcessor processor = new GhostscriptProcessor())
            {
                List<string> switches = new List<string>();
                switches.Add("-empty");
                switches.Add("-dPrinted");
                switches.Add("-dBATCH");
                switches.Add("-dNOPAUSE");
                switches.Add("-dNOSAFER");
                switches.Add("-dNumCopies=1");
                switches.Add("-sDEVICE=mswinpr2");
                switches.Add("-sOutputFile=%printer%" + printerName);
                switches.Add("-f");
                switches.Add(inputFile);

                processor.StartProcessing(switches.ToArray(), null);
            }
        }
        private static string GetAcrobatReaderPath()
        {
            const string keyBase = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths";
            const string fileName = "AcroRd32.exe";

            var localMachine = Registry.LocalMachine;
            using (var fileKey = localMachine.OpenSubKey(string.Format(@"{0}\{1}", keyBase, fileName)))
            {
                if (fileKey != null)
                {
                    return fileKey.GetValue(string.Empty).ToString();
                }
            }
            throw new Exception(string.Format("no installation of {0} found", fileName));
        }

        public static bool PrintPdf(string file)
        {
            try
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = GetAcrobatReaderPath();
                // Registry.LocalMachine.OpenSubKey(
                   //     @"SOFTWARE\Microsoft\Windows\CurrentVersion" +
                     //   @"\App Paths\AcroRd32.exe").GetValue("").ToString();
                info.Arguments = string.Format("/h /t \"{0}\" \"{1}\"", file, "Godex G500");
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

