using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSoftwareConfirmADB
{
    public class OCREngine
    {
        public static string RecognizeTextJa(string fileName)
        {
            
            Process p = new Process();
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.StartInfo.FileName = "tesseract.exe";
            p.StartInfo.Arguments = $"\"{fileName}\" stdout -l \"tessdata/jpn\"";
            p.Start();

            //--psm 6 --oem 3  --dpi 300
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            return output;
        }
    }
}
