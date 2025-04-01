using CSharpMyLib.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpMyLib.Components
{
    public class FileLog
    {
        public static void Write(string str)
        {
            string logPath = User.GetByKey("LogPath");
            string pathFile = logPath + "//" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            if (Directory.Exists(logPath))
            {
                List<string> lst = new List<string>();
                lst.Add(str);
                File.AppendAllLines(pathFile, lst, Common.ShiftJIS);
            }
            else
            {
                MessageBox.Show("LogPath not found!");
            }
        }

        public static void WriteByPath(string logPath, string str)
        {
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }
            string pathFile = logPath + "//" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            if (Directory.Exists(logPath))
            {
                List<string> lst = new List<string>();
                lst.Add(str);
                File.AppendAllLines(pathFile, lst, Common.ShiftJIS);
            }
            else
            {
                MessageBox.Show("LogPath not found!");
            }
        }

        public static void WriteMachi(string str)
        {
            string logPath = User.GetByKey("LogPath");


            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }

            if (Directory.Exists(logPath))
            {
                string machineName = logPath + "//" + Environment.MachineName;
                if (!Directory.Exists(logPath))
                {
                    Directory.CreateDirectory(machineName);
                }

                string pathFile = machineName + "//" + DateTime.Now.ToString("yyyyMMdd") + ".log";

                List<string> lst = new List<string>();
                lst.Add(str);
                if (!File.Exists(pathFile))
                {
                    File.Create(pathFile);
                }
                File.AppendAllLines(pathFile, lst, Common.ShiftJIS);
            }
            else
            {
                MessageBox.Show("LogPath not found!");
            }
        }
        public static void WriteByPathFileName(string logPath, string str)
        {
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }
            string pathFile = logPath + "//" + User.GetByKey("LogNameFile");
            if (Directory.Exists(logPath))
            {
                List<string> lst = new List<string>();
                lst.Add(str);
                File.AppendAllLines(pathFile, lst, Common.ShiftJIS);
            }
            else
            {
                MessageBox.Show("LogPath not found!");
            }
        }
    }
}
