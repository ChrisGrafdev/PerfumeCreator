using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeCreator
{

    public abstract class Basis
    {
        /// <summary>
        /// Defines the Name of the component.
        /// </summary>
        public string _name { get; set; }

        /// <summary>
        /// Sets the complete amount of the component.
        /// For Molecules: full amount of the complete raw-material (used to calculate the price-per-milligram).
        /// For Accords/Perfumes: stores the combined amounts of all ingredients.
        /// </summary>
        public MaterialUnit _fullAmount { get; set; }

        /// <summary>
        /// Sets the currently used amount of the component.
        /// For Molecules: the amount of each Molecule drops/mg used in an Accord.
        /// For Accords: the amount of each Accord used in a Perfume.
        /// (not needed for Perfumes)
        /// </summary>
        public MaterialUnit _usedAmount { get; set; }

        /// <summary>
        /// Sets the dilution percentage of the components.
        /// Used to calculate the individuals/complete dilution of the components/Perfume.
        /// Important: Requires a concentration value between 0.0 and 1.0!
        /// </summary>
        public float _concentration { get; set; }

        /// <summary>
        /// Defines the price for the complete of a component
        /// For Molecules: Sets the price for the corresponding <paramref name="_fullAmount"/> of a raw material.
        /// For Accord/Perfume: Contains the price of the combination of all ingredients in relation to their amount.
        /// </summary>
        public float _totalPrice{ get; set; }

        /// <summary>
        /// Calculated price based on the values of amount and price.
        /// For Molecules: Calculated price based on <paramref name="_fullAmount"/> and <paramref name="_totalPrice"/>.
        /// For Accords/Perfumes: Calculated price based on <paramref name="_usedAmount"/> and <paramref name="_pricePerMilligram"/> of each ingredient.
        /// </summary>
        public float _pricePerMilligram { get; set; }

        /// <summary>
        /// Defines the dilution type of the Mixture.
        /// Possible values: Oil, Alcohol, Mix
        /// </summary>
        public DilutionType _dilutionType { get; set; }

        /// <summary>
        /// Sets a description for a Molecule/Accord/Perfume - optional.
        /// </summary>
        public string? _description { get; set; }

        /// <summary>
        /// Sets a comment for a Molecule/Accord/Perfume - optional.
        /// </summary>
        public string? _comment { get; set; }
        
        /// <summary>
        /// Standard contructor for the abstract class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="materialAmount"></param>
        /// <param name="concentration"></param>
        /// <param name="fullPrice"></param>
        /// <param name="dilutionType"></param>
        /// <param name="description"></param>
        /// <param name="comment"></param>
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
            _usedAmount = new MaterialUnit(UnitType.Milligram, 0);
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
            /// Important:
            /// The <paramref name="FullAmount"/> of the base collection is used to track the 
            /// combined amount of all mixed components.
            /// The <paramref name="UsedAmount"/> of the introduced component is used to define
            /// the amount of the component which should be mixed - this amount has to be
            /// specified befor using!
            /// </summary>
            /// <param name="baseMixture">A collection (Accord/Perfume) used as mixing basis</param>
            /// <param name="newComponent">A component (Molecule/Accord) which should be mixed into the existingMixture</param>
            /// <returns>ICollectionType which could be rather a Accord or Perfume, depending on its usecase</returns>
            /// <exception cref="ArgumentNullException"></exception>
            public static void MixGeneralFragrance(
                ref ICollectionType baseMixture, // Accord or Perfume
                IAccordCompatible newComponent) // Molecule or Accord
            {
                if (newComponent == null)
                    throw new ArgumentNullException("Some value for Mixture calculation is null!");
                else if (newComponent.UsedAmount.GetMilligramAmount() == 0)
                    throw new ArgumentNullException("UsedAmound of mixing component is not defined!");

                // Check if newComponent already exists inside the baseMixture
                // -> if yes, don't add new component, only update amount.
                IAccordCompatible? existingIngredient = baseMixture.CheckIngredientExistence(newComponent);
                if (existingIngredient != null) // -> component already exist => don't add new component, only update amount
                {
                    bool success = Mixing.UpdateIngredientAmount(ref baseMixture, newComponent.Name, newComponent.UsedAmount);
                    if (!success)
                    {
                        MessageBox.Show("Mixing Error - Existing ingredient were found, but the amount couldn't be updated.", "Mixing error", MessageBoxButtons.OK);
                    }
                    return; // changes applied and values calculated -> end
                }


                // calculate Amount and Concentration
                // Get the raw fragrance amount of the existing Mixture based on the Accord/Perfume concentration and the combined amount of all ingredients -> _fullamount
                float existingRawFragranceAmount = baseMixture.Concentration * baseMixture.FullAmount.GetMilligramAmount();

                // Calculate the fragrance amount of the new Mixture based on its concentration and the used amount (of this component)
                float newRawFragranceAmount = newComponent.Concentration * newComponent.UsedAmount.GetMilligramAmount(); // in case of Diluent concentration = 0

                //float combinedAmount = existingAmount.GetMilligramAmount() + newAmount.GetMilligramAmount();
                float combinedAmount = baseMixture.FullAmount.GetMilligramAmount() + newComponent.UsedAmount.GetMilligramAmount();

                if (combinedAmount == 0)
                    throw new ArgumentException("Added Mixture amount is zero!");// tbd: better way of handling
                float combinedConcentration = (existingRawFragranceAmount + newRawFragranceAmount) / combinedAmount;

                // calculate total Price
                float totalPriceExistingMix = baseMixture.PricePerMG * baseMixture.FullAmount.GetMilligramAmount();
                float totalPriceNewComponent = newComponent.PricePerMG * newComponent.UsedAmount.GetMilligramAmount();
                float combinedPrice = totalPriceExistingMix + totalPriceNewComponent;

                // Write/Add all data into baseMixture
                // required update:
                // -> FullAmount (new component added)
                // -> ingredientList (add new component)
                // -> PricePerMG (due to mixing)
                // -> TotalPrice (due to mixing)
                // -> Concentration (possible dilution)
                // -> DilutionType (possible dilution)
                MaterialUnit resultUnit = new MaterialUnit(UnitType.Milligram, combinedAmount);
                baseMixture.FullAmount = resultUnit;
                baseMixture.AddComponent(newComponent);
                baseMixture.PricePerMG = combinedPrice / combinedAmount;
                baseMixture.TotalPrice = combinedPrice;
                baseMixture.Concentration = combinedConcentration;
                DilutionType dilutionTypeResult = baseMixture.DilutionType;
                if (baseMixture.DilutionType != newComponent.DilutionType)
                    dilutionTypeResult = DilutionType.Mix;
            }

            public static bool UpdateIngredientAmount(ref ICollectionType collection, string changedComponentName, MaterialUnit changedAmount)
            {
                List<IAccordCompatible> ingredientsList = collection.GetIngredientsList();
                IAccordCompatible? existingComponent = ingredientsList.FirstOrDefault(x => x.Name == changedComponentName);
                if (existingComponent == null)
                    return false;
                existingComponent.UsedAmount.UpdateMaterialAmount(changedAmount);

                Mixture? resMixture = Mixing.RecalculateFullMix(collection.GetIngredientsList());
                if (resMixture == null)
                    return false;

                // apply resMixture changes back into collection
                collection.FullAmount = resMixture._fullAmount;
                collection.Concentration = resMixture._concentration;
                collection.PricePerMG = resMixture._pricePerMilligram;
                collection.TotalPrice = resMixture._totalPrice;
                collection.DilutionType = resMixture._dilutionType;
                return true;
            }

            public static Mixture? RecalculateFullMix(List<IAccordCompatible> ingredientsList)
            {
                if (ingredientsList?.Count == 0 || ingredientsList == null)
                    return null;

                Mixture baseMixture = new Mixture( // this mixture imitates the Accord/Perfume for recalculation
                    "collection",
                    ingredientsList[0].UsedAmount, // set fullAmount to the used amount of the first ingredient
                    new MaterialUnit(UnitType.Milligram, 0), // set used amount to zero (could be later defined if this is an Accord which is used in a Perfume
                    ingredientsList[0].Concentration,
                    ingredientsList[0].PricePerMG * ingredientsList[0].UsedAmount.GetMilligramAmount(), // reverse calculation of the current price (so far)
                    ingredientsList[0].DilutionType);
                
                foreach(IAccordCompatible frag in ingredientsList.Skip(1))
                {
                    // calculate Amount and Concentration
                    // Get the raw fragrance amount of the existing Mixture based on the Accord/Perfume concentration and the combined amount of all ingredients -> _fullamount
                    float existingRawFragranceAmount = baseMixture.Concentration * baseMixture.FullAmount.GetMilligramAmount();

                    // Calculate the fragrance amount of the new Mixture based on its concentration and the used amount (of this component)
                    float newRawFragranceAmount = frag.Concentration * frag.UsedAmount.GetMilligramAmount(); // in case of Diluent concentration = 0

                    //float combinedAmount = existingAmount.GetMilligramAmount() + newAmount.GetMilligramAmount();
                    float combinedAmount = baseMixture.FullAmount.GetMilligramAmount() + frag.UsedAmount.GetMilligramAmount();
                    if (combinedAmount == 0)
                        return null;
                        //throw new ArgumentException("Added Mixture amount is zero!");// tbd: better way of handling

                    // calculate concentration
                    float averageConcentration = (existingRawFragranceAmount + newRawFragranceAmount) / combinedAmount;

                    // calculate total Price
                    float totalPriceExistingMix = baseMixture.PricePerMG * baseMixture.FullAmount.GetMilligramAmount();
                    float totalPricefrag = frag.PricePerMG * frag.UsedAmount.GetMilligramAmount();
                    float combinedPrice = totalPriceExistingMix + totalPricefrag;

                    // update values into baseMixture
                    baseMixture._fullAmount.UpdateMaterialAmount(UnitType.Milligram, combinedAmount);
                    baseMixture._concentration = averageConcentration;
                    baseMixture._totalPrice = combinedPrice;
                    baseMixture._pricePerMilligram = combinedPrice / combinedAmount;
                    if (baseMixture.DilutionType != frag.DilutionType)
                        baseMixture.DilutionType = DilutionType.Mix;
                }
                return baseMixture;
            }
        }
    }
}
