using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeCreator
{
    public class MaterialUnit
    {
        public MaterialUnit(UnitType unitType, float unitAmount)
        {
            updateMaterialAmount(unitType, unitAmount);
        }

        public float GetUnitAmount(UnitType unitType)
        {
            if(unitType == UnitType.Drops)
                return _amountDrops;
            return _amountMilligram;
        }

        public float GetDropAmount()
        { return _amountDrops; }

        public float GetMilligramAmount()
        { return _amountMilligram; }

        public void updateMaterialAmount(UnitType unitType, float unitAmount)
        {
            if (unitType == UnitType.Drops)
            {
                _amountDrops = unitAmount;
                _amountMilligram = DropsToMilligram(unitAmount);
            }
            else
            {
                _amountDrops = MilligramToDrops(unitAmount);
                _amountMilligram = unitAmount;
            }
        }
        public float DropsToMilligram(float drops)
        {
            return Globals.DropWeight * drops;
        }

        public float MilligramToDrops(float milligrams)
        {
            return milligrams / Globals.DropWeight;
        }

        public static float MilligramToMilliliter(float mgAmount, DilutionType materialType)
        {
            float mlAmount;
            if (materialType == DilutionType.Oil)
                mlAmount = mgAmount / _DENSITY_OIL;
            else if (materialType == DilutionType.Alcohol)
                mlAmount = mgAmount / _DENSITY_ALCOHOL;
            else
                mlAmount = mgAmount / ((_DENSITY_OIL + _DENSITY_ALCOHOL) / 2.0f); // average between Oil and Alcohol
            return mlAmount;
        }

        public static float MilliliterToMilligram(float mlAmount, DilutionType materialType)
        {
            float mgramAmount;
            if (materialType == DilutionType.Oil)
                mgramAmount = mlAmount * _DENSITY_OIL * 1000.0f;
            else if (materialType == DilutionType.Alcohol)
                mgramAmount = mlAmount * _DENSITY_ALCOHOL * 1000.0f;
            else
                mgramAmount = mlAmount * ((_DENSITY_OIL + _DENSITY_ALCOHOL) / 2.0f) * 1000.0f; // average between Oil and Alcohol
            return mgramAmount;
        }

        public float MixtureToMilliliter(DilutionType materialType)
        {
            float mlAmount;
            if (materialType == DilutionType.Oil)
                mlAmount = _amountMilligram / (_DENSITY_OIL * 1000.0f); // ml based on oil density (gram per ml) and internal amount in MILLIgram
            else if (materialType == DilutionType.Alcohol)
                mlAmount = _amountMilligram / (_DENSITY_ALCOHOL * 1000.0f);
            else
                mlAmount = _amountMilligram / ((_DENSITY_OIL + _DENSITY_ALCOHOL) / 0.002f); // average between Oil and Alcohol
            return mlAmount;
        }

        private float _amountDrops;
        private float _amountMilligram;
        private const float _DENSITY_OIL = 0.87f; // g/ml
        private const float _DENSITY_ALCOHOL = 0.79f; // g/ml
    }
}
