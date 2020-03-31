using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class BinarySearchTests
    {
        #region prototype tests

        [TestMethod]
        public void BinarySearchPrototypeTest()
        {
            var cheatSheet = new Algorithms.Algorithms.AlgorithmCheatSheet(true);
            cheatSheet.RunBinarySearchSentencesSingleSearchTermPrototype();
        }

        #endregion
        
        #region name tests

        [TestMethod]
        public void BinarySearchNameTest()
        {
            ISearch sut = new BinarySearch();
            var bucketListItems = new List<BucketListItem>();
            var searchTerm = "of";
            var expectedMatchCount = 3;

            bucketListItems.Add(new BucketListItem() { Name = "paris - see nortre dame cathedral" });
            bucketListItems.Add(new BucketListItem() { Name = "get picture on ledge in Trolltunga Norway" });
            bucketListItems.Add(new BucketListItem() { Name = "Plitvice Lakes National Park  Croatia" });
            bucketListItems.Add(new BucketListItem() { Name = "see alex Lang Fingles Cave on the island of Staffa...of the west coast of scotland." });
            bucketListItems.Add(new BucketListItem() { Name = "The Great Pyramid of Cholula" });
            bucketListItems.Add(new BucketListItem() { Name = "visit all big famous cities" });
            bucketListItems.Add(new BucketListItem() { Name = "ireland->aran - chain of islands south part ireland(ring of cari)" });
            bucketListItems.Add(new BucketListItem() { Name = "eat at Jiros sushi bar in tokoyo(needs year reservation)" });

            var searchResults = sut.Search(bucketListItems, searchTerm);

            Assert.IsNotNull(searchResults);
            Assert.AreEqual(expectedMatchCount, searchResults.Count);

            var ctr = 0;
            foreach(var bucketListItem in bucketListItems)
            {
                // TODO - stream line these checks
                if (bucketListItem.Name == "see alex Lang Fingles Cave on the island of Staffa...of the west coast of scotland."
                        || bucketListItem.Name == "The Great Pyramid of Cholula"
                            || bucketListItem.Name == "ireland->aran - chain of islands south part ireland(ring of cari)")
                {
                    ctr++;
                }
            }

            Assert.AreEqual(expectedMatchCount, ctr);
        }

        #endregion
    }
}
