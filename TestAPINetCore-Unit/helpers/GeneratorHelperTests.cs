using BLLNetCore.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.interfaces;

namespace TestAPINetCore_Unit.helpers
{
    [TestClass]
    public class GeneratorHelperTests : BaseTest
    {
        private IGenerator sut = null;

        public GeneratorHelperTests() {
            sut = new GeneratorHelper();
        }

        [TestMethod]
        public void GetPrivateKey_HappyPathTest()
        {
            var key = sut.GetPrivateKey();
            Assert.IsNotNull(key);
            Assert.IsTrue(key.Length > 0);
        }
    }
}
