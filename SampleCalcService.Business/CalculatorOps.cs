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
using System.IO;
using System.Net.Http;
using System.Net;

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

        public static XElement ToXElement<T>(object obj)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (TextWriter streamWriter = new StreamWriter(memoryStream))
                {
                    var xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(streamWriter, obj);
                    return XElement.Parse(Encoding.ASCII.GetString(memoryStream.ToArray()));
                }
            }
        }

        public string CalcProcess(XElement value) 
        {
            if(value != null)
            {
                var xmldata = FromXElement<Maths>(value);
                for (int i = 0; i < xmldata.Operation.Count; i++)
                {
                    var myenum = (CalcEnum)Enum.Parse(typeof(CalcEnum), xmldata.Operation[i].ID);
                    switch (myenum)
                    {
                        case CalcEnum.Plus:
                            var addRes = new CalcRepository().AdditionOperation(xmldata.Operation[i].Value);
                            xmldata.Operation[i].Result = addRes;
                            break;
                        case CalcEnum.Subraction:
                            var subRes = new CalcRepository().SubractionOperation(xmldata.Operation[i].Value);
                            xmldata.Operation[i].Result = subRes;
                            break;
                        case CalcEnum.Multiplication:
                            var mulRes = new CalcRepository().MultiplicationOperation(xmldata.Operation[i].Value);
                            xmldata.Operation[i].Result = mulRes;
                            break;
                        case CalcEnum.Division:
                            var divRes = new CalcRepository().DivisionOperation(xmldata.Operation[i].Value);
                            xmldata.Operation[i].Result = divRes;
                            break;

                    }

                }
                return ToXElement<Maths>(xmldata).ToString();
            }
            else
            {
                return null;
            }
            
        }
    }
}
