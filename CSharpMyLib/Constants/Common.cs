using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMyLib.Constants
{
    public class Common
    {
  
        public static string FolderNameSave => $"{DateTime.Now.ToString("yyyyMMdd")}";
        public static Encoding ShiftJIS => Encoding.GetEncoding("Shift-JIS");

    }
}
