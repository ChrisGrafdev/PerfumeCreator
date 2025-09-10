using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeCreator
{
    public interface ICollectionType
    {
        string Name { get; }
        MaterialUnit FullAmount { get; set; }
        MaterialUnit UsedAmount { get; set; }
        float Concentration { get; set; }
        float TotalPrice { get; set; }
        float PricePerMG { get; set; }
        DilutionType DilutionType { get; set; }
        void AddComponent(IAccordCompatible newComponent);
        void RemoveComponent(int index);
        IAccordCompatible? CheckIngredientExistence(IAccordCompatible compareComponent);
        List<IAccordCompatible> GetIngredientsList();
    }
}
