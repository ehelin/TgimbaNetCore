using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.dto;
using Shared.misc;
using System.Collections.Generic;
using Algorithms.Algorithms.Sorting;
using Algorithms.Algorithms.Sorting.Implementations;

namespace Algorithms_Unit
{
    [TestClass]
    public class SortingTests
    {
        [TestMethod]
        public void BubbleSortListNameAscTest()
        {
            var compareValues = GetValues();

            var sortedSorted = RunSortTest(GetValues(), false);

            Assert.AreEqual(compareValues[2].Name, sortedSorted[0].Name);
            Assert.AreEqual(compareValues[3].Name, sortedSorted[1].Name);
            Assert.AreEqual(compareValues[1].Name, sortedSorted[2].Name);
            Assert.AreEqual(compareValues[0].Name, sortedSorted[3].Name);
        }

        [TestMethod]
        public void BubbleSortListNameDescTest()
        {
            var compareValues = GetValues();

            var sortedSorted = RunSortTest(GetValues(), true);

            Assert.AreEqual(compareValues[0].Name, sortedSorted[0].Name);
            Assert.AreEqual(compareValues[1].Name, sortedSorted[1].Name);
            Assert.AreEqual(compareValues[3].Name, sortedSorted[2].Name);
            Assert.AreEqual(compareValues[2].Name, sortedSorted[3].Name);
        }

        #region Private Methods

        private List<BucketListItem> RunSortTest(List<BucketListItem> values, bool desc)
        {
            ISort bubbleSort = new BubbleSort();

            var sortedList = bubbleSort.Sort(values, Enums.SortColumns.ListItemName, desc);

            return sortedList;
        }
               
        private List<BucketListItem> GetValues()
        {
            var values = new List<BucketListItem>();

            var item1 = new BucketListItem() { Name = "ZBucketListItem" };
            var item2 = new BucketListItem() { Name = "yBucketListItem" };
            var item3 = new BucketListItem() { Name = "ABucketListItem" };
            var item4 = new BucketListItem() { Name = "tBucketListItem" };

            values.Add(item1);
            values.Add(item2);
            values.Add(item3);
            values.Add(item4);

            return values;
        }

        #endregion
    }
}
