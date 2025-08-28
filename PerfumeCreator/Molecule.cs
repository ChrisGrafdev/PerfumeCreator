using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeCreator
{
    public class Molecule : Basis, IOnlyAccordCompatible
    {
        // interface definition
        public float Concentration => _concentration;
        public DilutionType DilutionType => _dilutionType;
        public MaterialUnit FullAmount => _fullAmount;
        public float TotalPrice => _totalPrice;
        //---

        public ScentCategory _scentCategory { get; set; }
        public NoteLevel _noteLevel { get; set; }
        public string _manufacturer { get; set; }

        /*public Molecule(string name) : base(name)
        {
            _emptyObject = true;
        }*/

        public Molecule(
            string name,
            MaterialUnit materialAmount,
            float concentration,
            float fullPrice,
            DilutionType dilutionType,
            ScentCategory scentCategory = ScentCategory.UNKNOWN,
            NoteLevel noteLevel = NoteLevel.UNKNOWN,
            string manufacturer = "unkown",
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
            _manufacturer = manufacturer;
        }
    }
}
