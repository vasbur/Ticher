using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticher.Translater;

namespace Ticher.Dictionary
{
    class Quiz
    {
        public string word { get; set; }
        public List<string> translationList;
        public int ansverNumber; 

    }
   static class DictionarySet
    {
        static List<DictionaryItem> itemList;

        static private void LoadDict()
        {
            StreamReader sr = new StreamReader("C:\\GIT\\Ticher\\data.csv");

            for (int i = 0; i < 500; i++)
            {
                string itemLine = sr.ReadLine();
                string word = itemLine.Substring(0, itemLine.IndexOf(";"));
                itemLine = itemLine.Substring(word.Length+1);
                string freq = itemLine.Substring(0, itemLine.IndexOf(";"));

                try
                {
                    string translation = TranslaterTools.GetTranslation(word);
                    string pos = TranslaterTools.GetPos(word); 
                    if (translation != null)
                        itemList.Add(new DictionaryItem(word, pos, translation, float.Parse(freq)));
                }
                catch (Exception e)
                {
                    Console.WriteLine("trouble whith " + word);
                    Console.WriteLine(e.Message);
                }
            }

        }

        static  DictionarySet()
        {
            itemList = new List<DictionaryItem>();
            LoadDict();
       
        }

        static public Quiz getQuiz(int numberOfVariant)
        {
            Quiz result = new Quiz();

            Random ran = new Random();

            int item = ran.Next(itemList.Count);
            DictionaryItem trueResponse = itemList[item];
            result.word = trueResponse.word;
            result.ansverNumber = ran.Next(3);
            result.translationList = new List<string>();

            
            for (int i = 0; i < numberOfVariant; i++)
                if (i == result.ansverNumber)
                    result.translationList.Add(trueResponse.translation);
                else
                {
                    List<string> listOfVar = itemList.Where(x => ((x.pos == trueResponse.pos) && (x.word != trueResponse.word)))
                                                     .Where(x => (isInto(result.translationList, x.translation)==false))
                                                     .Select(x => x.translation).ToList();
                    if (listOfVar.Count > 0)
                        result.translationList.Add(listOfVar[ran.Next(listOfVar.Count)]);
                    else
                        result.translationList.Add("");
                }
            return result;
        
        }

        static private bool isInto(List<string> translationList, string word)
        {
            return (translationList.Where(x => (x == word)).ToList().Count > 0);
        }
    }
}
