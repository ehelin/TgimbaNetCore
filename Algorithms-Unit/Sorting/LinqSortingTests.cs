using Algorithms.Algorithms.Sorting.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.misc;

namespace Algorithms_Unit
{
    [TestClass]
    public class LinqSortingTests : BaseSortingTest
    {
        #region name tests

        [TestMethod]
        public void LinqSortListNameAscTest()
        {
            var sortedValues = RunSortTest(GetNameValues(), Enums.SortColumns.ListItemName, false, new LinqSort());
            ValidateSortListNameAscTest(GetNameValues(), sortedValues);
        }

        [TestMethod]
        public void LinqSortListNameDescTest()
        {
            var sortedValues = RunSortTest(GetNameValues(), Enums.SortColumns.ListItemName, true, new LinqSort());
            ValidateSortListCreatedDescTest(GetNameValues(), sortedValues);
        }

        #endregion

        #region created tests

        [TestMethod]
        public void LinqSortListCreatedAscTest()
        {
            var sortedValues = RunSortTest(GetCreatedValues(), Enums.SortColumns.Created, false, new LinqSort());
            ValidateSortListCreatedAscTest(GetCreatedValues(), sortedValues);
        }

        [TestMethod]
        public void LinqSortListCreatedDescTest()
        {
            var sortedValues = RunSortTest(GetCreatedValues(), Enums.SortColumns.Created, true, new LinqSort());
            ValidateSortListCreatedDescTest(GetCreatedValues(), sortedValues);
        }

        #endregion

        #region category tests

        [TestMethod]
        public void LinqSortListCategoryAscTest()
        {
            var sortedValues = RunSortTest(GetCategoryValues(), Enums.SortColumns.Category, false, new LinqSort());
            ValidateSortListCategoryAscTest(GetCategoryValues(), sortedValues);
        }

        [TestMethod]
        public void LinqSortListCategoryDescTest()
        {
            var sortedValues = RunSortTest(GetCategoryValues(), Enums.SortColumns.Category, true, new LinqSort());
            ValidateSortListCategoryDescTest(GetCategoryValues(), sortedValues, true);
        }

        #endregion

        #region acheived tests

        [TestMethod]
        public void LinqSortListAchievedAscTest()
        {
            var sortedValues = RunSortTest(GetAchievedValues(), Enums.SortColumns.Achieved, false, new LinqSort());
            ValidateSortAchievedAscTest(sortedValues);
        }

        [TestMethod]
        public void LinqSortListAchievedDescTest()
        {
            var sortedValues = RunSortTest(GetAchievedValues(), Enums.SortColumns.Achieved, true, new LinqSort());
            ValidateSortAchievedDescTest(sortedValues);
        }

        #endregion
    }
}
