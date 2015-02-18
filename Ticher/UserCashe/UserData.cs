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

        public int ditionaryEstimate()
        {
            List<int> reprezList = new List<int>();
            int totalCount = 0;

            foreach (Quiz q in quizSet)
                if (reprezList.Where(x => x == q.reprezentNumber).ToList().Count == 0)
                    reprezList.Add(q.reprezentNumber);

            foreach (int rep in reprezList)
            {
             
                List<Quiz> qset = quizSet.Where(x => (x.reprezentNumber == rep)).Where(x => x.ansvers.Count>0).ToList();
                int totalansver = qset.Count();

                if (totalansver > 0)
                {
                    int trueansver = qset.Where(x => x.isTrueAnsver()).ToList().Count;
                    totalCount += (int)(rep * getFrequensyEstimate((double)trueansver / (double)totalansver, totalansver));
                }
            }

             return totalCount;
        }

        private double getFrequensyEstimate(double p, int n)
        {
            double d = p * (1 - p) / n;
            d = Math.Sqrt(d);

            double pm = p - 2 * d;
 
            pm =  (9 * pm - 1) / 8;

            return (pm < 0) ? 0 : pm;


        }

    }
}
