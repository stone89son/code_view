using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PsychSupSys.Shared.Helpers
{
    public class ObjectHelper
    {
        public static string GetFieldName<TModel, TField>(Expression<Func<TModel, TField>> propertyExpression)
        {
            var memberExpression = propertyExpression.Body as MemberExpression;
            if (memberExpression != null)
            {
                var propertyInfo = memberExpression.Member as PropertyInfo;
                if (propertyInfo != null)
                {
                    return propertyInfo.Name;
                }
            }

            throw new ArgumentException("Unable to extract field name from lambda expression.");
        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static string GetMemberName<T, TValue>(Expression<Func<T, TValue>> memberAccess)
        {
            return ((MemberExpression)memberAccess.Body).Member.Name;
        }

        public static object GetPropValue(object src, string propName)
        {
            try
            {
                var prop = src.GetType().GetProperty(propName);
                if (prop == null)
                {
                    throw new Exception($"The property named :{propName} does not exist.");
                }
                else
                {
                    return prop.GetValue(src, null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SetPropValue(object src, string propName, object value)
        {
            var prop = src.GetType().GetProperty(propName);
            if (prop == null)
            {
                throw new Exception($"The property named :{propName} does not exist.");
            }
            if (value == null)
            {
                prop.SetValue(src, value, null);
                return;
            }
            else
            {
                Type type = prop.PropertyType;
                Type typeSetValue = value.GetType();
                if (typeSetValue != type)
                {
                    var originType = Nullable.GetUnderlyingType(type);
                    var originTypeValue = Convert.ChangeType(value, originType);
                    prop.SetValue(src, originTypeValue, null);
                }
                else
                {
                    prop.SetValue(src, value, null);
                }
            }
        }

        public static T MoveObjectValue<T>(T objSrc, T objDest)
        {
            PropertyInfo[] lstPropertyInfo = objSrc.GetType().GetProperties();

            foreach (var propertyInfo in lstPropertyInfo)
            {
                object value = propertyInfo.GetValue(objSrc, null);
                SetPropValue(objDest, propertyInfo.Name, value);
            }
            return objDest;
        }

        public static TTo MoveObjectValue<TFrom, TTo>(TFrom objSrc, TTo objDest, Action<TFrom, TTo> mapAction = null)
        {
            PropertyInfo[] fromProperties = typeof(TFrom).GetProperties();
            PropertyInfo[] toProperties = typeof(TTo).GetProperties();

            foreach (var fromProperty in fromProperties)
            {
                PropertyInfo toProperty = toProperties.FirstOrDefault(p => p.Name == fromProperty.Name && p.PropertyType == fromProperty.PropertyType);
                if (toProperty != null 
                    && toProperty.CanWrite)
                {
                    object value = fromProperty.GetValue(objSrc, null);
                    toProperty.SetValue(objDest, value, null);
                }
            }

            mapAction?.Invoke(objSrc, objDest);

            return objDest;
        }
    }
}
