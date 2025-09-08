using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeCreator
{
    public interface IDataStorage
    {
        public bool StoreComponent(Molecule molecule);
        public bool StoreComponent(Diluent diluent);
        public bool StoreCollection(Accord accord);
        public bool StoreCollection(Perfume perfume);
    }
}
