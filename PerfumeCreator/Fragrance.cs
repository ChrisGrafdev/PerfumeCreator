using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeCreator
{

    public abstract class Fragrance : IFragranceDilution
    {
        public string _name { get; set; }
        public float _fragranceConcentration { get; set; }
        public float _pricePerMilligram { get; set; }
        public float _totalPrice{ get; set; }
        public DilutionType _dilutionType { get; set; }
        public string _description { get; set; }
        public NoteLevel _noteLevel { get; set; }
        public string _comment { get; set; }
        public List<string> _scents { get; set; }

        public MaterialUnit _fullAmount;


        public Fragrance(string name, float concentration, DilutionType dilutionType, MaterialUnit materialAmount, float fullPrice = 0, NoteLevel noteLevel = NoteLevel.UNKNOWN)
        {
            _name = name;
            _fragranceConcentration = concentration;
            _dilutionType = dilutionType;
            _pricePerMilligram = fullPrice / materialAmount.GetMilligramAmount();
            _totalPrice = fullPrice;
            _fullAmount = materialAmount;
            _noteLevel = noteLevel; 
        }
        public void diluteFragrance(Diluent addedComponent, MaterialUnit componentAmount, MaterialUnit? specificBaseAmount = null)
        {
            /* Calculate Fragrance dilutions */
            if (_dilutionType != addedComponent._diluentType)
            {
                _dilutionType = DilutionType.Mix;
            }

            float rawFragranceAmount;
            if (specificBaseAmount != null)
            {
                rawFragranceAmount = _fragranceConcentration * specificBaseAmount.GetMilligramAmount();
                float newMaterialAmount = specificBaseAmount.GetMilligramAmount() + componentAmount.GetMilligramAmount();
                if (_fullAmount != null)
                    _fullAmount.updateMaterialAmount(UnitType.Milligram, newMaterialAmount);
                else
                    _fullAmount = new MaterialUnit(UnitType.Milligram, newMaterialAmount);
            }
            else
            {
                if (_fullAmount == null) // case should not exist
                    throw new ArgumentNullException(nameof(_fullAmount), "Fragrance-base amount is not defined");
                
                rawFragranceAmount = _fragranceConcentration * _fullAmount.GetMilligramAmount();
                _fullAmount.updateMaterialAmount(UnitType.Milligram, _fullAmount.GetMilligramAmount() + componentAmount.GetMilligramAmount());
            }

            _fragranceConcentration = rawFragranceAmount / _fullAmount.GetMilligramAmount();
        }

        public void updatePrice(Diluent addedComponent, MaterialUnit componentAmount, MaterialUnit? specificBaseAmount = null)
        {
            if (_pricePerMilligram == 0 || (specificBaseAmount == null && _fullAmount == null))
                return;

            if (specificBaseAmount != null)
            {
                float combinedPrice = specificBaseAmount.GetMilligramAmount() * _pricePerMilligram + componentAmount.GetMilligramAmount() * addedComponent._pricePerMilligram;
                float combinedGram = specificBaseAmount.GetMilligramAmount() + componentAmount.GetMilligramAmount();
                _pricePerMilligram = combinedPrice / combinedGram;
            }
            else if (_fullAmount != null)
            {
                float combinedPrice = _fullAmount.GetMilligramAmount() * _pricePerMilligram + componentAmount.GetMilligramAmount() * addedComponent._pricePerMilligram;
                float combinedGram = _fullAmount.GetMilligramAmount() + componentAmount.GetMilligramAmount();
                _pricePerMilligram = combinedPrice / combinedGram;
            }
            else
                throw new ArgumentNullException(nameof(specificBaseAmount) + " and " + nameof(_fullAmount), "Fragrance-base amount is undefined and no specific amount is given");
        }

        public void updatePrice(Fragrance addedFragrance, MaterialUnit fragranceAmount, MaterialUnit? specificBaseAmount = null)
        {
            if (_pricePerMilligram == 0 || (specificBaseAmount == null && _fullAmount == null))
                return;

            if (specificBaseAmount != null)
            {
                float combinedPrice = specificBaseAmount.GetMilligramAmount() * _pricePerMilligram + fragranceAmount.GetMilligramAmount() * addedFragrance._pricePerMilligram;
                float combinedGram = specificBaseAmount.GetMilligramAmount() + fragranceAmount.GetMilligramAmount();
                _pricePerMilligram = combinedPrice / combinedGram;
            }
            else if (_fullAmount != null)
            {
                float combinedPrice = _fullAmount.GetMilligramAmount() * _pricePerMilligram + fragranceAmount.GetMilligramAmount() * addedFragrance._pricePerMilligram;
                float combinedGram = _fullAmount.GetMilligramAmount() + fragranceAmount.GetMilligramAmount();
                _pricePerMilligram = combinedPrice / combinedGram;
            }
            else
                throw new ArgumentNullException(nameof(specificBaseAmount) + " and " + nameof(_fullAmount), "Fragrance-base amount is undefined and no specific amount is given");
        }
    }
}
