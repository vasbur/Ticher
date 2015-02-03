using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticher.WebServer
{
    class MainPage
    {
        static public string getPage()
        {
            StreamReader st = new StreamReader("C:\\GIT\\Ticher\\Ticher\\WebServer\\mainPage.html");
            string result = "";
            while (!st.EndOfStream)
                result += st.ReadLine();

            return result;
        }
    }
}
