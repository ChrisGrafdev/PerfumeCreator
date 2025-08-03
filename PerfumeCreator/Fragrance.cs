using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeCreator
{

    public abstract class Fragrance : IFragranceDilution, IFragranceMixture
    {
        public string _name { get; set; }
        public float _fragranceConcentration { get; set; }
        public float _price { get; set; }
        public DilutionType _dilutionType { get; set; }
        public string _description { get; set; }
        public string _comment { get; set; }
        public List<string> _scents { get; set; }

        private float _fullAmount;

        public Fragrance(string name, float concentration, DilutionType dilutionType, float pricePerGram = 0)
        {
            _name = name;
            _fragranceConcentration = concentration;
            _dilutionType = dilutionType;
            _price = pricePerGram;
            _fullAmount = 0;
        }
        public void diluteFragrance(MaterialUnit baseAmount, Diluent addedComponent, MaterialUnit componentAmount)
        {
            (_fragranceConcentration, _fullAmount, _dilutionType) = CalcDilution(this, baseAmount, addedComponent, componentAmount);

        }
        public static (float concentration, float amount, DilutionType resultType) CalcDilution(Fragrance baseMaterial, MaterialUnit baseAmount, Diluent addedComponent, MaterialUnit componentAmount)
        {
            DilutionType resType = baseMaterial._dilutionType;
            if(baseMaterial._dilutionType != addedComponent._diluentType)
            {
                resType = DilutionType.Mix;
            }

            float rawFragranceAmount = baseMaterial._fragranceConcentration * baseAmount.GetMilligramAmount();
            float fullAmount = baseAmount.GetMilligramAmount() + componentAmount.GetMilligramAmount();

            float newConcentration = rawFragranceAmount / fullAmount;
            return (newConcentration, fullAmount, resType);
        }

        public static (float concentration, float amount, DilutionType resultType) CalcMixture(Fragrance baseMaterial, MaterialUnit baseAmount, Fragrance addedFragrance, MaterialUnit fragranceAmount)
        {
            DilutionType resType = baseMaterial._dilutionType;
            if (baseMaterial._dilutionType != addedFragrance._dilutionType)
            {
                resType = DilutionType.Mix;
            }

            float rawFragranceAmount = baseMaterial._fragranceConcentration * baseAmount.GetMilligramAmount() + addedFragrance._fragranceConcentration * fragranceAmount.GetMilligramAmount();
            float fullAmount = baseAmount.GetMilligramAmount() + fragranceAmount.GetMilligramAmount();

            float newConcentration = rawFragranceAmount / fullAmount;
            return (newConcentration, fullAmount, resType);
        }
    }
}
