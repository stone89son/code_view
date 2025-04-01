using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMyLib.Helpers
{
    public class FileHelper
    {
        public static void WriteCSV(string savePath, List<string> lines)
        {
            var csv = new StringBuilder();
            foreach (var line in lines)
            {
                csv.AppendLine(line);
            }
            File.WriteAllText(savePath, csv.ToString(), Encoding.UTF8);
        }
        public static string[] ReadCSV(string readPath)
        {
           return File.ReadAllLines(readPath, Encoding.UTF8);
        }
        public static string[] ReadText(string savePath)
        {
            return File.ReadAllLines(savePath, Encoding.UTF8);
        }
    }
}
