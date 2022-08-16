using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SampleCalcService.Business
{
    public class CalculatorOps
    {
        public static T FromXElement<T>(XElement xElement)
        {
            try
            {
                XmlRootAttribute xRoot = new XmlRootAttribute();
                xRoot.ElementName = "Maths";
                xRoot.IsNullable = true;
                var xmlSerializer = new XmlSerializer(typeof(T), xRoot);
                return (T)xmlSerializer.Deserialize(xElement.CreateReader());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
