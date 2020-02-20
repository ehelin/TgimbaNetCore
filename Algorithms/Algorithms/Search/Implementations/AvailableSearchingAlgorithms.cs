using System.Collections.Generic;
using Shared.misc;
using Algorithms.Algorithms.Search;

namespace Algorithms.Algorithms.Sorting.Implementations
{
    public class AvailableSearchingAlgorithms : IAvailableSearchingAlgorithms
    {
        private IList<ISearch> searchingAlgorithms = null;

        public AvailableSearchingAlgorithms(IList<ISearch> searchingAlgorithms)
        {
            this.searchingAlgorithms = searchingAlgorithms;
        }

        public ISearch GetAlgorithm(Enums.SearchAlgorithms algorithm)
        {
            ISearch selectedSearchingAlgorithmImpl = null;

            foreach(ISearch searchingAlgorithm in searchingAlgorithms)
            {
                if (searchingAlgorithm.GetSearchingAlgorithm() == algorithm)
                {
                    selectedSearchingAlgorithmImpl = searchingAlgorithm;
                    break;
                }
            }

            return selectedSearchingAlgorithmImpl;
        }
    }
}
