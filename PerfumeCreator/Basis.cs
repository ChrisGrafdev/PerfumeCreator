using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeCreator
{

    public abstract class Basis
    {
        public string _name { get; set; }
        public MaterialUnit _fullAmount { get; set; }
        public float _concentration { get; set; } /// concentration value between 0.0 and 1.0 required
        public float _totalPrice{ get; set; }
        public float _pricePerMilligram { get; set; }
        public DilutionType _dilutionType { get; set; }
        public string? _description { get; set; }
        public string? _comment { get; set; }
        // +++
        //protected bool _emptyObject = false;

        /*public Basis(string name)
        {
            _name = name;
            _emptyObject = true;
        }*/

        public Basis(
            string name,
            MaterialUnit materialAmount,
            float concentration,
            float fullPrice,
            DilutionType dilutionType,
            string? description = null,
            string? comment = null)
        {
            _name = name;
            _fullAmount = materialAmount;
            _concentration = concentration;
            _totalPrice = fullPrice;
            _pricePerMilligram = fullPrice / materialAmount.GetMilligramAmount();
            _dilutionType = dilutionType;
            _description = description;
            _comment = comment;
            //_emptyObject = false;
        }

        protected static class Mixing
        {
            /// <summary>
            /// Internal static function to mix different components together.
            /// Note: The function takes basically all types of components converted as "Basis"
            /// types to be more flexible. The additional required material amounts are needed
            /// to calculate the correct value (even if the Basis-objects contain there own
            /// "_amount" variable. This circumstand is used to avoid wrong calculations due
            /// to amount missmatches. The resulting Accord type is only for holding the important
            /// informations. It ignores members like comments or note-level for simplicity,
            /// but due to this fact, this method should be used inside a wrapper function.
            /// </summary>
            /// <param name="existingMixture"></param> as "Basis" converted component (could be anything Molecule/Accord/Diluent even Perfume, even if that doesn't make sense).
            /// <param name="existingAmount"></param> specific material amount of the Basis component
            /// <param name="newComponent"></param> as "Basis" converted component which should be mixed to the existing mixture.
            /// <param name="newAmount"></param> specific material amount of the added component
            /// <returns>(Mixture, MaterialUnit)</returns> where "Accord"-part of the tuple contains all required informations of the resulting mixture with the specific resulting amount which is specified in the "MaterialUnit"-part.
            /// <exception cref="ArgumentNullException"></exception>
            public static (Mixture, MaterialUnit) MixGeneralFragrance(
                Basis existingMixture,
                MaterialUnit existingAmount,
                Basis newComponent,
                MaterialUnit newAmount)
            {
                if (existingMixture == null || existingAmount == null || newComponent == null || newAmount == null)
                    throw new ArgumentNullException("Some value for Mixture calculation is null!");

                DilutionType dilutionTypeResult = existingMixture._dilutionType;
                if (existingMixture._dilutionType != newComponent._dilutionType)
                {
                    dilutionTypeResult = DilutionType.Mix;
                }
                // calculate Amount and Concentration
                float existingRawFragranceAmount = existingMixture._concentration * existingAmount.GetMilligramAmount();
                float newRawFragranceAmount = newComponent._concentration * newAmount.GetMilligramAmount(); // in case of Diluent concentration = 0
                float combinedAmount = existingAmount.GetMilligramAmount() + newAmount.GetMilligramAmount();
                if (combinedAmount == 0)
                    throw new ArgumentException("Added Mixture amount is zero!");// tbd: better way of handling
                float combinedConcentration = (existingRawFragranceAmount + newRawFragranceAmount) / combinedAmount;
                
                // calculate total Price
                float totalPriceExistingMix = existingMixture._pricePerMilligram * existingAmount.GetMilligramAmount();
                float totalPriceNewComponent = newComponent._pricePerMilligram * newAmount.GetMilligramAmount();
                float combinedPrice = totalPriceExistingMix + totalPriceNewComponent;

                MaterialUnit resultUnit = new MaterialUnit(UnitType.Milligram, combinedAmount);
                Mixture resultMixture = new Mixture(existingMixture._name, resultUnit, combinedConcentration, combinedPrice, dilutionTypeResult);
                return (resultMixture, resultUnit);
            }
        }
    }
}
