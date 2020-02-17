using Algorithms.Algorithms.Sorting.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.misc;

namespace Algorithms_Unit
{
    [TestClass]
    public class BubbleSortingTests : BaseSortingTest
    {
        #region name tests

        [TestMethod]
        public void BubbleSortListNameAscTest()
        {
            var sortedValues = RunSortTest(GetNameValues(), Enums.SortColumns.ListItemName, false, new BubbleSort());
            ValidateSortListNameAscTest(GetNameValues(), sortedValues);
        }

        [TestMethod]
        public void BubbleSortListNameDescTest()
        {
            var sortedValues = RunSortTest(GetNameValues(), Enums.SortColumns.ListItemName, true, new BubbleSort());
            ValidateSortListCreatedDescTest(GetNameValues(), sortedValues);
        }

        #endregion

        #region created tests

        [TestMethod]
        public void BubbleSortListCreatedAscTest()
        {
            var sortedValues = RunSortTest(GetCreatedValues(), Enums.SortColumns.Created, false, new BubbleSort());
            ValidateSortListCreatedAscTest(GetCreatedValues(), sortedValues);
        }

        [TestMethod]
        public void BubbleSortListCreatedDescTest()
        {
            var sortedValues = RunSortTest(GetCreatedValues(), Enums.SortColumns.Created, true, new BubbleSort());
            ValidateSortListCreatedDescTest(GetCreatedValues(), sortedValues);
        }

        #endregion

        #region category tests

        [TestMethod]
        public void BubbleSortListCategoryAscTest()
        {
            var sortedValues = RunSortTest(GetCategoryValues(), Enums.SortColumns.Category, false, new BubbleSort());
            ValidateSortListCategoryAscTest(GetCategoryValues(), sortedValues);
        }

        [TestMethod]
        public void BubbleSortListCategoryDescTest()
        {
            var sortedValues = RunSortTest(GetCategoryValues(), Enums.SortColumns.Category, true, new BubbleSort());
            ValidateSortListCategoryDescTest(GetCategoryValues(), sortedValues, false);
        }

        #endregion

        #region acheived tests

        [TestMethod]
        public void BubbleSortListAchievedAscTest()
        {
            var sortedValues = RunSortTest(GetAchievedValues(), Enums.SortColumns.Achieved, false, new BubbleSort());
            ValidateSortAchievedAscTest(sortedValues);
        }

        [TestMethod]
        public void BubbleSortListAchievedDescTest()
        {
            var sortedValues = RunSortTest(GetAchievedValues(), Enums.SortColumns.Achieved, true, new BubbleSort());
            ValidateSortAchievedDescTest(sortedValues);
        }

        #endregion
    }
}
