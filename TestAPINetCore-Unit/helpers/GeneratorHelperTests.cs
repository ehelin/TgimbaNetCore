using BLLNetCore.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shared;
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

        #region JWT 

        [TestMethod]
        public void GetJwtPrivateKey_HappyPathTest()
        {
            var jwtPrivateKey = sut.GetJwtPrivateKey();
            Assert.IsNotNull(jwtPrivateKey);
            Assert.IsTrue(jwtPrivateKey.Length > 0);
        }

        [TestMethod]
        public void GetJwtIssuer_HappyPathTest()
        {
            var jwtIssuer = sut.GetJwtIssuer();
            Assert.IsNotNull(jwtIssuer);
            Assert.IsTrue(jwtIssuer.Length > 0);
        }
               
        [TestMethod]
        public void GetJwtToken_HappyPathTest()
        {
            var jwtPrivateKey = "IAmAJwtPrivateKey";
            var jwtIssuer = "IAmAJwtIssuer";
            var jwtToken = sut.GetJwtToken(jwtPrivateKey, jwtIssuer);
            Assert.IsNotNull(jwtToken);
            Assert.IsTrue(jwtToken.Length > 0);
        }

        [TestMethod]
        public void DecryptJwtToken_HappyPathTest()
        {
            var jwtToken = GetRealJwtToken();
            var decodedJwtToken = sut.DecryptJwtToken(jwtToken);

            Assert.IsNotNull(decodedJwtToken);
            Assert.IsTrue(decodedJwtToken.Issuer == Credentials.GetJwtIssuer());
        }

        #endregion
    }
}
