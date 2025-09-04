using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeCreator
{
    public class Accord : Basis, IOnlyAccordCompatible, IAccordPerfumeCompatible, ICollectionReturn
    {
        // interface definition
        public float Concentration => _concentration;
        public DilutionType DilutionType => _dilutionType;
        public MaterialUnit FullAmount => _fullAmount;
        public float TotalPrice => _totalPrice;
        // ---

        public NoteLevel _noteLevel { get; set; }
        public ScentCategory _scentCategory { get; set; }
        private List<(IOnlyAccordCompatible Frag, MaterialUnit Amount)> _ingredientsList = new List<(IOnlyAccordCompatible, MaterialUnit)>();
        
        /// <summary>
        /// Constructor to create an Accord based on an existing IOnlyAccordCompatible object (Molecule/Accord/Diluent)
        /// </summary>
        /// <param name="name"></param> defines the name of the created Accord
        /// <param name="baseComponent"></param> sets the base/initial component
        /// <param name="baseMaterialAmount"></param> defines the amount of the baseComponent putted into the Accord
        /// <param name="scentCategory"></param> defines the scent category of the Accord
        /// <param name="noteLevel"></param> defines the note type (Head/Heart/Base) of the Accord
        /// <exception cref="ArgumentException"></exception>
        public Accord(
            string name,
            IOnlyAccordCompatible baseComponent,
            MaterialUnit baseMaterialAmount,
            ScentCategory scentCategory = ScentCategory.UNKNOWN,
            NoteLevel noteLevel = NoteLevel.UNKNOWN,
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
            //_emptyObject = false;
            _noteLevel = noteLevel;
            _scentCategory = scentCategory;
            AddComponentToAccord(baseComponent, baseMaterialAmount);
        }

        /// <summary>
        /// Wrapper class for the Basis-internal Mixing-logic
        /// </summary>
        /// <param name="newComponent"></param>
        /// <param name="newComponentAmount"></param>
        public void AddComponentToAccord(IOnlyAccordCompatible newComponent, MaterialUnit newComponentAmount)
        {
            if (_ingredientsList.Count == 0) // first element
            {
                // Accord member variables could be ignored due to handling them automatically when calling the constructor
                // only adding the first component to the list
                _ingredientsList.Add((newComponent, newComponentAmount));
                return;
            }
            // convert current Accord properties to transferring structure
            Mixture currentMix = new Mixture(_name, _fullAmount, _concentration, _totalPrice, _dilutionType);
            (Mixture resMix, MaterialUnit resAmount) = Mixing.MixGeneralFragrance(currentMix, _fullAmount, (Basis)newComponent, newComponentAmount);
            // update resulting values
            _fullAmount = resAmount;
            _concentration = resMix._concentration;
            _totalPrice = resMix._totalPrice;
            _dilutionType = resMix._dilutionType;
        }

        public void RemoveComponentFromAccord(int index) //?
        {
            //tbd...
        }

        public List<(IOnlyAccordCompatible Frag, MaterialUnit Amount)> GetIngredientsList()
        {
            return _ingredientsList;
        }
    }
}
