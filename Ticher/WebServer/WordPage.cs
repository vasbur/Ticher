using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticher.Dictionary;

namespace Ticher.WebServer
{
    static class WordPage
    {
        static public string GetPage()
        {
            StreamReader st = new StreamReader("C:\\GIT\\Ticher\\Ticher\\WebServer\\WordPage.html");
            string result = "";
            while (!st.EndOfStream)
                result += st.ReadLine();

            DictionarySet dict = new DictionarySet();
            Quiz q = dict.getQuiz();

            result = result.Replace("$word$", q.word);
            result = result.Replace("$ansverNumber$", q.ansverNumber.ToString());
            result = result.Replace("$translation0$", q.translationList[0]);
            result = result.Replace("$translation1$", q.translationList[1]);
            result = result.Replace("$translation2$", q.translationList[2]); 


            return result;

        }
    }
}
