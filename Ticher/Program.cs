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

            MainContext.dictionaryDir = args[0];
            MainContext.pagesDir = args[1];
            MainContext.port = args[2]; 
            Dictionary.DictionarySet.getQuiz(9);
            Console.WriteLine("dictionary is load");
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

    static class MainContext
    {
        public static string pagesDir { get; set; }
        public static string dictionaryDir { get; set; }
        public static string  port { get; set; } 

    }
}
