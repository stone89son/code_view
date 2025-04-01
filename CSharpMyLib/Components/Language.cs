using CSharpMyLib.Helpers;
using System;

namespace CSharpMyLib.Components
{
    public class Language
    {
        private static string _filePath= AppDomain.CurrentDomain.BaseDirectory + @"Resources\" + User.GetByKey("Lang") + ".json";

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
        public static string GetByKeyFormat(string key, params object[] args)
        {
            return JsonHelper.GetByKeyFormat(_filePath, key, args);
        }
    }
}
