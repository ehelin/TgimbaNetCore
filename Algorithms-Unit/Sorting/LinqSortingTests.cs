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
            var valuesToBeSorted = GetNameValues();
            var valuesToBeCompared = GetNameValues();

            var sortedValues = RunSortTest(valuesToBeSorted, Enums.SortColumns.ListItemName, false, new LinqSort());
            ValidateSortListNameAscTest(valuesToBeCompared, sortedValues);
        }

        [TestMethod]
        public void LinqSortListNameDescTest()
        {
            var valuesToBeSorted = GetNameValues();
            var valuesToBeCompared = GetNameValues();

            var sortedValues = RunSortTest(valuesToBeSorted, Enums.SortColumns.ListItemName, true, new LinqSort());
            ValidateSortListCreatedDescTest(valuesToBeCompared, sortedValues);
        }

        #endregion

        #region created tests

        [TestMethod]
        public void LinqSortListCreatedAscTest()
        {
            var valuesToBeSorted = GetCreatedValues();
            var valuesToBeCompared = GetCreatedValues();

            var sortedValues = RunSortTest(valuesToBeSorted, Enums.SortColumns.Created, false, new LinqSort());
            ValidateSortListCreatedAscTest(valuesToBeCompared, sortedValues);
        }

        [TestMethod]
        public void LinqSortListCreatedDescTest()
        {
            var valuesToBeSorted = GetCreatedValues();
            var valuesToBeCompared = GetCreatedValues();

            var sortedValues = RunSortTest(valuesToBeSorted, Enums.SortColumns.Created, true, new LinqSort());
            ValidateSortListCreatedDescTest(valuesToBeCompared, sortedValues);
        }

        #endregion

        #region category tests

        [TestMethod]
        public void LinqSortListCategoryAscTest()
        {
            var valuesToBeSorted = GetCategoryValues();
            var valuesToBeCompared = GetCategoryValues();

            var sortedValues = RunSortTest(valuesToBeSorted, Enums.SortColumns.Category, false, new LinqSort());
            ValidateSortListCategoryAscTest(valuesToBeCompared, sortedValues);
        }

        [TestMethod]
        public void LinqSortListCategoryDescTest()
        {
            var valuesToBeSorted = GetCategoryValues();
            var valuesToBeCompared = GetCategoryValues();

            var sortedValues = RunSortTest(valuesToBeSorted, Enums.SortColumns.Category, true, new LinqSort());
            ValidateSortListCategoryDescTest(valuesToBeCompared, sortedValues, true);
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
