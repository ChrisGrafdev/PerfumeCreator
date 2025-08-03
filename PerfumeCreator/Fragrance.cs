using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeCreator
{

    public abstract class Fragrance : Diluent, IFragranceDilution
    {
        public List<string> _scents { get; set; }
        public string _description { get; set; }
        public float _dilution { get; set; }
        public string _comment { get; set; }  

        public float CalcDilution(Diluent component)
        {
            float newDilution = _dilution * _materialAmount.GetMilligramAmount() + component._dilution * component._materialAmount.GetMilligramAmount();
            float fullAmount = _materialAmount.GetMilligramAmount() + component._materialAmount.GetMilligramAmount();

            _dilution = newDilution / fullAmount;
            _materialAmount.updateMaterialAmount(UnitType.Milligram, fullAmount);
            return _dilution;
        }
    }
}
