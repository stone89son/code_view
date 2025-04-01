using CSharpMyLib.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerModeCam
{
    public class Constant
    {
        public static string CAMERA_PROPERTY_PATH = Path.Combine(FOLDERS_DEFAULT.DataPath, "CameraProperty.json");
        public static string DEVICE_RANGE_COLOR_PATH = Path.Combine(FOLDERS_DEFAULT.DataPath, "DeviceRangeColor.json");
        

    }
}
