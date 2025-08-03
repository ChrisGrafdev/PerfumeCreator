using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeCreator
{
    public class Molecule : Fragrance
    {
        public string _manufacturer { get; set; }

        public Molecule(string name, float concentration, DilutionType dilutionType, float pricePerGram = 0, string manufacturer = "unkown")
            : base(name, concentration, dilutionType, pricePerGram)
        {
            _manufacturer = manufacturer;
        }
    }
}
