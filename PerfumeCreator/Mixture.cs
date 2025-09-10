using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeCreator
{
    public class Mixture : Basis, IAccordCompatible, IAccordPerfumeCompatible, ICollectionType
    {
        // interface definition
        public string Name => _name;
        public float Concentration
        {
            get => _concentration;
            set => _concentration = value;
        }
        public DilutionType DilutionType
        {
            get => _dilutionType;
            set => _dilutionType = value;
        }
        public MaterialUnit FullAmount
        {
            get => _fullAmount;
            set => _fullAmount = value;
        }
        public MaterialUnit UsedAmount
        {
            get => _usedAmount;
            set => _usedAmount = value;
        }
        public float TotalPrice
        {
            get => _totalPrice;
            set => _totalPrice = value;
        }
        public float PricePerMG
        {
            get => _pricePerMilligram;
            set => _pricePerMilligram = value;
        }

        public void AddComponent(IAccordCompatible newComponent)
        {
            _ingredientsList.Add(newComponent);
        }

        public void RemoveComponent(int index)
        {
            _ingredientsList.RemoveAt(index);
        }

        public IAccordCompatible? CheckIngredientExistence(IAccordCompatible compareComponent)
        {
            return _ingredientsList.FirstOrDefault(x => x.Name == compareComponent.Name);
        }

        public List<IAccordCompatible> GetIngredientsList()
        {
            return _ingredientsList;
        }
        //---

        private List<IAccordCompatible> _ingredientsList = new List<IAccordCompatible>();
        public NoteLevel _noteLevel { get; set; }
        public ScentCategory _scentCategory { get; set; }

        /// <summary>
        /// Constructor to create an Accord-like data container based on the given data.
        /// It acts like an universal object, for storing/transferring information
        /// between different objects without using an Accord object.
        /// Reason for that is the missing information what type of data is added to
        /// the Mixture. In contrast: an Accord itself is basically just a container for
        /// a collection of other components like Molecules, Diluents and other Accords
        /// (theoretically also Perfumes).
        /// By using Mixture all informations can be stored, without knowing which
        /// components it is later used for (it could be an Molecule, Accord, etc.).
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fullAmount"></param>
        /// <param name="usedAmount"></param>
        /// <param name="concentration"></param>
        /// <param name="fullPrice"></param>
        /// <param name="dilutionType"></param>
        /// <param name="scentCategory"></param>
        /// <param name="noteLevel"></param>
        /// <param name="description"></param>
        /// <param name="comment"></param>
        public Mixture(
            string name,
            MaterialUnit fullAmount,
            MaterialUnit usedAmount,
            float concentration,
            float fullPrice,
            DilutionType dilutionType,
            ScentCategory scentCategory = ScentCategory.UNKNOWN,
            NoteLevel noteLevel = NoteLevel.UNKNOWN,
            string? description = null,
            string? comment = null)
            : base(
                  name,
                  fullAmount,
                  concentration,
                  fullPrice,
                  dilutionType,
                  description,
                  comment)
        {
            _usedAmount = usedAmount;
            _noteLevel = noteLevel;
            _scentCategory = scentCategory;
        }
    }
}
