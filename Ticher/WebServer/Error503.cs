using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticher.WebServer
{
    class Error503
    {
        static public string getPage(string errorDescription)
        {
            StreamReader st = new StreamReader("C:\\GIT\\Ticher\\Ticher\\WebServer\\Error503.html");
            string result = "";
            while (!st.EndOfStream)
                result += st.ReadLine();

            result = result.Replace("$error$", errorDescription); 

            return result;
        }
    }
}
