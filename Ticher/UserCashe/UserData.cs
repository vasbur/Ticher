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
                    totalCount += rep * trueansver / totalansver;
                }
            }

             return totalCount;
        }

    }
}
