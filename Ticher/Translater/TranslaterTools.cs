using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Ticher.Translater.XmlParser;

namespace Ticher.Translater
{
    static class TranslaterTools
    {
        static public string GetTranslation(string word)
        {
            string filename = getDataFile(word);
            DicResult trans = getTranslationData(filename);

            if ((trans.def == null) || (trans.def.tr.Count == 0))
            {
                Console.WriteLine(" no trans for " + word);
                return null;
            }

            return trans.def.tr[0].text.name;

        }

        static public string GetPos(string word)
        {
            string filename = getDataFile(word);
            DicResult trans = getTranslationData(filename);

            if ((trans.def == null) || (trans.def.tr.Count == 0))
            {
                Console.WriteLine(" no trans for " + word);
                return null;
            }

            return trans.def.pos;

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

            try
            {
                StreamWriter SW = new StreamWriter(path);
                SW.Write(s);
                SW.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }

           
            return path; 
 
        }
    
    static private DicResult getTranslationData(string filename)
        {
            StreamReader SR = new StreamReader(filename);
            string str = SR.ReadToEnd();

            XmlSerializer xml = new XmlSerializer(typeof(DicResult));
            DicResult  res = (DicResult)xml.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(str)));

            return res;
        }

    
    }
}
