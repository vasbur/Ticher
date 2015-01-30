using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ticher.Translater.XmlParser
{
    public class Text
    {
        [XmlText]
        public string name { get; set; }

    }
}
