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

            for (int i = 0; i < 1000; i++)
            {
                string itemLine = sr.ReadLine();
                string word = itemLine.Substring(0, itemLine.IndexOf(";"));
                itemLine = itemLine.Substring(word.Length+1);
                string freq = itemLine.Substring(0, itemLine.IndexOf(";"));

                string translation = TranslaterTools.GetTranslation(word);
                itemList.Add(new DictionaryItem(word, translation, float.Parse(freq)));
            }

        }

        static  DictionarySet()
        {
            itemList = new List<DictionaryItem>();
            LoadDict();
       
        }

        static public Quiz getQuiz()
        {
            Quiz result = new Quiz();

            Random ran = new Random();

            int item = ran.Next(itemList.Count);
            DictionaryItem trueResponse = itemList[item];
            result.word = trueResponse.word;
            result.ansverNumber = ran.Next(0, 3);
            result.translationList = new List<string>();
            for (int i = 0; i < 3; i++)
                if (i == result.ansverNumber)
                    result.translationList.Add(trueResponse.translation);
                else
                {
                    int index = ran.Next(itemList.Count - 1);
                    if (index >= item) 
                        index++;
                    result.translationList.Add(itemList[index].translation);
                }
            
            return result;
        
        }
    }
}
