using System;
using BLLNetCore.helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.interfaces;
using Shared.misc;

namespace TestAPINetCore_Unit.helpers
{
    [TestClass]
    public class StringHelperTests : BaseTest
    {
        private IString sut = null;
        private string unencodedBase64String = "IAmAnUnBased64String";
        private string encodedBase64String = "SUFtQW5VbkJhc2VkNjRTdHJpbmc=";

        public StringHelperTests() {
            sut = new StringHelper();
        }

        #region DecodeBase64String

        [TestMethod]
        public void DecodeBase64String_HappyPathTest()
        {
            var result = sut.DecodeBase64String(encodedBase64String);
            Assert.IsNotNull(result);
            Assert.AreEqual(unencodedBase64String, result);
        }

        [TestMethod]
        public void DecodeBase64String_NullValue()
        {
            var result = sut.DecodeBase64String(null);
            Assert.IsNotNull(result);
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void DecodeBase64String_EmptyValue()
        {
            var result = sut.DecodeBase64String("");
            Assert.IsNotNull(result);
            Assert.AreEqual(string.Empty, result);
        }

        #endregion

        #region EncodeBase64String

        [TestMethod]
        public void EncodeBase64String_HappyPathTest()
        {
            var result = sut.EncodeBase64String(unencodedBase64String);
            Assert.IsNotNull(result);
            Assert.AreEqual(encodedBase64String, result);
        }

        [TestMethod]
        public void EncodeBase64String_NullValue()
        {
            var result = sut.EncodeBase64String(null);
            Assert.IsNotNull(result);
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void EncodeBase64String_EmptyValue()
        {
            var result = sut.EncodeBase64String("");
            Assert.IsNotNull(result);
            Assert.AreEqual(string.Empty, result);
        }

        #endregion

        #region HasSortOrderAsc

        [DataTestMethod]
        [DataRow("asc", true)]
        [DataRow("Asc", true)]
        [DataRow("ASC", true)]
        [DataRow(null, false)]
        [DataRow("", false)]
        [DataRow("desc", false)]
        [DataRow("Desc", false)]
        [DataRow("DESC", false)]
        public void HasSortOrderAsc_Tests(string sortString, bool isAsc)
        {
            var result = sut.HasSortOrderAsc(sortString);
            Assert.AreEqual(isAsc, result);
        }

        #endregion

        #region GetLowerCaseSortString

        [DataTestMethod]
        [DataRow("asc", "asc")]
        [DataRow("Asc", "asc")]
        [DataRow("ASC", "asc")]
        [DataRow(null, "")]
        [DataRow("", "")]
        [DataRow("desc", "desc")]
        [DataRow("Desc", "desc")]
        [DataRow("DESC", "desc")]
        public void GetLowerCaseSortString_Tests(string sortString, string expectedResult)
        {
            var result = sut.GetLowerCaseSortString(sortString);
            Assert.AreEqual(expectedResult, result);
        }

        #endregion

        #region GetSortColumn

        [DataTestMethod]
        [DataRow("LISTITEMNAME", Enums.SortColumns.ListItemName)]
        [DataRow("ListItemName", Enums.SortColumns.ListItemName)]
        [DataRow("listitemname", Enums.SortColumns.ListItemName)]
        [DataRow("CREATED", Enums.SortColumns.Created)]
        [DataRow("Created", Enums.SortColumns.Created)]
        [DataRow("created", Enums.SortColumns.Created)]
        [DataRow("CATEGORY", Enums.SortColumns.Category)]
        [DataRow("Category", Enums.SortColumns.Category)]
        [DataRow("category", Enums.SortColumns.Category)]
        [DataRow("ACHIEVED", Enums.SortColumns.Achieved)]
        [DataRow("Achieved", Enums.SortColumns.Achieved)]
        [DataRow("achieved", Enums.SortColumns.Achieved)]
        [DataRow(null, null)]
        [DataRow("IAmAnUnknownSortString", null)]
        public void GetSortColumn_Tests(string sortString, Enums.SortColumns? expectedResult)
        {
            try 
            {
                var result = sut.GetSortColumn(sortString);
                Assert.AreEqual(expectedResult.Value, result);
            } 
            catch (Exception ex)
            {
                if (expectedResult != null || !ex.Message.Contains("Unknown sort string"))
                {
                    Assert.IsTrue(false); //expected result to be null and an error to be thrown
                }
            }
        }

        #endregion
    }
}
