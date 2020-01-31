using System.Collections.Generic;
using Shared.misc;

namespace Algorithms.Algorithms.Sorting.Implementations
{
    public class AvailableSortingAlgorithms : IAvailableSortingAlgorithms
    {
        private IList<ISort> sortingAlgorithms = null;

        public AvailableSortingAlgorithms(IList<ISort> sortingAlgorithms)
        {
            this.sortingAlgorithms = sortingAlgorithms;
        }

        public ISort GetAlgorithm(Enums.SortAlgorithms algorithm)
        {
            ISort selectedSortingAlgorithmImpl = null;

            foreach(ISort sortingAlgorithm in sortingAlgorithms)
            {
                if (sortingAlgorithm.GetSortingAlgorithm() == algorithm)
                {
                    selectedSortingAlgorithmImpl = sortingAlgorithm;
                    break;
                }
            }

            return selectedSortingAlgorithmImpl;
        }
    }
}
