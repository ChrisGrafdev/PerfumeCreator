using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeCreator
{
    public interface IAccordPerfumeCompatible
    {
        float Concentration { get; }
        DilutionType DilutionType { get; }
        MaterialUnit FullAmount { get; }
        float TotalPrice { get; }
    }
}
