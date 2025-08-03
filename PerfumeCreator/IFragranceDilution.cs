using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeCreator
{
    public interface IFragranceDilution
    {
        public static abstract (float concentration, float amount, DilutionType resultType) CalcDilution(Fragrance baseMaterial, MaterialUnit baseAmount, Diluent addedComponent, MaterialUnit componentAmount);
    }

    public interface IFragranceMixture
    {
        public static abstract (float concentration, float amount, DilutionType resultType) CalcMixture((Fragrance baseMaterial, MaterialUnit baseAmount, Fragrance addedFragrance, MaterialUnit fragranceAmount);
    }
}
