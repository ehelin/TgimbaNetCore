using Shared.misc;
using Algorithms.Algorithms.Search;

namespace Algorithms.Algorithms.Sorting
{
    public interface IAvailableSearchingAlgorithms
    {
        ISearch GetAlgorithm(Enums.SearchAlgorithms algorithm);
    }
}
