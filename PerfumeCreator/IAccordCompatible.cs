using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeCreator
{
    public interface IAccordCompatible
    {
        string Name { get; }
        MaterialUnit FullAmount { get; }
        MaterialUnit UsedAmount { get; }
        float Concentration { get; }
        float TotalPrice { get; }
        float PricePerMG { get; }
        DilutionType DilutionType { get; }
    }
}
