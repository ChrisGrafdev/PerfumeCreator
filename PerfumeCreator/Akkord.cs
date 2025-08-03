using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeCreator
{
    internal class MoleculeAmount
    {
        public Molecule _molecule;
        public MaterialUnit _moleculeAmount;
        public MoleculeAmount(Molecule mol, MaterialUnit molUnit)
        {
            _molecule = mol;
            _moleculeAmount = molUnit;
        }
    }

    public class Akkord : Molecule
    {
        private float _fullAmount = 0;

        private List<MoleculeAmount> _moleculeList;
        
        public Akkord()
        {
            _dilution = 0;
        }
        
        public void AddMolecule(Molecule molecule, MaterialUnit moleculeAmount)
        {
            _moleculeList.Add(new MoleculeAmount(molecule, moleculeAmount));
            //CalcDilution(molecule._dilution, moleculeAmount);
        }

        
    }
}
