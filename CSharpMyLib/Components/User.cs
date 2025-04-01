using CSharpMyLib.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharpMyLib.Components
{
    public class User
    {
        private static string _filePath = AppDomain.CurrentDomain.BaseDirectory + @"Data\User.json";

        public static T GetInitObjectD<T>()
        {
            return JsonHelper.GetInitObjectJsonTextD<T>(_filePath);
        }
        public static string GetByKey(string key)
        {
            return JsonHelper.GetByKey(_filePath, key);
        }
        public static string GetByKeyFormat(string key, string insertStr)
        {
            return JsonHelper.GetByKeyFormat(_filePath, key, insertStr);
        }
        public static void Update<T>(T obj)
        {
            JsonHelper.UpdateJsonText<T>(_filePath, obj);
        }

    }
}
