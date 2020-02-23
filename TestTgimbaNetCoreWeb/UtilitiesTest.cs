using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.misc;
using SharedWeb = TgimbaNetCoreWebShared;

namespace TestTgimbaNetCoreWeb
{
    [TestClass]
    public class UtilitiesTest : BaseTest
    {
        [TestMethod]
        public void Test_IsMobileTrue()
        {
            Assert.IsTrue(SharedWeb.Utilities.IsMobile("Mozilla/5.0 (Linux; U; Android 4.4.2; en-us; SCH-I535 Build/KOT49H) AppleWebKit/534.30 (KHTML, like Gecko) Version/4.0 Mobile Safari/534.30"));
        }

        [TestMethod]
        public void Test_IsMobileFalse()
        {
            Assert.IsFalse(SharedWeb.Utilities.IsMobile("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.135 Safari/537.36 Edge/12.246"));
        }

        [TestMethod]
        public void Test_GetAvailableSortingAlgorithms()
        {
            var availableSortingAlgorithms = SharedWeb.Utilities.GetAvailableSortingAlgorithms();
            var expectedEnumValues = Enum.GetNames(typeof(Enums.SortAlgorithms));

            Assert.AreEqual(expectedEnumValues.Length, availableSortingAlgorithms.Length);
            foreach(var availableSortingAlgorithm in availableSortingAlgorithms)
            {
                Assert.IsTrue(Array.IndexOf(expectedEnumValues, availableSortingAlgorithm) != -1);
            }
         }

        [TestMethod]
        public void Test_GetAvailableSearchingAlgorithms()
        {
            var availableSearchingAlgorithms = SharedWeb.Utilities.GetAvailableSearchingAlgorithms();
            var expectedEnumValues = Enum.GetNames(typeof(Enums.SearchAlgorithms));

            Assert.AreEqual(expectedEnumValues.Length, availableSearchingAlgorithms.Length);
            foreach (var availableSearchingAlgorithm in availableSearchingAlgorithms)
            {
                Assert.IsTrue(Array.IndexOf(expectedEnumValues, availableSearchingAlgorithm) != -1);
            }
        }

        [TestMethod]
        public void Test_ConvertModelToStringArray()
        {
            var bucketListItemString = GetBucketListItemSingleString("base64EncodedGoodUser", "testBucketLIstItem", null, true);
            var bucketListItemModel = GetBucketListItemModel("base64EncodedGoodUser", "testBucketLIstItem", null, true);

            var convertedBucketListItem = SharedWeb.Utilities.ConvertModelToString(bucketListItemModel);

            Assert.AreEqual(bucketListItemString, convertedBucketListItem);
        }


        [TestMethod]
        public void Test_ConvertCategoryHotToEnum()
        {
            var enumValue = SharedWeb.Utilities.ConvertCategoryToEnum("Hot");

            Assert.AreEqual(Enums.BucketListItemTypes.Hot, enumValue);
        }

        [TestMethod]
        public void Test_ConvertCategoryWarmToEnum()
        {
            var enumValue = SharedWeb.Utilities.ConvertCategoryToEnum("Warm");

            Assert.AreEqual(Enums.BucketListItemTypes.Warm, enumValue);
        }

        [TestMethod]
        public void Test_ConvertCategoryColdToEnum()
        {
            var enumValue = SharedWeb.Utilities.ConvertCategoryToEnum("Cool");

            Assert.AreEqual(Enums.BucketListItemTypes.Cool, enumValue);
        }

        [TestMethod]
        public void Test_ConvertCategoryBadInputToEnumThrowsException()
        {
            try
            {
                var enumValue = SharedWeb.Utilities.ConvertCategoryToEnum("UnrecognizedCategory");
                Assert.AreEqual(1, 2);    // Fail if this line executes
            }
            catch (Exception e)
            {
                Assert.IsNotNull(e);
                Assert.AreEqual("Unknown category: UnrecognizedCategory", e.Message);
            }
        }
    }
}
