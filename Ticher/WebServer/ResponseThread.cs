using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Ticher.Dictionary;
using Ticher.UserCashe;

namespace Ticher.WebServer
{
    class ResponseThread
    {
        public ResponseThread(HttpListenerContext ListenerContext)
        {
            HttpListenerResponse Response = ListenerContext.Response;

            string rowUrl = ListenerContext.Request.RawUrl;
            String ResponseString = "";

            if (rowUrl == "/")
                ResponseString = MainPage.getPage();
            else if (rowUrl == "/startQuize")
            {
                UserData user = UserCasheTools.getNewUser();
                ResponseString = WordPage.GetPage(user, 1);
            }
            else if (rowUrl.IndexOf("/quize")>-1) 
            {
                string sid   = ListenerContext.Request.QueryString["sid"];
                int page     = int.Parse(ListenerContext.Request.QueryString["page"]);
                string ansver   = ListenerContext.Request.QueryString["ansver"];

                UserData user = UserCasheTools.getUser(sid);
                if (user.quizSet.Count >= page)
                {
                    Quiz q = user.quizSet[page - 1];
                    if (ansver != null)
                    {
                        int numAnsver = int.Parse(ansver);
                        if (q.ansvers.Where(x => x == numAnsver).ToList().Count == 0)
                            q.ansvers.Add(numAnsver); 
                    }
                }
                ResponseString = WordPage.GetPage(user, page);
            }
            else
                ResponseString = Error404.getPage();



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
