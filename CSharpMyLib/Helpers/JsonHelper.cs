using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using JsonSerializerTextJson = System.Text.Json.JsonSerializer;

namespace CSharpMyLib.Helpers
{
    public class JsonHelper
    {
        public static T GetInitObjectD<T>(string filePath)
        {
            try
            {
                string jsonString = File.ReadAllText(filePath);

                T t = JsonConvert.DeserializeObject<T>(jsonString);
                return t;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString());
                return default(T);
            }
        }
        public static T GetInitObjectJsonTextD<T>(string filePath)
        {
            try
            {
                string jsonString = File.ReadAllText(filePath);
                T t = JsonConvert.DeserializeObject<T>(jsonString);
                return t;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString());
                return default(T);
            }
        }

        public static string GetByKey(string filePath, string key)
        {
            string jsonString = File.ReadAllText(filePath);
            JObject t = JsonConvert.DeserializeObject<JObject>(jsonString);
            return (string)t[key];
        }
        public static string GetByKeyFormat(string filePath, string key, params object[] args)
        {
            return string.Format(GetByKey(filePath, key), args);
        }
        public static void Update<T>(string filePath, T updateObject)
        {
            try
            {
                string json = JsonConvert.SerializeObject(updateObject, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString());
            }
        }

        public static void UpdateJsonText<T>(string filePath, T updateObject)
        {
            try
            {
                string json = JsonSerializerTextJson.Serialize(updateObject, new JsonSerializerOptions() { WriteIndented = true });
                File.WriteAllText(filePath, json, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString());
            }
        }
    }
}
