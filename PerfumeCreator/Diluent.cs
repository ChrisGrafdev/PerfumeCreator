using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeCreator
{
    public abstract class Diluent : IAccordCompatible, IPerfumeCompatible
    {
        public float FragranceConcentration => 0.0f;
        public DilutionType DilutionType => _diluentType;
        public MaterialUnit FullAmount => _fullAmount;
        public float TotalPrice => _totalPrice;

        public Diluent(string name, DilutionType type, float fullPrice, MaterialUnit dilutionAmount)
        {
            _name = name;
            _pricePerMilligram = fullPrice / dilutionAmount.GetMilligramAmount();
            _diluentType = type;
            _totalPrice = fullPrice;
            _fullAmount = dilutionAmount;
        }
        public string _name { get; set; }
        public float _pricePerMilligram { get; set; }
        public float _totalPrice { get; set; }
        public MaterialUnit _fullAmount { get; set; }
        public DilutionType _diluentType { get; set; }
    }
}
