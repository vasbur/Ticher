using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ticher.WebServer
{
    class ResponseThread
    {
        public ResponseThread(HttpListenerContext ListenerContext)
        {
            HttpListenerResponse Response = ListenerContext.Response;

            string rowUrl = ListenerContext.Request.RawUrl;
            String ResponseString = "";

            ResponseString = WordPage.GetPage();

            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(ResponseString);
            try
            {
                Response.OutputStream.Write(buffer, 0, buffer.Length);
                Response.OutputStream.Close();
            }
            catch
            {
                Console.WriteLine("на нет и суда нет");
            }
        }
     

    }
}
