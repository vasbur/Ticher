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

        private string GetResponseString(HttpListenerRequest Request)
        {
            string rowUrl = Request.RawUrl;
            String ResponseString = "";

            if (rowUrl == "/")
                ResponseString = MainPage.getPage();
            else if (rowUrl == "/startQuize")
            {
                UserData user = UserCasheTools.getNewUser();
                ResponseString = WordPage.GetPage(user, 1);
            }
            else if (rowUrl.IndexOf("/quize") > -1)
            {
                string sid = Request.QueryString["sid"];
                int page = int.Parse(Request.QueryString["page"]);
                string ansver = Request.QueryString["ansver"];

                UserData user = UserCasheTools.getUser(sid);

                if (user == null)
                    throw new PageNotFoundExeption();

                if (user.quizSet.Count >= page)
                {
                    Quiz q = user.quizSet[page - 1];
                    if ( (ansver != null) && (q.ansvers.Count==0))
                    {
                        int numAnsver = int.Parse(ansver);
                        if (q.ansvers.Where(x => x == numAnsver).ToList().Count == 0)
                            q.ansvers.Add(numAnsver);
                    }
                }
                ResponseString = WordPage.GetPage(user, page);
            }
            else if (rowUrl.IndexOf("/result") > -1)
            {
                string sid = Request.QueryString["sid"];
                UserData user = UserCasheTools.getUser(sid);

                if (user == null)
                    throw new PageNotFoundExeption();

                ResponseString = ResultPage.GetPage(user);
            }
            else
                throw new PageNotFoundExeption(); 

            return ResponseString;
        }
        public ResponseThread(HttpListenerContext ListenerContext)
        {
            HttpListenerResponse Response = ListenerContext.Response;
            
            string ResponseString;

            try
            {
                ResponseString = GetResponseString(ListenerContext.Request);
            }

            catch (PageNotFoundExeption e)
            {
                ResponseString = Error404.getPage(); 
            }

            catch (Exception e)
            {
                ResponseString = Error503.getPage(e.Message+e.StackTrace);
            }

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

    class PageNotFoundExeption : Exception
    { }

}
