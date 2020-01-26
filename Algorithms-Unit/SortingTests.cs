using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.dto;
using Shared.misc;
using System.Collections.Generic;
using Algorithms.Algorithms.Sorting;
using Algorithms.Algorithms.Sorting.Implementations;
using System;

namespace Algorithms_Unit
{
    [TestClass]
    public class SortingTests
    {
        #region name tests

        [TestMethod]
        public void BubbleSortListNameAscTest()
        {
            var compareValues = GetNameValues();

            var sortedSorted = RunSortTest(GetNameValues(), Enums.SortColumns.ListItemName, false);

            Assert.AreEqual(compareValues[2].Name, sortedSorted[0].Name);
            Assert.AreEqual(compareValues[3].Name, sortedSorted[1].Name);
            Assert.AreEqual(compareValues[1].Name, sortedSorted[2].Name);
            Assert.AreEqual(compareValues[0].Name, sortedSorted[3].Name);
        }

        [TestMethod]
        public void BubbleSortListNameDescTest()
        {
            var compareValues = GetNameValues();

            var sortedSorted = RunSortTest(GetNameValues(), Enums.SortColumns.ListItemName, true);

            Assert.AreEqual(compareValues[0].Name, sortedSorted[0].Name);
            Assert.AreEqual(compareValues[1].Name, sortedSorted[1].Name);
            Assert.AreEqual(compareValues[3].Name, sortedSorted[2].Name);
            Assert.AreEqual(compareValues[2].Name, sortedSorted[3].Name);
        }

        #endregion

        #region created tests

        [TestMethod]
        public void BubbleSortListCreatedAscTest()
        {
            var compareValues = GetCreatedValues();

            var sortedSorted = RunSortTest(GetCreatedValues(), Enums.SortColumns.Created, false);
            
            Assert.AreEqual(compareValues[2].Created.ToString("yyyyMMddHHmmss"), 
                            sortedSorted[0].Created.ToString("yyyyMMddHHmmss"));
            Assert.AreEqual(compareValues[0].Created.ToString("yyyyMMddHHmmss"), 
                            sortedSorted[1].Created.ToString("yyyyMMddHHmmss"));
            Assert.AreEqual(compareValues[3].Created.ToString("yyyyMMddHHmmss"), 
                            sortedSorted[2].Created.ToString("yyyyMMddHHmmss"));
            Assert.AreEqual(compareValues[1].Created.ToString("yyyyMMddHHmmss"), 
                            sortedSorted[3].Created.ToString("yyyyMMddHHmmss"));
        }

        [TestMethod]
        public void BubbleSortListCreatedDescTest()
        {
            var compareValues = GetCreatedValues();

            var sortedSorted = RunSortTest(GetCreatedValues(), Enums.SortColumns.Created, true);

            Assert.AreEqual(compareValues[1].Created.ToString("yyyyMMddHHmmss"), 
                            sortedSorted[0].Created.ToString("yyyyMMddHHmmss"));
            Assert.AreEqual(compareValues[3].Created.ToString("yyyyMMddHHmmss"), 
                            sortedSorted[1].Created.ToString("yyyyMMddHHmmss"));
            Assert.AreEqual(compareValues[0].Created.ToString("yyyyMMddHHmmss"), 
                            sortedSorted[2].Created.ToString("yyyyMMddHHmmss"));
            Assert.AreEqual(compareValues[2].Created.ToString("yyyyMMddHHmmss"), 
                            sortedSorted[3].Created.ToString("yyyyMMddHHmmss"));
        }

        #endregion

        #region category tests

        [TestMethod]
        public void BubbleSortListCategoryAscTest()
        {
            var compareValues = GetCategoryValues();

            var sortedSorted = RunSortTest(GetCategoryValues(), Enums.SortColumns.Category, false);

            Assert.AreEqual(compareValues[1].Category, sortedSorted[0].Category);
            Assert.AreEqual(compareValues[3].Category, sortedSorted[1].Category);
            Assert.AreEqual(compareValues[2].Category, sortedSorted[2].Category);
            Assert.AreEqual(compareValues[0].Category, sortedSorted[3].Category);
        }

