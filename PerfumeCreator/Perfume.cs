using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeCreator
{
    public class Perfume : Basis, ICollectionReturn
    {
        /*
        public float FragranceConcentration => _concentration;
        public DilutionType DilutionType => _dilutionType;
        public MaterialUnit FullAmount => _fullAmount;
        public float TotalPrice => _totalPrice;
        */
        
        private List<(IAccordPerfumeCompatible Accord, MaterialUnit Amount)> _ingredientsList = new List<(IAccordPerfumeCompatible, MaterialUnit)>();

        public Perfume(
            string name,
            IAccordPerfumeCompatible baseComponent,
            MaterialUnit baseMaterialAmount,
            string? description = null,
            string? comment = null)
            : base(
                  name,
                  baseComponent.FullAmount,
                  baseComponent.Concentration,
                  baseComponent.TotalPrice,
                  baseComponent.DilutionType,
                  description,
                  comment)
        {
            AddComponentToPerfume(baseComponent, baseMaterialAmount);
        }

        /// <summary>
        /// Wrapper class for the Basis-internal Mixing-logic
        /// </summary>
        /// <param name="newComponent"></param>
        /// <param name="newComponentAmount"></param>
        public void AddComponentToPerfume(IAccordPerfumeCompatible newComponent, MaterialUnit newComponentAmount)
        {
            _ingredientsList.Add((newComponent, newComponentAmount));
            if (_ingredientsList.Count == 1) // first element
            {
                // Perfume member variables could be ignored due to handling them automatically when calling the constructor
                // only adding the first component to the list
                return;
            }
            // convert current Perfume properties to transferring structure
            Mixture currentMix = new Mixture(_name, _fullAmount, _concentration, _totalPrice, _dilutionType);
            (Mixture resMix, MaterialUnit resAmount) = Mixing.MixGeneralFragrance(currentMix, _fullAmount, (Basis)newComponent, newComponentAmount);
            // update resulting values
            _fullAmount = resAmount;
            _concentration = resMix._concentration;
            _totalPrice = resMix._totalPrice;
            _dilutionType = resMix._dilutionType;
        }

        public void RemoveComponentFromPerfume(int index) //?
        {
            //tbd...
        }

        public List<(IAccordPerfumeCompatible Accord, MaterialUnit Amount)> GetIngredientsList()
        {
            return _ingredientsList;
        }
    }
}
