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

            Quiz q = DictionarySet.getQuiz(9);

            result = result.Replace("$word$", q.word);
            result = result.Replace("$ansverNumber$", q.ansverNumber.ToString());
            result = result.Replace("$translation0$", q.translationList[0]);
            result = result.Replace("$translation1$", q.translationList[1]);
            result = result.Replace("$translation2$", q.translationList[2]);
            result = result.Replace("$translation3$", q.translationList[3]);
            result = result.Replace("$translation4$", q.translationList[4]);
            result = result.Replace("$translation5$", q.translationList[5]);
            result = result.Replace("$translation6$", q.translationList[6]);
            result = result.Replace("$translation7$", q.translationList[7]);
            result = result.Replace("$translation8$", q.translationList[8]); 


            return result;

        }
    }
}
