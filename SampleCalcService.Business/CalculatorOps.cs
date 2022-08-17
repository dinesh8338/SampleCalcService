using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using SampleCalcService.Entities;
using SampleCalcService.Entities.Enum;
using SampleCalcService.DAL.Repository;

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

        public string CalcProcess(XElement value) {
            var xmldata = FromXElement<Maths>(value);
            for (int i= 0; i < xmldata.Operation.Count; i++)
            {
                var myenum = (CalcEnum)Enum.Parse(typeof(CalcEnum), xmldata.Operation[i].ID);
                switch (myenum)
                {
                    case CalcEnum.Plus:
                        var result = new CalcRepository().AdditionOperation(xmldata.Operation[i].ID, xmldata.Operation[i].Value);
                        break;
                    case CalcEnum.Subraction:
                        break;
                    case CalcEnum.Multiplication:
                        break;
                    case CalcEnum.Division:
                        break;

                }

            }
            return null;
        }

    }
}
