using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CustomerModeCam
{
    public class ORCPyEngine
    {
        public static string RecognizeTextHttp(string fileName)
        {
            using (var client = new HttpClient())
            {
                FileInfo fileInfo = new FileInfo(fileName);
                client.BaseAddress = new Uri("http://127.0.0.1:5000/");
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var result = client.GetAsync("image-to-text-ja/" + fileInfo.Name);  // Blocking call!
                if (result.Result.IsSuccessStatusCode)
                {
                    string resultString = result.Result.Content.ReadAsStringAsync().Result;
                    resultString = resultString.Replace(" ", "");
                    return RemoveOtherString(resultString);
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        private static string RemoveOtherString(string strInput)
        {
            string correctStr = "ようこそ";
            correctStr = correctStr.ToUpper();
            strInput = strInput.ToUpper();

            char[] strInputchars = strInput.ToArray();
            string resultStr = string.Empty;
            for (int i = 0; i < strInputchars.Length; i++)
            {
                char item = strInputchars[i];
                if (correctStr.Contains(item))
                {
                    resultStr += item;
                }
            }
            return resultStr;
        }
    }
}
