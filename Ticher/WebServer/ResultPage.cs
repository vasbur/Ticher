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
    static class ResultPage
    {
        static public string GetPage(UserData User)
        {
            StreamReader st = new StreamReader("C:\\GIT\\Ticher\\Ticher\\WebServer\\ResultPage.html");
            string result = "";
            while (!st.EndOfStream)
                result += st.ReadLine();


      
            result = result.Replace("$log$", "оценка количества слов: " + User.ditionaryEstimate(false).ToString()+
                " оченка частоты: " + User.ditionaryEstimate(true).ToString());

            return result;

        }

      
      
    }
}
