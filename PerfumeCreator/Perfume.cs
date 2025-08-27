using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeCreator
{
    public class Perfume : Fragrance
    {
        public float FragranceConcentration => _fragranceConcentration;
        public DilutionType DilutionType => _dilutionType;
        public MaterialUnit FullAmount => _fullAmount;
        public float TotalPrice => _totalPrice;

        private List<(IAccordPerfumeCompatible Accord, MaterialUnit Amount)> _ingredientsList = new List<(IAccordPerfumeCompatible, MaterialUnit)>();

        public Perfume(string name, IAccordPerfumeCompatible baseAccord, MaterialUnit materialUnit)
            : base(name, baseAccord.FragranceConcentration, baseAccord.DilutionType, baseAccord.FullAmount, baseAccord.TotalPrice)
        {
            _ingredientsList.Add((Accord: baseAccord, Amount: materialUnit));
            if (_ingredientsList.Count > 1)
            {
                if (baseAccord is Diluent)
                {
                    diluteFragrance((Diluent)baseAccord, materialUnit);
                    updatePrice((Diluent)baseAccord, materialUnit);
                }
                else if (baseAccord is Accord)
                {
                    mixFragrance((Accord)baseAccord, materialUnit);
                    updatePrice((Accord)baseAccord, materialUnit);
                }
                else
                    throw new ArgumentException(nameof(baseAccord), "Given IPerfumeCompatible type is rather Diluent nor Accord");
            }
        }

        public void mixFragrance(Fragrance addedFragrance, MaterialUnit fragranceAmount, MaterialUnit? specificBaseAmount = null)
        {
            if (_dilutionType != addedFragrance._dilutionType)
            {
                _dilutionType = DilutionType.Mix;
            }

            float rawFragranceAmount;
            if (specificBaseAmount != null)
            {
                rawFragranceAmount = _fragranceConcentration * specificBaseAmount.GetMilligramAmount();
                float newMaterialAmount = specificBaseAmount.GetMilligramAmount() + fragranceAmount.GetMilligramAmount();
                if (_fullAmount != null)
                    _fullAmount.updateMaterialAmount(UnitType.Milligram, newMaterialAmount);
                else
                    _fullAmount = new MaterialUnit(UnitType.Milligram, newMaterialAmount);
            }
            else
            {
                if (_fullAmount == null) // maybe handle it in a better way?
                    throw new ArgumentNullException(nameof(_fullAmount), "Fragrance-base amount is not defined");

                rawFragranceAmount = _fragranceConcentration * _fullAmount.GetMilligramAmount();
                _fullAmount.updateMaterialAmount(UnitType.Milligram, _fullAmount.GetMilligramAmount() + fragranceAmount.GetMilligramAmount());
            }

            _fragranceConcentration = rawFragranceAmount / _fullAmount.GetMilligramAmount();
        }

        public (float fillUpMilligramAmount, float perfumeRawMatFactor) calcFillUpMilligramAmount(float finalMilliliter, float finalPerfumeConcentrationPercent, DilutionType finalDilutionMaterial)
        {
            float perfumeRawMatML = _fullAmount.MixtureToMilliliter(_dilutionType); // ml amount of raw perfume material-mixture
            float mlAmountFromCurrentFragranceAmount = perfumeRawMatML / finalPerfumeConcentrationPercent * 100.0f; // resulting diluted perfume amount based on current raw material amount and the final perfume percentage
            float scaleFactor = finalMilliliter / mlAmountFromCurrentFragranceAmount; // calculation of the scaling factor to reach the desired perfume amount
            float requiredDilutionML = finalMilliliter - perfumeRawMatML * scaleFactor; // get dilution ML amount based on rescaled raw materials
            float requiredDilutionMG = MaterialUnit.MilliliterToMilligram(requiredDilutionML, finalDilutionMaterial);
            return (requiredDilutionMG, scaleFactor);
        }

        public List<(IAccordPerfumeCompatible Accord, MaterialUnit Amount)> GetIngredientsList()
        {
            return _ingredientsList;
        }
    }
}
