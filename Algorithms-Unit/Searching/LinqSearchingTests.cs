using System;
using System.Collections.Generic;
using Algorithms.Algorithms.Sorting;
using Algorithms.Algorithms.Sorting.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.dto;
using Shared.misc;
using Algorithms.Algorithms.Search;
using Algorithms.Algorithms.Search.Implementations;

namespace Algorithms_Unit
{
    [TestClass]
    public class LinqSearchingTests
    {
        #region name tests

        [TestMethod]
        public void BubbleSortListNameAscTest()
        {
            ISearch sut = new LinqSearch();
            var values = new List<BucketListItem>();

            values.Add(new BucketListItem() { Name = "ZBucketListItem" });
            values.Add(new BucketListItem() { Name = "yBucketListItem" });
            values.Add(new BucketListItem() { Name = "ABucketListItem" });
            values.Add(new BucketListItem() { Name = "tBucketListItem" });

            var searchResults = sut.Search(values, "yBucketListItem");

            Assert.IsNotNull(searchResults);
            Assert.AreEqual(1, searchResults.Count);
            Assert.AreEqual("yBucketListItem", searchResults[0].Name);
        }

        #endregion
    }
}
