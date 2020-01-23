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
        public void BubbleSortListNameTest()
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

            var sortedSorted = RunSortTest(values);

            Assert.AreEqual(item3.Name, sortedSorted[0].Name);
            Assert.AreEqual(item4.Name, sortedSorted[1].Name);
            Assert.AreEqual(item2.Name, sortedSorted[2].Name);
            Assert.AreEqual(item1.Name, sortedSorted[3].Name);
        }

        private List<BucketListItem> RunSortTest(List<BucketListItem> values)
        {
            ISort bubbleSort = new BubbleSort();

            var sortedList = bubbleSort.Sort(values, Enums.SortColumns.ListItemName);

            return sortedList;
        }
    }
}
