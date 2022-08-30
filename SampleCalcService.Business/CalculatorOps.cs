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
using System.Reflection;

namespace SampleCalcService.Business
{
    public class CalculatorOps
    {
        public static T FromXElement<T>(XElement xElement, string rootElement)
        {
            try
            {
                XmlRootAttribute xRoot = new XmlRootAttribute();
                xRoot.ElementName = rootElement;
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
            Maths maths = new Maths();
            if(value != null)
            {
                maths = FromXElement<Maths>(value, "Maths");
                for (int i = 0; i < maths.Operation.Count; i++)
                {
                    ReadPropertiesRecursive(maths.Operation[i]);
                }
                return ToXElement<Maths>(maths).ToString();
            }
            else
            {
                return null;
            }
        }

        private static Operation Calculate(Operation operation)
        {
            var myenum = (CalcEnum)Enum.Parse(typeof(CalcEnum), operation.ID);
            switch (myenum)
            {
                case CalcEnum.Plus:
                    var addRes = new CalcRepository().AdditionOperation(operation.Value);
                    operation.Result = addRes;
                    break;
                case CalcEnum.Subtraction:
                    var subRes = new CalcRepository().SubractionOperation(operation.Value);
                    operation.Result = subRes;
                    break;
                case CalcEnum.Multiplication:
                    var mulRes = new CalcRepository().MultiplicationOperation(operation.Value);
                    operation.Result = mulRes;
                    break;
                case CalcEnum.Division:
                    var divRes = new CalcRepository().DivisionOperation(operation.Value);
                    operation.Result = divRes;
                    break;
            }
            return operation;
        }

        private static void ReadPropertiesRecursive(Operation operation)
        {
            foreach (PropertyInfo property in operation.GetType().GetProperties())
            {
                if (property.PropertyType.IsClass)
                {
                    Operation operation_Sub = property.GetValue(operation, null) as Operation;
                    if (operation_Sub != null)
                    {
                        ReadPropertiesRecursive(operation_Sub);
                    }
                    else
                    {
                        Calculate(operation);
                        break;
                    }
                }
            }
        }
    }
}
