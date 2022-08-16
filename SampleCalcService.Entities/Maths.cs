using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SampleCalcService.Entities
{
    [Serializable, XmlRoot(ElementName = "Maths", DataType = "string", IsNullable = false), XmlType("Maths")]
    public class Maths
    {
        [XmlElement("Opertaion")]
        public List<Operations> Operation { get; } = new List<Operations>();
        [XmlElement("Value")]
        public List<int> Value { get; set; }
    }
    public class Operations
    {

        [XmlAttribute("ID")]
        public string ops { set; get; }
    }
}
