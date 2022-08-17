using SampleCalcService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCalcService.DAL.Interface
{
    interface ICalcRepository
    {
        string AdditionOperation(string ops, List<int> values);
        string MultiplicationOperation(Maths math);
        string SubractionOperation(Maths math);
        string DivisionOperation(Maths math);
    }
}
