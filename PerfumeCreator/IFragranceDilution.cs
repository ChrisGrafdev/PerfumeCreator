using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeCreator
{
    public interface IFragranceDilution
    {
        public float CalcDilution(Diluent component);
    }
}
