using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ticher.Translater
{
    static class TranslaterTools
    {
        static public string GetTranslation(string word)
        {
            getDataFile(word);
            return "xxx";

        }

        static private string getDataFile(string word)
        {
            string path = "C:\\GIT\\Ticher\\TranslationData\\"+word+".xml";
            try
            {
                StreamReader SR = new StreamReader(path);
                return path;
            }
            catch { }

            string apikey = "dict.1.1.20150130T114115Z.de5d40ac6c8cf588.8a98367d4ef3774714dc615033196188432d4963";
            string url = "https://dictionary.yandex.net/api/v1/dicservice/lookup?key="+apikey+"&lang=en-ru&text="+word;

            string s; 
            HttpWebRequest Request = (HttpWebRequest)HttpWebRequest.Create(url);
            Request.Timeout = int.MaxValue;
            try
            {
                HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
                Stream ResponseStream = Response.GetResponseStream();
                StreamReader sr = new StreamReader(ResponseStream, Encoding.UTF8);
                s = sr.ReadToEnd();
            }
            catch (Exception e)
            {
                Console.WriteLine("api error: " + url);
                throw e;
            }

            StreamWriter SW = new StreamWriter(path);
            SW.Write(s);
            SW.Close();

            return path; 
 
        }
    }
}
