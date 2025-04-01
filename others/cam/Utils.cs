using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSoftwareConfirmADB
{
    public class Utils
    {
        public static string ToPhoneInfoProperty(string property, string resultText)
        {
            using (StringReader sr = new StringReader(resultText))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] propertyValue = line.Split(':');
                    if (propertyValue.Length > 1)
                    {
                        if (propertyValue[0].Trim() == property)
                        {
                            string value = propertyValue[1];
                            value = value.Replace("[", "");
                            value = value.Replace("]","");
                            return value.Trim();
                        }
                    }

                }
            }
            return null;
        }
        public static object GetPropValue(object src, string propName)
        {
            try
            {
                if (propName == null) return null;
                var propety = src.GetType().GetProperty(propName);
                if (propety != null)
                    return propety.GetValue(src, null);
                else return null;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static void SetPropValue(object src, string propName, object value)
        {
            var prop = src.GetType().GetProperty(propName);
            Type type = prop.PropertyType;
            PropertyInfo propertyInfo = src.GetType().GetProperty(prop.Name);
            if (prop == null)
            {
                return;
            }

            if (value == null)
            {
                propertyInfo.SetValue(src, value, null);
                return;
            }
            if (Nullable.GetUnderlyingType(type) != null)
            {
                var nullType = Nullable.GetUnderlyingType(type);
                var valueNull = Convert.ChangeType(value, nullType);
                propertyInfo.SetValue(src, valueNull, null);
            }
            else
            {
                propertyInfo.SetValue(src, Convert.ChangeType(value, type), null);
            }
        }
        public static T MoveObjectValue<T>(T objFrom, T objTo)
        {
            PropertyInfo[] lstPropertyInfo = objFrom.GetType().GetProperties();

            foreach (var propertyInfo in lstPropertyInfo)
            {
                object value = propertyInfo.GetValue(objFrom, null);

                Type type = propertyInfo.PropertyType;
                if (value == null)
                {
                    propertyInfo.SetValue(objTo, value, null);
                }
                else
                {
                    if (Nullable.GetUnderlyingType(type) != null)
                    {
                        var nullType = Nullable.GetUnderlyingType(type);
                        var valueNull = Convert.ChangeType(value, nullType);
                        propertyInfo.SetValue(objTo, valueNull, null);
                    }
                    else
                    {
                        propertyInfo.SetValue(objTo, Convert.ChangeType(value, type), null);
                    }

                }
            }
            return objTo;
        }
        public static bool IsBackGround(Mat frameMat)
        {
            return false;
            //Bitmap image = BitmapConverter.ToBitmap(frameMat);
            //LuminanceSource source = new BitmapLuminanceSource(image);
            //BinaryBitmap bitmap = new BinaryBitmap(new HybridBinarizer(source));
            //try
            //{
            //    MultiFormatReader _multiFormatReader = new MultiFormatReader();
            //    Result result = _multiFormatReader.decode(bitmap);
            //    if (result != null)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //catch (System.NullReferenceException ex)
            //{
            //    return false;
            //}
        }
    }
}
