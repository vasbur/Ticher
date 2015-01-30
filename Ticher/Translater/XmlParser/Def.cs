using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ticher.Translater.XmlParser
{
    public class Def
    {
        [XmlAttribute(AttributeName = "pos")]
        public string pos { get; set; }

        [XmlElement(ElementName = "tr")]
        public List<Tr> tr { get; set; }

    }
}
