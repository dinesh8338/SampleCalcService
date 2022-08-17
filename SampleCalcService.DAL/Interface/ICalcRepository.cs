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
        string AdditionOperation(List<int> values);
        string MultiplicationOperation(List<int> values);
        string SubractionOperation(List<int> values);
        string DivisionOperation(List<int> values);
    }
}
