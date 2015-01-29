using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticher.Dictionary
{
    class DictionaryItem
    {
        public string word { get; set; }
        public string translation { get; set; }

        public DictionaryItem(string word, string translation)
        {
            this.translation = translation;
            this.word = word;
        }
    }
}
