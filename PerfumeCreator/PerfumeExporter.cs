using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace PerfumeCreator
{
    public static class PerfumeExporter
    {
        public static bool ExportCollection(Perfume perfume)
        {
            if (perfume == null) return false;

            string outputStringLines = $"Perfume: {perfume._name}\n";
            if (perfume._description != null && perfume._description != "")
                outputStringLines += $"Description:\n{perfume._description}\n";
            
            outputStringLines += "Formula:\n";
            List<(IAccordPerfumeCompatible, MaterialUnit)> mainIngredients = perfume.GetIngredientsList();
            foreach ((IAccordPerfumeCompatible mainAccord, MaterialUnit mainAmount) in mainIngredients)
            {
                outputStringLines += $"\t{((Accord)mainAccord)._name} : {mainAmount.AllToString()}\n";
                outputStringLines += "\t\tAccord ingredients:\n";

                List<(IAccordCompatible, MaterialUnit)> accordIngredients = ((Accord)mainAccord).GetIngredientsList();
                foreach ((IAccordCompatible molecule, MaterialUnit moleculeAmount) in accordIngredients) // handle recurrent accords?
                {
                    if (molecule == null) continue;
                    outputStringLines += $"\t\t\t{((Molecule)molecule)._name} : {moleculeAmount.AllToString()}\n";
                }
            }

            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    saveFileDialog.Title = "Export Perfume";
                    saveFileDialog.FileName = $"Perfume_{perfume._name}.txt";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, outputStringLines);
                    }
                }
            } catch (Exception ex) { return false; }
            return true;
        }

        public static Mixture? NormalizeIngredientAmounts(Perfume perfume)
        {
            if (perfume == null) return null;
            Mixture normalizedPerf = new Mixture(
                perfume._name,
                perfume._fullAmount,
                perfume._concentration,
                perfume._totalPrice,
                perfume._dilutionType);
            normalizedPerf._description = perfume._description;
            normalizedPerf._comment = perfume._comment;

            List<(IAccordPerfumeCompatible, MaterialUnit)> mainIngredients = perfume.GetIngredientsList();
            
            // check if Perfume amount fits to sum of Accord amounts (with tolerance)
            float amountSum = 0;
            foreach ((_, MaterialUnit amount) in mainIngredients) { amountSum += amount.GetMilligramAmount(); }
            if (perfume._fullAmount.GetMilligramAmount() < (amountSum - 0.001) || perfume._fullAmount.GetMilligramAmount() > (amountSum + 0.001))
                throw new ArgumentOutOfRangeException("Sum of Perfume ingredient amounts is unequal to Perfume amount!");
            
            foreach ((IAccordPerfumeCompatible mainAccord, MaterialUnit mainAmount) in mainIngredients)
            {
                List<(IAccordCompatible, MaterialUnit)> accordIngredients = ((Accord)mainAccord).GetIngredientsList();
                foreach ((IAccordCompatible molecule, MaterialUnit moleculeAmount) in accordIngredients) // handle recurrent accords?
                {
                    //tdb...
                }
            }

            return normalizedPerf;
        }
    }
}
