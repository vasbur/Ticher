using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticher.Dictionary;

namespace Ticher
{
    class Program
    {
        static void Main(string[] args)
        {
            DictionarySet ds = new DictionarySet(); 
            try
            {
                WebServer.ServerRoot srv = new WebServer.ServerRoot();
            }
            catch (Exception ex)
            {
                Console.WriteLine("не удалось запустить сервер по причине: " + ex.Message);
                Console.ReadKey();
            }
            Console.WriteLine("Сервер запущен");
        }
    }
}
