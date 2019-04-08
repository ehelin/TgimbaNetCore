using Algorithms.PredictCategoryCountry.Perceptron;
using System;
														  
namespace Algorithms.PredictCategoryCountry.Perceptron
{
    public class CountryCategoryPerceptron
    {
        //public CountryCategoryTrainingSet Train(CountryCategoryTrainingSet trainingSet)
        //{
           // throw new NotImplementedException();
            //var learningRate = 1;
            //var totalError = 1;
            //var ctr = 1;

            //while (totalError > .2)
            //{
            //    for (var i = 0; i < trainingSet.countriesCategories.Count; i++)
            //    {
            //        var curTrainingSet = trainingSet.countriesCategories[i];

            //        var total = trainingSet.x * weights[0] + trainingSet.y * weights[1] + 1 * weights[2];

            //        var output = 0;
            //        if (total >= 0)
            //        {
            //            output = 1;
            //        }

            //        var error = trainingSet.expectedOutput - output;

            //        weights[0] += learningRate * error * trainingSet.x;
            //        weights[1] += learningRate * error * trainingSet.y;
            //        weights[2] += learningRate * error * 1;

            //        totalError = Math.abs(error);
            //    }

            //    ctr++;
            //}

            //return weights;
        //}
    }
}

//function run(trainingSet, pWeights)
//{
//    var total = trainingSet.x * pWeights[0] + trainingSet.y * pWeights[1] + 1 * pWeights[2];

//    var output = 0;
//    if (total >= 0)
//    {
//        return 1;
//    }
//    else
//    {
//        return 0;
//    }
//}
