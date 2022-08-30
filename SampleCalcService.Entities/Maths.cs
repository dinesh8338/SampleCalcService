using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SampleCalcService.Entities
{
    [XmlRoot(ElementName = "Operation")]
    public class Operation
    {
        [XmlElement(ElementName = "Operation")]
        public Operation Operation_Sub { get; set; }
        [XmlElement(ElementName = "Value")]
        public List<int> Value { get; set; }

        [XmlAttribute(AttributeName = "ID")]
        public string ID { get; set; }

        [XmlText]
        public string Text { get; set; }
        [XmlElement(ElementName = "Result")]
        public string Result { get { return result; } set { result = value; } }

        private string result;
    }

    [XmlRoot(ElementName = "Maths")]
    public class Maths
    {
        public Maths()
        {
            this.Operation = new List<Operation>();
        }
        [XmlElement(ElementName = "Operation")]
        public List<Operation> Operation { get; set; }
    }


    //[XmlRoot(ElementName = "Operation")]
    //public class Operation
    //{
    //    [XmlElement(ElementName = "Value")]
    //    public List<string> Value { get; set; }
    //    [XmlAttribute(AttributeName = "ID")]
    //    public string ID { get; set; }
    //    [XmlElement(ElementName = "Result")]
    //    public string Result { get { return result; } set { result = value; } }
    //    private string result;
    //}

    //[XmlRoot(ElementName = "Maths")]
    //public class Maths
    //{
    //    [XmlElement(ElementName = "Operation")]
    //    public Operation Operation { get; set; }
    //}
}
