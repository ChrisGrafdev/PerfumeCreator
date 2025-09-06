using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeCreator
{
    public interface IOnlyAccordCompatible
    {
        MaterialUnit FullAmount { get; }
        float Concentration { get; }
        float TotalPrice { get; }
        DilutionType DilutionType { get; }
    }
}
