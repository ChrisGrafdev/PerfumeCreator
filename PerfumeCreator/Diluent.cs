using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeCreator
{
    public abstract class Diluent : Basis, IOnlyAccordCompatible, IAccordPerfumeCompatible
    {
        // interface definition
        public float Concentration => 0.0f;
        public DilutionType DilutionType => _dilutionType;
        public MaterialUnit FullAmount => _fullAmount;
        public float TotalPrice => _totalPrice;
        // ---

        public Diluent(
            string name,
            MaterialUnit dilutionAmount,
            float fullPrice,
            DilutionType dilutionType)
            : base(
                  name,
                  dilutionAmount,
                  0.0f,
                  fullPrice,
                  dilutionType)
        { }
    }
}
