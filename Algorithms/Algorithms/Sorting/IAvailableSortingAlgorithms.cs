using Shared.misc;

namespace Algorithms.Algorithms.Sorting
{
    public interface IAvailableSortingAlgorithms
    {
        ISort GetAlgorithm(Enums.SortAlgorithms algorithm);
    }
}
