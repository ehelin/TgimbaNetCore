using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms_Unit
{
    [TestClass]
    public class BinarySearchTests
    {
        #region name tests

        [TestMethod]
        public void BinarySearchTest()
        {
            var cheatSheet = new Algorithms.Algorithms.AlgorithmCheatSheet(true);
            cheatSheet.RunBinarySearchSentencesSingleSearchTermPrototype();
            ///throw new System.NotImplementedException();
            //var cheatSheet = new Algorithms.Algorithms.AlgorithmCheatSheet();
            //var test = 1;
            //ISearch sut = new BinarySearch();
            //var values = new List<BucketListItem>();

            //hvalues.Add(new BucketListItem() { Name = "ZBucketListItem" });
            //values.Add(new BucketListItem() { Name = "yBucketListItem" });
            //values.Add(new BucketListItem() { Name = "ABucketListItem" });
            //values.Add(new BucketListItem() { Name = "tBucketListItem" });

            //var searchResults = sut.Search(values, "yBucketListItem");

            //Assert.IsNotNull(searchResults);
            //Assert.AreEqual(1, searchResults.Count);
            //Assert.AreEqual("yBucketListItem", searchResults[0].Name);
        }

        #endregion
    }
}
