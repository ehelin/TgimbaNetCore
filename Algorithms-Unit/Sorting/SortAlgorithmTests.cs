using Algorithms.Algorithms.Sorting.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.misc;
using Algorithms.Algorithms.Sorting;

namespace Algorithms_Unit
{
    [TestClass]
    public class SortAlgorithmTests : BaseSortingTest
    {
        [TestMethod]
        public void SortAlgorithmGetAlgorithmLinqTest()
        {
            var sortingAlgorithms = GetSortingAlgorithms();
            var sut = new AvailableSortingAlgorithms(sortingAlgorithms);

            ISort sortingAlgorithm = sut.GetAlgorithm(Enums.SortAlgorithms.Linq);

            Assert.IsNotNull(sortingAlgorithm);
            Assert.AreEqual(Enums.SortAlgorithms.Linq, sortingAlgorithm.GetSortingAlgorithm());
        }

        [TestMethod]
        public void SortAlgorithmGetAlgorithmBubbleTest()
        {
            var sortingAlgorithms = GetSortingAlgorithms();
            var sut = new AvailableSortingAlgorithms(sortingAlgorithms);

            ISort sortingAlgorithm = sut.GetAlgorithm(Enums.SortAlgorithms.Bubble);

            Assert.IsNotNull(sortingAlgorithm);
            Assert.AreEqual(Enums.SortAlgorithms.Bubble, sortingAlgorithm.GetSortingAlgorithm());
        }
    }
}
