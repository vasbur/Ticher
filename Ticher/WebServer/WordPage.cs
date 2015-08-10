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
                q = User.GetNextQuiz();

            result = result.Replace("$word$", q.word);
            result = result.Replace("$ansverNumber$", q.ansverNumber.ToString());
            string currentPageLink = "\\quize?sid=" + User.sid.ToString() + "&page=" + (User.quizSet.Count).ToString();
       
            for (int i = 0; i < 7; i++)
            {
                result = result.Replace("$translation"+i.ToString()+"$", q.translationList[i]);
                result = result.Replace("$link" + i.ToString() + "$", currentPageLink + "&ansver=" + i.ToString());

                result = result.Replace("$classes" + i.ToString() + "$", getclasses(q, i));

            }
            
            result = result.Replace("$currentPage$", currentPageLink); 

            string nextPageLink;
            if (page==12)
                nextPageLink = "\\result?sid=" + User.sid.ToString();
            else 
                nextPageLink = "\\quize?sid="+User.sid.ToString()+"&page="+(User.quizSet.Count+1).ToString();

            result = result.Replace("$nextpage$", nextPageLink);

            if (q.ansvers.Count > 0)
                result = result.Replace("visibility:hidden", "");

            result = result.Replace("$n$", page.ToString()); 

            result = result.Replace("$log$", "оценка количества слов: " + User.ditionaryEstimate(false).ToString()+
                " оченка частоты: " + User.ditionaryEstimate(true).ToString());
       //     result = result.Replace("$log$", ""); 
            return result;

        }

        static private string getclasses(Quiz q, int ind)
        {
            if ((q.ansvers.Count>0) && (q.ansverNumber == ind))
                return "correct";
            else if (q.ansvers.Where(x => (x == ind)).ToList().Count == 0)
                return "blank";
            else
                return "wrong";


        }
    }
}
