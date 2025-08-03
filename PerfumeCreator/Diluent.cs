using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeCreator
{
    public abstract class Diluent
    {
        
        public Diluent(string name, DilutionType type, float pricePerGram = 0)
        {
            _name = name;
            _price = pricePerGram;
            _diluentType = type;
        }
        public string _name { get; set; }
        public float _price { get; set; }
        public DilutionType _diluentType { get; set; }
    }
}
