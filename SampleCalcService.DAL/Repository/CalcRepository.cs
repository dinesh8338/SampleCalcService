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
        public string AdditionOperation(string ops, List<int> values)
        {
            int sum = 0;
         foreach(int i in values)
            {
                sum += i;
            }   
        }

        public string DivisionOperation(Maths math)
        {
            throw new NotImplementedException();
        }

        public string MultiplicationOperation(Maths math)
        {
            throw new NotImplementedException();
        }

        public string SubractionOperation(Maths math)
        {
            throw new NotImplementedException();
        }
    }
}
