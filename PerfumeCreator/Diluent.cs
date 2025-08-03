using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeCreator
{
    public static class Globals
    {
        public static float DropWeight = 15.0f;
        public static void SetDropWeight(float dropWeight)
        {
            Globals.DropWeight = dropWeight;
        }
    }

    public enum UnitType
    {
        Drops,
        Milligram
    }

    public class MaterialUnit
    {
        private float _amountDrops;
        private float _amountMilligram;

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

        public MaterialUnit()
        {
            _amountDrops = 0;
            _amountMilligram = 0;
        }

        public MaterialUnit(UnitType unitType, float unitAmount)
        {
            updateMaterialAmount(unitType, unitAmount);
        }

        public float DropsToMilligram(float drops)
        {
            return Globals.DropWeight * drops;
        }

        public float MilligramToDrops(float milligrams)
        {
            return milligrams / Globals.DropWeight;
        }
    }

    public abstract class Diluent
    {
        public string _name { get; set; }
        public float _preis { get; set; }
        public MaterialUnit _materialAmount { get; set; }
    }
}