        [TestMethod]
        public void BubbleSortListCategoryDescTest()
        {
            var compareValues = GetCategoryValues();

            var sortedSorted = RunSortTest(GetCategoryValues(), Enums.SortColumns.Category, true);

            Assert.AreEqual(compareValues[0].Category, sortedSorted[0].Category);
            Assert.AreEqual(compareValues[2].Category, sortedSorted[1].Category);
            Assert.AreEqual(compareValues[1].Category, sortedSorted[2].Category);
            Assert.AreEqual(compareValues[3].Category, sortedSorted[3].Category);
        }

        #endregion

        #region acheived tests

        [TestMethod]
        public void BubbleSortListAchievedAscTest()
        {
            var compareValues = GetAchievedValues();

            var sortedSorted = RunSortTest(GetAchievedValues(), Enums.SortColumns.Achieved, false);

            Assert.AreEqual(false, sortedSorted[0].Achieved);
            Assert.AreEqual(false, sortedSorted[1].Achieved);
            Assert.AreEqual(true, sortedSorted[2].Achieved);
            Assert.AreEqual(true, sortedSorted[3].Achieved);
        }

        [TestMethod]
        public void BubbleSortListAchievedDescTest()
        {
            var compareValues = GetAchievedValues();

            var sortedSorted = RunSortTest(GetAchievedValues(), Enums.SortColumns.Achieved, true);

            Assert.AreEqual(true, sortedSorted[0].Achieved);
            Assert.AreEqual(true, sortedSorted[1].Achieved);
            Assert.AreEqual(false, sortedSorted[2].Achieved);
            Assert.AreEqual(false, sortedSorted[3].Achieved);
        }

        #endregion

        #region Private Methods

        private List<BucketListItem> RunSortTest(List<BucketListItem> values, Enums.SortColumns sortColumn, bool desc)
        {
            ISort bubbleSort = new BubbleSort();

            var sortedList = bubbleSort.Sort(values, sortColumn, desc);

            return sortedList;
        }
               
        private List<BucketListItem> GetNameValues()
        {
            var values = new List<BucketListItem>();

            values.Add(new BucketListItem() { Name = "ZBucketListItem" });
            values.Add(new BucketListItem() { Name = "yBucketListItem" });
            values.Add(new BucketListItem() { Name = "ABucketListItem" });
            values.Add(new BucketListItem() { Name = "tBucketListItem" });

            return values;
        }

        private List<BucketListItem> GetCreatedValues()
        {
            var values = new List<BucketListItem>();

            values.Add(new BucketListItem() { Created = DateTime.UtcNow.AddDays(-3) });
            values.Add(new BucketListItem() { Created = DateTime.UtcNow.AddDays(-1) });
            values.Add(new BucketListItem() { Created = DateTime.UtcNow.AddDays(-10) });
            values.Add(new BucketListItem() { Created = DateTime.UtcNow.AddDays(-2) });

            return values;
        }

        private List<BucketListItem> GetCategoryValues()
        {
            var values = new List<BucketListItem>();

            values.Add(new BucketListItem() { Category = Enums.BucketListItemTypes.Warm.ToString() });
            values.Add(new BucketListItem() { Category = Enums.BucketListItemTypes.Cold.ToString() });
            values.Add(new BucketListItem() { Category = Enums.BucketListItemTypes.Hot.ToString() });
            values.Add(new BucketListItem() { Category = Enums.BucketListItemTypes.Cool.ToString() });

            return values;
        }

        private List<BucketListItem> GetAchievedValues()
        {
            var values = new List<BucketListItem>();

            values.Add(new BucketListItem() { Achieved = false });
            values.Add(new BucketListItem() { Achieved = true });
            values.Add(new BucketListItem() { Achieved = false });
            values.Add(new BucketListItem() { Achieved = true });

            return values;
        }

        #endregion
    }
}
