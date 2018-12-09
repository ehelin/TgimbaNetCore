using Algorithms.PredictCategoryCountry.Perceptron.Data;
using Algorithms.PredictCategoryCountry;

//public enum Country { France, Germany, Mexico, UnitedStates, Turkey, Japan };
//public enum Category { Hot, Warm, Cool };

namespace TestAlgorithms
{
    public class TestData
    {
        public static CountryCategoryTrainingSet GetHotCategoryFranceTrainingSet()
        {
            CountryCategoryTrainingSet hotFranceTrainingSet = new CountryCategoryTrainingSet();

            hotFranceTrainingSet.countriesCategories.Add(new CountryCategoryTraining(Enumerations.Country.France, Enumerations.Category.Hot, true));
            hotFranceTrainingSet.countriesCategories.Add(new CountryCategoryTraining(Enumerations.Country.France, Enumerations.Category.Warm, false));
            hotFranceTrainingSet.countriesCategories.Add(new CountryCategoryTraining(Enumerations.Country.France, Enumerations.Category.Cool, false));
            hotFranceTrainingSet.countriesCategories.Add(new CountryCategoryTraining(Enumerations.Country.Germany, Enumerations.Category.Hot, false));
            hotFranceTrainingSet.countriesCategories.Add(new CountryCategoryTraining(Enumerations.Country.Germany, Enumerations.Category.Cool, false));
            hotFranceTrainingSet.countriesCategories.Add(new CountryCategoryTraining(Enumerations.Country.Germany, Enumerations.Category.Warm, false));
            hotFranceTrainingSet.countriesCategories.Add(new CountryCategoryTraining(Enumerations.Country.Mexico, Enumerations.Category.Hot, false));
            hotFranceTrainingSet.countriesCategories.Add(new CountryCategoryTraining(Enumerations.Country.Mexico, Enumerations.Category.Warm, false));
            hotFranceTrainingSet.countriesCategories.Add(new CountryCategoryTraining(Enumerations.Country.Mexico, Enumerations.Category.Cool, false));
            hotFranceTrainingSet.countriesCategories.Add(new CountryCategoryTraining(Enumerations.Country.UnitedStates, Enumerations.Category.Hot, false));
            hotFranceTrainingSet.countriesCategories.Add(new CountryCategoryTraining(Enumerations.Country.UnitedStates, Enumerations.Category.Cool, false));
            hotFranceTrainingSet.countriesCategories.Add(new CountryCategoryTraining(Enumerations.Country.UnitedStates, Enumerations.Category.Warm, false));
            hotFranceTrainingSet.countriesCategories.Add(new CountryCategoryTraining(Enumerations.Country.Turkey, Enumerations.Category.Hot, false));
            hotFranceTrainingSet.countriesCategories.Add(new CountryCategoryTraining(Enumerations.Country.Turkey, Enumerations.Category.Cool, false));
            hotFranceTrainingSet.countriesCategories.Add(new CountryCategoryTraining(Enumerations.Country.Turkey, Enumerations.Category.Warm, false));
            hotFranceTrainingSet.countriesCategories.Add(new CountryCategoryTraining(Enumerations.Country.Japan, Enumerations.Category.Hot, false));
            hotFranceTrainingSet.countriesCategories.Add(new CountryCategoryTraining(Enumerations.Country.Japan, Enumerations.Category.Warm, false));
            hotFranceTrainingSet.countriesCategories.Add(new CountryCategoryTraining(Enumerations.Country.Japan, Enumerations.Category.Cool, false));

            return hotFranceTrainingSet;
        }
    }
}
