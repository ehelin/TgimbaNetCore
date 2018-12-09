using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.PredictCategoryCountry.Perceptron.Data;

namespace TestAlgorithms
{
    [TestClass]
    public class TestPerceptron
    {
        [TestMethod]
        public void TestCategoryHotWithFrance()
        {
            CountryCategoryTrainingSet trainingSet = TestData.GetHotCategoryFranceTrainingSet();
            
        }


    }
}
