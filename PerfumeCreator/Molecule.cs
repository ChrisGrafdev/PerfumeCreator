using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeCreator
{
    public class Molecule : Fragrance, IOnlyAccordCompatible
    {
        public float FragranceConcentration => _fragranceConcentration;
        public DilutionType DilutionType => _dilutionType;
        public MaterialUnit FullAmount => _fullAmount;
        public float TotalPrice => _totalPrice;

        public string _manufacturer { get; set; }

        public ScentCategory _scentCategory { get; set; }

        public Molecule(string name, float concentration, DilutionType dilutionType, MaterialUnit materialAmount, ScentCategory scentCategory = ScentCategory.UNKNOWN, float fullPrice = 0, NoteLevel noteLevel = NoteLevel.UNKNOWN, string manufacturer = "unkown")
            : base(name, concentration, dilutionType, materialAmount, fullPrice, noteLevel)
        {
            _manufacturer = manufacturer;
            _scentCategory = scentCategory;
        }
    }
}
