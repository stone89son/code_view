using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMyLib
{
    public class UtilsLib
    {
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
        public static void DeleteListFile(List<string> lstPathFileDelete)
        {
            foreach (var pathFileDelete in lstPathFileDelete)
            {
                File.Delete(pathFileDelete);
            }
        }

        public List<string> GetFileByCreateDate(string path, DateTime byDate)
        {
            List<string> lstResult = new List<string>();
            return lstResult;
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
            return objTo;
        }
    }
}
