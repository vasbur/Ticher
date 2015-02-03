using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticher.WebServer
{
    class Error404
    {
        static public string getPage()
        {
            StreamReader st = new StreamReader("C:\\GIT\\GoodProjects\\lastfmRecommedizer\\lastfmRecommedizer\\lastfmRecommedizer\\WebServer\\Error404.html");
            string result = "";
            while (!st.EndOfStream)
                result += st.ReadLine();

            return result;
        }
    }
}
