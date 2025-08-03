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
        public Molecule() { }
        public Molecule(string name)
        {
            _name = name;
        }
        public void diluteMolecule(Diluent component)
        {
            CalcDilution(component);
        }
    }
}
