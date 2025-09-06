using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeCreator
{
    public class Mixture : Basis, IOnlyAccordCompatible, IAccordPerfumeCompatible
    {
        // interface definition
        public float Concentration => _concentration;
        public DilutionType DilutionType => _dilutionType;
        public MaterialUnit FullAmount => _fullAmount;
        public float TotalPrice => _totalPrice;
        //---

        public NoteLevel _noteLevel { get; set; }
        public ScentCategory _scentCategory { get; set; }

        /// <summary>
        /// Constructor to create an Accord-like data container based on the given data.
        /// It could be used for storing/transferring information between different
        /// objects without using an Accord object.
        /// Reason for that is the missing information what type of data is added to
        /// the Mixture. In contrast: an Accord itself is basically just a container for
        /// a collection of other components like Molecules, Diluents and other Accords
        /// (theoretically also Perfumes).
        /// By using Mixture all informations can be stored, without knowing which
        /// components it is later used for (it could be an Molecule, Accord, etc.).
        /// </summary>
        /// <param name="name"></param>
        /// <param name="materialAmount"></param>
        /// <param name="concentration"></param>
        /// <param name="fullPrice"></param>
        /// <param name="dilutionType"></param>
        /// <param name="scentCategory"></param>
        /// <param name="noteLevel"></param>
        /// <param name="description"></param>
        /// <param name="comment"></param>
        public Mixture(
            string name,
            MaterialUnit materialAmount,
            float concentration,
            float fullPrice,
            DilutionType dilutionType,
            ScentCategory scentCategory = ScentCategory.UNKNOWN,
            NoteLevel noteLevel = NoteLevel.UNKNOWN,
            string? description = null,
            string? comment = null)
            : base(
                  name,
                  materialAmount,
                  concentration,
                  fullPrice,
                  dilutionType,
                  description,
                  comment)
        {
            _noteLevel = noteLevel;
            _scentCategory = scentCategory;
        }
    }
}
