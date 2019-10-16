using BLLNetCore.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.interfaces;
using BLLNetCore.helpers;

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

        [TestMethod]
        public void DecodeBase64String_HappyPathTest()
        {
            var result = sut.DecodeBase64String(encodedBase64String);
            Assert.IsNotNull(result);
            Assert.AreEqual(unencodedBase64String, result);
        }
        
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
    }
}
