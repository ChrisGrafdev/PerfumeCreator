using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeCreator
{
    public interface IFragranceDilution
    {
        public void diluteFragrance(Diluent addedComponent, MaterialUnit componentAmount, MaterialUnit? specificBaseAmount = null);
        public void updatePrice(Diluent addedComponent, MaterialUnit componentAmount, MaterialUnit? specificBaseAmount = null);
        public void updatePrice(Fragrance addedFragrance, MaterialUnit fragranceAmount, MaterialUnit? specificBaseAmount = null);
    }

    public interface IFragranceMixture
    {
        public void mixFragrance(Fragrance addedFragrance, MaterialUnit fragranceAmount, MaterialUnit? specificBaseAmount = null);
    }

    public interface IAccordCompatible
    {
        float FragranceConcentration {  get; }
        DilutionType DilutionType { get; }
        MaterialUnit FullAmount { get; }
        float TotalPrice { get; }
    }
    public interface IPerfumeCompatible
    {
        float FragranceConcentration { get; }
        DilutionType DilutionType { get; }
        MaterialUnit FullAmount { get; }
        float TotalPrice { get; }
    }
}
