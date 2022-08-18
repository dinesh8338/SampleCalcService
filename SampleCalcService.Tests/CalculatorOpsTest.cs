using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleCalcService.Business;
using SampleCalcService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Xunit;

namespace SampleCalcService.Tests
{
    [TestClass()]
    public class CalculatorOpsTest
    {
        [TestMethod]
        [Fact]
        public void CalcProcess_isvalidinput_shouldreturnresult()
        {
            //Arrange 

            var xmlstring = "<Maths><Operation ID='Plus'><Value>2</Value><Value>3</Value></Operation><Operation ID='Multiplication'><Value>4</Value><Value>5</Value></Operation></Maths>";
            Maths maths = new Maths();
            maths.Operation = new List<Operation>();
            Operation operation = new Operation();
            operation.ID = "Plus";
            operation.Value = new List<int>();
            operation.Value.Add(2);
            operation.Value.Add(3);
            operation.Result = "5";
            maths.Operation.Add(operation);
            Operation operation1 = new Operation();
            operation1.ID = "Multiplication";
            operation1.Value = new List<int>();
            operation1.Value.Add(4);
            operation1.Value.Add(5);
            operation1.Result = "20";
            maths.Operation.Add(operation1);
            var expectedResult = CalculatorOps.ToXElement<Maths>(maths);
            var xElement = XElement.Parse(xmlstring);
            //XmlRootAttribute xRoot = new XmlRootAttribute();
            //xRoot.ElementName = "Maths";
            //xRoot.IsNullable = true;
            //ACT
            CalculatorOps calculatorOps = new CalculatorOps();
            var result = calculatorOps.CalcProcess(xElement);
            //Assert
            Assert.IsTrue(maths != null);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("<Result>5</Result>"));
            Assert.IsTrue(result.Contains("<Result>20</Result>"));
            Assert.AreEqual(expectedResult.ToString(), result);
        }

        [TestMethod]
        [Fact]
        public void CalcProcess_isInvalidinput_shouldreturnresult()
        {
            //Arrange 
            Maths maths = new Maths();
            maths.Operation = new List<Operation>();
            Operation operation = new Operation();
            operation.ID = "Plus";
            operation.Value = new List<int>();
            operation.Value.Add(2);
            operation.Value.Add(3);
            operation.Result = "5";
            maths.Operation.Add(operation);
            Operation operation1 = new Operation();
            operation1.ID = "Multiplication";
            operation1.Value = new List<int>();
            operation1.Value.Add(4);
            operation1.Value.Add(5);
            operation1.Result = "20";
            maths.Operation.Add(operation1);
            var expectedResult = CalculatorOps.ToXElement<Maths>(maths);
            XElement xElement = null;
            //ACT
            CalculatorOps calculatorOps = new CalculatorOps();
            var result = calculatorOps.CalcProcess(xElement);
            //Assert
            Assert.IsTrue(result == null);
        }
    }
}
