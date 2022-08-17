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
            int sum = 0;
            foreach (int i in values)
            {
                sum += i;
            }
            return sum.ToString();
        }

        public string SubractionOperation(List<int> values)
        {
            int res = 0;
            foreach (int i in values)
            {
                res -= i;
            }
            return res.ToString();
        }

        public string MultiplicationOperation(List<int> values)
        {
            int res = 1;
            foreach (int i in values)
            {
                res *= i;
            }
            return res.ToString();
        }

        public string DivisionOperation(List<int> values)
        {
            int res = 1;
            foreach (int i in values)
            {
                res /= i;
            }
            return res.ToString();
        }
    }
}
