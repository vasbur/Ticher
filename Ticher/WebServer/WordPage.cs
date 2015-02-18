using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticher.Dictionary;
using Ticher.UserCashe;

namespace Ticher.WebServer
{
    static class WordPage
    {
        static public string GetPage(UserData User, int page)
        {
            StreamReader st = new StreamReader("C:\\GIT\\Ticher\\Ticher\\WebServer\\WordPage.html");
            string result = "";
            while (!st.EndOfStream)
                result += st.ReadLine();


            Quiz q;

            if (User.quizSet.Count >= page)
                q = User.quizSet[page - 1];
            else
            {
                if (User.quizSet.Count < 10)
                    q = DictionarySet.getQuiz(0, 100, 9);
                else if (User.quizSet.Count < 20)
                    q = DictionarySet.getQuiz(101, 1000, 9);
                else if (User.quizSet.Count < 30)
                    q = DictionarySet.getQuiz(1001, 10000, 9);
                else 
                    q = DictionarySet.getQuiz(10000, int.MaxValue, 9);


                User.quizSet.Add(q);
            }

            result = result.Replace("$word$", q.word);
            result = result.Replace("$ansverNumber$", q.ansverNumber.ToString());

            for (int i = 0; i < 9; i++)
            {
                result = result.Replace("$translation"+i.ToString()+"$", q.translationList[i]);
                result = result.Replace("$bg" + i.ToString() + "$", getColor(q, i));

            }
            
            string currentPageLink = "\\quize?sid=" + User.sid.ToString() + "&page=" + (User.quizSet.Count).ToString();
            result = result.Replace("$currentPage$", currentPageLink); 

            string nextPageLink = "\\quize?sid="+User.sid.ToString()+"&page="+(User.quizSet.Count+1).ToString();
            result = result.Replace("$nextpage$", nextPageLink);

            if (q.ansvers.Where(x => (x == q.ansverNumber)).ToList().Count > 0)
                result = result.Replace("visibility:hidden", "");

            result = result.Replace("$log$", "оценка количества слов " + User.ditionaryEstimate().ToString());

            return result;

        }

        static private string getColor(Quiz q, int ind)
        {
            if (q.ansvers.Where(x => (x == ind)).ToList().Count == 0)
                return "white";
            else if (q.ansverNumber == ind)
                return "green";
            else
                return "red";


        }
    }
}
