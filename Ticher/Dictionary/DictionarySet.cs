using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticher.Dictionary
{
    class Quiz
    {
        public string word { get; set; }
        public List<string> translationList;
        public int ansverNumber; 

    }
    class DictionarySet
    {
        List<DictionaryItem> itemList;

        public DictionarySet()
        {
            itemList = new List<DictionaryItem>();
            itemList.Add(new DictionaryItem("table", "стол"));
            itemList.Add(new DictionaryItem("house", "дом"));
            itemList.Add(new DictionaryItem("cat", "кошка"));
            itemList.Add(new DictionaryItem("dog", "собака"));
            itemList.Add(new DictionaryItem("mouse", "мышь"));
            itemList.Add(new DictionaryItem("computer", "компьютер"));
            itemList.Add(new DictionaryItem("love", "любовь"));
            itemList.Add(new DictionaryItem("pen", "ручка"));
            itemList.Add(new DictionaryItem("knife", "нож"));

        }

        public Quiz getQuiz()
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
