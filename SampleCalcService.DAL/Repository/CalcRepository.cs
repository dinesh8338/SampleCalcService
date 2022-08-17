using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleCalcService.DAL.Interface;
using SampleCalcService.Entities;

namespace SampleCalcService.DAL.Repository
{
    public class CalcRepository : ICalcRepository
    {
        public string AdditionOperation(List<int> values)
        {
            if (values != null && values.Count > 1)
                return values.Aggregate((x, y) => x + y).ToString();
            return "0";
        }

        public string SubractionOperation(List<int> values)
        {
            if (values != null && values.Count > 1)
                return values.Aggregate((x, y) => x - y).ToString();
            return "0";
        }

        public string MultiplicationOperation(List<int> values)
        {
            if (values != null && values.Count > 1)
                return values.Aggregate((x, y) => x * y).ToString();
            return "0";
        }

        public string DivisionOperation(List<int> values)
        {
            if (values != null && values.Count > 1)
                return values.Aggregate((x, y) => x / y).ToString();
            return "0";
        }
    }
}
