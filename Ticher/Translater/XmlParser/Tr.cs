using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ticher.Translater.XmlParser
{
    public class Tr
    {
        [XmlElement(ElementName = "text")]
        public Text text { get; set; }

    }
}
