using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeCreator
{
    /*
    public class DummyAccord
    {
        public string _name {  get; set; }
        public ScentCategory _scentCategory { get; set; }
        public NoteLevel _noteLevel { get; set; }
        public string _comment { get; set; }
    }*/

    public class Accord : Fragrance, IFragranceMixture, IAccordCompatible, IPerfumeCompatible
    {
        public float FragranceConcentration => _fragranceConcentration;
        public DilutionType DilutionType => _dilutionType;
        public MaterialUnit FullAmount => _fullAmount;
        public float TotalPrice => _totalPrice;

        private List<(IAccordCompatible Frag, MaterialUnit Amount)> _ingredientsList = new List<(IAccordCompatible, MaterialUnit)>();
        
        public Accord(string name, IAccordCompatible baseMolecule, MaterialUnit materialUnit)
            : base(name, baseMolecule.FragranceConcentration, baseMolecule.DilutionType, baseMolecule.FullAmount, baseMolecule.TotalPrice)
        {
            /*
             *  -> shift adding/mixing new component into seperate function
             */
            _ingredientsList.Add((Frag: baseMolecule, Amount: materialUnit));
            if(_ingredientsList.Count > 1)
            {
                if (baseMolecule is Diluent)
                {
                    diluteFragrance((Diluent)baseMolecule, materialUnit);
                    updatePrice((Diluent)baseMolecule, materialUnit);
                }
                else if (baseMolecule is Molecule)
                {
                    mixFragrance((Molecule)baseMolecule, materialUnit);
                    updatePrice((Molecule)baseMolecule, materialUnit);
                }
                else if (baseMolecule is Accord)
                {
                    mixFragrance((Accord)baseMolecule, materialUnit);
                    updatePrice((Accord)baseMolecule, materialUnit);
                }
                else
                    throw new ArgumentException(nameof(baseMolecule), "Given IAccordCompatible type is rather Diluent, Molecule nor Accord");
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
        public List<(IAccordCompatible Frag, MaterialUnit Amount)> getIngredients()
        {
            return _ingredientsList;
        }
    }
}
