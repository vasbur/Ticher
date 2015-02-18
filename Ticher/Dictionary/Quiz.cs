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
        public List<int> ansvers;
        public int reprezentNumber; 

        public Quiz()
        {
            translationList = new List<string>();
            ansvers = new List<int>();
        }

        public Boolean isTrueAnsver()
        {
            return ((ansvers.Count == 1) && (ansvers[0] == ansverNumber));
        }

    }
  
}
