using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticher.Dictionary;

namespace Ticher.UserCashe
{
    class UserData
    {
        public string  sid { get; set; }
        public List<Quiz> quizSet { get; set; }

        private List<int> getRankList()
        {
            List<int> result = new List<int>();
            result.Add(0);
            result.Add(300);
            result.Add(2000);
            result.Add(5000);
            result.Add(12000);
            result.Add(30000);

            return result; 
        }
        public Quiz GetNextQuiz()
        {

            List<int> rankList = getRankList();

            for (int i = 1; i < rankList.Count; i++)
            {
                int currentRank = rankList[i];
                int prevRank = rankList[i - 1];

                List<Quiz> trueQuises = quizSet.Where(x => (x.rank <= currentRank) && (x.rank > prevRank))
                    .Where(x => x.isTrueAnsver()).ToList();

                if (trueQuises.Count < 4)
                {

                    Quiz q = DictionarySet.getQuiz(prevRank, currentRank, 7);
                    quizSet.Add(q);
                    return q;
                }

            }


            return null;
        }


        public double ditionaryEstimate(bool isFreq)
        {
           List<int> reprezList = new List<int>();
           double totalCount = 0;

            foreach (Quiz q in quizSet)
                if (reprezList.Where(x => x == q.reprezentNumber).ToList().Count == 0)
                    reprezList.Add(q.reprezentNumber);

            foreach (int rep in reprezList)
            {
             
                List<Quiz> qset = quizSet.Where(x => (x.reprezentNumber == rep)).Where(x => x.ansvers.Count>0).ToList();
                int totalansver = (qset.Count() < 4) ? 4 : qset.Count();

                double sumData;
                if (!isFreq)
                    sumData = rep;
                else
                {
                    sumData = quizSet.Where(x => (x.reprezentNumber == rep)).ToList()[0].reprezentFrecuency;
                }

                if (totalansver > 0)
                {
                    int trueansver = qset.Where(x => x.isTrueAnsver()).ToList().Count;
                    totalCount += sumData * (double)trueansver / (double)totalansver;
                }
            }

             return totalCount;
        }

        private double getFrequensyEstimate(double p, int n, int degree)
        {
            return p;

            //double d = p * (1 - p) / n;
            //d = Math.Sqrt(d);

            //double pm = p + degree * 2* d;
 
            //pm =  (9 * pm - 1) / 8;

            //if (pm < 0)
            //    return 0;
            //else if (pm > 1)
            //    return 1;
            //else
            //    return pm;


        }

    }
}
