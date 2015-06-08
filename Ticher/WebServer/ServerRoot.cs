using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ticher.WebServer
{
    class ServerRoot
    {
        HttpListener Listener;

        static void ClientThread(Object StateInfo)
        {
            HttpListenerContext ThreadData = (HttpListenerContext)StateInfo;
            new ResponseThread(ThreadData);
        }

        public ServerRoot()
        {
            Listener = new HttpListener();
            Listener.Prefixes.Add("http://*:" + 555+ "/");
            Listener.Start();

            while (true)
            {
                HttpListenerContext ListenerContext = Listener.GetContext();
                ThreadPool.QueueUserWorkItem(new WaitCallback(ClientThread), ListenerContext);
            }
        }

        ~ServerRoot()
        {
            if (Listener != null)
            {
                Listener.Stop();
            }
        }
    }
}
