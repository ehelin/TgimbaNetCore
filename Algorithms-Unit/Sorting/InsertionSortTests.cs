using Algorithms.Algorithms.Sorting.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.misc;

namespace Algorithms_Unit
{
    [TestClass]
    public class InsertionSortTests : BaseSortingTest
    {
        #region name tests

        [TestMethod]
        public void InsertionSortListNameAscTest()
        {
            var sortedValues = RunSortTest(GetNameValues(), Enums.SortColumns.ListItemName, false, new InsertionSort());
            ValidateSortListNameAscTest(GetNameValues(), sortedValues);
        }

        [TestMethod]
        public void InsertionSortListNameDescTest()
        {
            var sortedValues = RunSortTest(GetNameValues(), Enums.SortColumns.ListItemName, true, new InsertionSort());
            ValidateSortListCreatedDescTest(GetNameValues(), sortedValues);
        }

        #endregion

        #region created tests

        [TestMethod]
        public void InsertionSortListCreatedAscTest()
        {
            var sortedValues = RunSortTest(GetCreatedValues(), Enums.SortColumns.Created, false, new InsertionSort());
            ValidateSortListCreatedAscTest(GetCreatedValues(), sortedValues);
        }

        [TestMethod]
        public void InsertionSortListCreatedDescTest()
        {
            var sortedValues = RunSortTest(GetCreatedValues(), Enums.SortColumns.Created, true, new InsertionSort());
            ValidateSortListCreatedDescTest(GetCreatedValues(), sortedValues);
        }

        #endregion

        #region category tests

        [TestMethod]
        public void InsertionSortListCategoryAscTest()
        {
            var sortedValues = RunSortTest(GetCategoryValues(), Enums.SortColumns.Category, false, new InsertionSort());
            ValidateSortListCategoryAscTest(GetCategoryValues(), sortedValues);
        }

        [TestMethod]
        public void InsertionSortListCategoryDescTest()
        {
            var sortedValues = RunSortTest(GetCategoryValues(), Enums.SortColumns.Category, true, new InsertionSort());
            ValidateSortListCategoryDescTest(GetCategoryValues(), sortedValues, false);
        }

        #endregion

        #region acheived tests

        [TestMethod]
        public void InsertionSortListAchievedAscTest()
        {
            var sortedValues = RunSortTest(GetAchievedValues(), Enums.SortColumns.Achieved, false, new InsertionSort());
            ValidateSortAchievedAscTest(sortedValues);
        }

        [TestMethod]
        public void InsertionSortListAchievedDescTest()
        {
            var sortedValues = RunSortTest(GetAchievedValues(), Enums.SortColumns.Achieved, true, new InsertionSort());
            ValidateSortAchievedDescTest(sortedValues);
        }

        #endregion
    }
}
