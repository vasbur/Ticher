﻿using System;
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
            StreamReader st = new StreamReader("C:\\GIT\\Ticher\\Ticher\\WebServer\\Error404.html");
            string result = "";
            while (!st.EndOfStream)
                result += st.ReadLine();

            return result;
        }
    }
}
