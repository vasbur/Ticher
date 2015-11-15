using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticher.Translater;

namespace Ticher.Dictionary
{
   static class DictionarySet
    {
        static List<DictionaryItem> itemList;

        static private void LoadDict()
        {
            StreamReader sr = new StreamReader(MainContext.dictionaryDir+"\\data.csv");

         //   StreamWriter sw = new StreamWriter("C:\\GIT\\Ticher\\data_out.csv", true, Encoding.Default);

            for (int i = 0; i < 30000; i++)
            {
                string itemLine = sr.ReadLine();
                string word = itemLine.Substring(0, itemLine.IndexOf(";"));
                itemLine = itemLine.Substring(word.Length+1);
                string freq = itemLine.Substring(0, itemLine.IndexOf(";")).Replace(" ","");
                
                try
                {
                    string translation = TranslaterTools.GetTranslation(word);
                    if (translation != null)
                    {
                        string pos = TranslaterTools.GetPos(word);
                        itemList.Add(new DictionaryItem(word, pos, translation, float.Parse(freq), i));
                     //   sw.WriteLine(word + ";" + pos + ";" + translation + ";" + freq);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("trouble whith " + word);
                    Console.WriteLine(e.Message);
                }
            }

            //sw.Close();
        }

        static  DictionarySet()
        {
            itemList = new List<DictionaryItem>();
            LoadDict();
       
        }

        static public Quiz getQuiz( int numberOfVariant)
        {
            return getQuiz(0, int.MaxValue, numberOfVariant);
        }

        static private double TotalFrequency(List<DictionaryItem> dicionaryList)
        {
            double result = 0;
            foreach (DictionaryItem item in dicionaryList)
                result += item.frequensy;

            return result;

        }

        static public Quiz getQuiz(int beginRank, int endRank, int numberOfVariant)
        {

            List<DictionaryItem> currentList = itemList.Where(x => (x.rank >= beginRank) && (x.rank <= endRank)).ToList();

            double representFrequency = TotalFrequency(currentList) / TotalFrequency(itemList);
            Quiz result = new Quiz();

            Random ran = new Random();

            int item = ran.Next(currentList.Count);
            DictionaryItem trueResponse = currentList[item];
            result.word = trueResponse.word;
            result.ansverNumber = ran.Next(numberOfVariant);
            result.reprezentNumber = currentList.Count;
            result.reprezentFrecuency = representFrequency;
            result.rank = trueResponse.rank;

            for (int i = 0; i < numberOfVariant; i++)
                if (i == result.ansverNumber)
                    result.translationList.Add(trueResponse.translation);
                else
                {
                    List<string> listOfVar = GetVariantList(currentList, trueResponse, result);
                    if (listOfVar.Count > 0)
                        result.translationList.Add(listOfVar[ran.Next(listOfVar.Count)]);
                    else
                    {
                        List<string> listOfVar2 = GetVariantList(itemList, trueResponse, result);
                        if (listOfVar2.Count>0)
                            result.translationList.Add(listOfVar2[ran.Next(listOfVar.Count)]);
                        else                
                            result.translationList.Add("");
                    }
                }
            return result;
        
        }

        static private List<string> GetVariantList(List<DictionaryItem> DictList, DictionaryItem trueResponse, Quiz CurrentResult)
        {
            return DictList.Where(x => ((x.pos == trueResponse.pos) && (x.translation != trueResponse.translation)))
                                                     .Where(x => (isInto(CurrentResult.translationList, x.translation) == false))
                                                     .Select(x => x.translation).ToList();
        }

        static private bool isInto(List<string> translationList, string word)
        {
            return (translationList.Where(x => (x == word)).ToList().Count > 0);
        }
    }
}
