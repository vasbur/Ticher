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
            MainContext.logfile = args[3]; 

            MainContext.startPage = 0;
            MainContext.startFB = 0;
            MainContext.endPage = 0;
            MainContext.endFB = 0; 

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
        public static string logfile { get; set; }

        public static int startPage { get; set; }
        public static int endPage {get; set;}
        public static int startFB { get; set; }
        public static int endFB { get; set; }

        public static void increaseStartPage()
        {
            startPage++;
        }

        public static void increaseEndPage()
        {
            endPage++;
        }
    }
}
