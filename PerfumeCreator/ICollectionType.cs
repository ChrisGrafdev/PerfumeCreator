using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeCreator
{
    public interface ICollectionType
    {
        MaterialUnit FullAmount { get; set; }
        MaterialUnit UsedAmount { get; set; }
        float Concentration { get; set; }
        float TotalPrice { get; set; }
        float PricePerMG { get; set; }
        DilutionType DilutionType { get; set; }
        void AddComponent(IOnlyAccordCompatible newComponent);
        void RemoveComponent(int index);
    }
}
