using CSharpMyLib.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpMyLib.Components
{
    public class FormLocation
    {
        private static string _filePath(string nameForm) { return AppDomain.CurrentDomain.BaseDirectory+ $@"Data\{nameForm}Init.json"; }
        public static void Init(Form form)
        {
            string pathName = _filePath(form.Name);
            if (File.Exists(pathName))
            {
                Point location = JsonHelper.GetInitObjectJsonTextD<Point>(pathName);
                if (location.X < 0)
                {
                    location.X = form.Location.X;
                }
                if (location.Y < 0)
                {
                    location.Y = form.Location.Y;
                }
                form.Location = location;

            }
            else
            {
                Save(form);
            }
        }

        //public static void GetLocation(Form form)
        //{
        //    JsonHelper.Update<Point>(_filePath(form.Name), form.Location);
        //}
        public static void Save(Form form)
        {
            JsonHelper.UpdateJsonText<Point>(_filePath(form.Name), form.Location);
        }

        public static void PlaceLowerRight(Form form)
        {
            Screen rightmost = Screen.AllScreens[0];
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.WorkingArea.Right > rightmost.WorkingArea.Right)
                    rightmost = screen;
            }

            form.Left = rightmost.WorkingArea.Right - form.Width;
            form.Top = rightmost.WorkingArea.Bottom - form.Height;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
    }
}
