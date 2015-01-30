using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ticher.Translater.XmlParser
{
     [XmlRoot(ElementName = "DicResult")]
    public class DicResult
    {
         [XmlElement(ElementName = "def")]
         public Def def { get; set; }

    }
}
