using System;
using System.Collections.Generic;
using Algorithms.Algorithms.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.dto;
using Shared.misc;

namespace Algorithms_Unit
{
    [TestClass]
    public class BaseSortingTest
    {
        protected void ValidateSortListNameAscTest(List<BucketListItem> compareValues, List<BucketListItem> sortedSorted)
        {
            Assert.AreEqual(compareValues[2].Name, sortedSorted[0].Name);
            Assert.AreEqual(compareValues[3].Name, sortedSorted[1].Name);
            Assert.AreEqual(compareValues[1].Name, sortedSorted[2].Name);
            Assert.AreEqual(compareValues[0].Name, sortedSorted[3].Name);
        }

        protected void ValidateSortListNameDescTest(List<BucketListItem> compareValues, List<BucketListItem> sortedSorted)
        {
            Assert.AreEqual(compareValues[0].Name, sortedSorted[0].Name);
            Assert.AreEqual(compareValues[1].Name, sortedSorted[1].Name);
            Assert.AreEqual(compareValues[3].Name, sortedSorted[2].Name);
            Assert.AreEqual(compareValues[2].Name, sortedSorted[3].Name);
        }

        protected void ValidateSortListCreatedAscTest(List<BucketListItem> compareValues, List<BucketListItem> sortedSorted)
        {            
            Assert.AreEqual(compareValues[2].Created.ToString("yyyyMMddHHmmss"), 
                            sortedSorted[0].Created.ToString("yyyyMMddHHmmss"));
            Assert.AreEqual(compareValues[0].Created.ToString("yyyyMMddHHmmss"), 
                            sortedSorted[1].Created.ToString("yyyyMMddHHmmss"));
            Assert.AreEqual(compareValues[3].Created.ToString("yyyyMMddHHmmss"), 
                            sortedSorted[2].Created.ToString("yyyyMMddHHmmss"));
            Assert.AreEqual(compareValues[1].Created.ToString("yyyyMMddHHmmss"), 
                            sortedSorted[3].Created.ToString("yyyyMMddHHmmss"));
        }

        protected void ValidateSortListCreatedDescTest(List<BucketListItem> compareValues, List<BucketListItem> sortedSorted)
        {
            Assert.AreEqual(compareValues[1].Created.ToString("yyyyMMddHHmmss"), 
                            sortedSorted[0].Created.ToString("yyyyMMddHHmmss"));
            Assert.AreEqual(compareValues[3].Created.ToString("yyyyMMddHHmmss"), 
                            sortedSorted[1].Created.ToString("yyyyMMddHHmmss"));
            Assert.AreEqual(compareValues[0].Created.ToString("yyyyMMddHHmmss"), 
                            sortedSorted[2].Created.ToString("yyyyMMddHHmmss"));
            Assert.AreEqual(compareValues[2].Created.ToString("yyyyMMddHHmmss"), 
                            sortedSorted[3].Created.ToString("yyyyMMddHHmmss"));
        }

        protected void ValidateSortListCategoryAscTest(List<BucketListItem> compareValues, List<BucketListItem> sortedSorted)
        {
            Assert.AreEqual(compareValues[1].Category, sortedSorted[0].Category);
            Assert.AreEqual(compareValues[3].Category, sortedSorted[1].Category);
            Assert.AreEqual(compareValues[2].Category, sortedSorted[2].Category);
            Assert.AreEqual(compareValues[0].Category, sortedSorted[3].Category);
        }

        protected void ValidateSortListCategoryDescTest(List<BucketListItem> compareValues, List<BucketListItem> sortedSorted, bool isLinqSort)
        {
            // HACK: Handle that linq sort handles multiple characters and other sorts only do one character
            if (isLinqSort)
            {
                Assert.AreEqual(compareValues[0].Category, sortedSorted[0].Category);
                Assert.AreEqual(compareValues[2].Category, sortedSorted[1].Category);
                Assert.AreEqual(compareValues[3].Category, sortedSorted[2].Category);
                Assert.AreEqual(compareValues[1].Category, sortedSorted[3].Category);
            }
            else
            {
                Assert.AreEqual(compareValues[0].Category, sortedSorted[0].Category);
                Assert.AreEqual(compareValues[2].Category, sortedSorted[1].Category);
                Assert.AreEqual(compareValues[1].Category, sortedSorted[2].Category);
                Assert.AreEqual(compareValues[3].Category, sortedSorted[3].Category);
            }
        }

        protected void ValidateSortAchievedAscTest(List<BucketListItem> sortedSorted)
        {
            Assert.AreEqual(false, sortedSorted[0].Achieved);
            Assert.AreEqual(false, sortedSorted[1].Achieved);
            Assert.AreEqual(true, sortedSorted[2].Achieved);
            Assert.AreEqual(true, sortedSorted[3].Achieved);
        }

        protected void ValidateSortAchievedDescTest(List<BucketListItem> sortedSorted)
        {
            Assert.AreEqual(true, sortedSorted[0].Achieved);
            Assert.AreEqual(true, sortedSorted[1].Achieved);
            Assert.AreEqual(false, sortedSorted[2].Achieved);
            Assert.AreEqual(false, sortedSorted[3].Achieved);
        }

        protected List<BucketListItem> RunSortTest(List<BucketListItem> values, Enums.SortColumns sortColumn, bool desc, ISort sortAlgorithm)
        {
            var sortedList = sortAlgorithm.Sort(values, sortColumn, desc);

            return sortedList;
        }

        protected List<BucketListItem> GetNameValues()
        {
            var values = new List<BucketListItem>();

            values.Add(new BucketListItem() { Name = "ZBucketListItem" });
            values.Add(new BucketListItem() { Name = "yBucketListItem" });
            values.Add(new BucketListItem() { Name = "ABucketListItem" });
            values.Add(new BucketListItem() { Name = "tBucketListItem" });

            return values;
        }

        protected List<BucketListItem> GetCreatedValues()
        {
            var values = new List<BucketListItem>();

            values.Add(new BucketListItem() { Created = DateTime.UtcNow.AddDays(-3) });
            values.Add(new BucketListItem() { Created = DateTime.UtcNow.AddDays(-1) });
            values.Add(new BucketListItem() { Created = DateTime.UtcNow.AddDays(-10) });
            values.Add(new BucketListItem() { Created = DateTime.UtcNow.AddDays(-2) });

            return values;
        }

        protected List<BucketListItem> GetCategoryValues()
        {
            var values = new List<BucketListItem>();

            values.Add(new BucketListItem() { Category = Enums.BucketListItemTypes.Warm.ToString() });
            values.Add(new BucketListItem() { Category = Enums.BucketListItemTypes.Cold.ToString() });
            values.Add(new BucketListItem() { Category = Enums.BucketListItemTypes.Hot.ToString() });
            values.Add(new BucketListItem() { Category = Enums.BucketListItemTypes.Cool.ToString() });

            return values;
        }

        protected List<BucketListItem> GetAchievedValues()
        {
            var values = new List<BucketListItem>();

            values.Add(new BucketListItem() { Achieved = false });
            values.Add(new BucketListItem() { Achieved = true });
            values.Add(new BucketListItem() { Achieved = false });
            values.Add(new BucketListItem() { Achieved = true });

            return values;
        }
    }
}
