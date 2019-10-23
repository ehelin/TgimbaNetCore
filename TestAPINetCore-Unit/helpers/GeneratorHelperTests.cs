using BLLNetCore.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shared.interfaces;

namespace TestAPINetCore_Unit.helpers
{
    [TestClass]
    public class GeneratorHelperTests : BaseTest
    {
        private IGenerator sut = null;

        public GeneratorHelperTests() {
            sut = new GeneratorHelper(this.mockPassword.Object);
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

        #endregion

        #region User Registration

        [DataTestMethod]
        [DataRow("userName", "email@email.com", "password123", true, true)]         //correct values
        [DataRow(null, "email@email.com", "password123", false, true)]              //user - null
        [DataRow("", "email@email.com", "password123", false, true)]                //user - empty string
        [DataRow("null", "email@email.com", "password123", false, true)]            //user - "null"
        [DataRow("user", "email@email.com", "pass", false, true)]                   //user- not long enough
        [DataRow("userName", null, "password123", false, true)]                     //email - null
        [DataRow("userName", "", "password123", false, true)]                       //email - empty string
        [DataRow("userName", "null", "password123", false, true)]                   //email - "null"
        [DataRow("userName", "emailnoatsigh", "password123", false, true)]
        [DataRow("userName", "email@email.com", null, false, true)]                 //password - null
        [DataRow("userName", "email@email.com", "", false, true)]                   //password- empty string
        [DataRow("userName", "email@email.com", "null", false, true)]               //password - "null"
        [DataRow("userName", "email@email.com", "password", false, false)]          //password - no number
        [DataRow("userName", "email@email.com", "pass", false, true)]               //password- not long enough
        public void IsValidUserToRegister_MultipleTests(string user, string email, 
                                                            string password, bool isValid, bool mock)
        {
            this.mockPassword.Setup(x => x.ContainsOneNumber
                                    (It.Is<string>(s => s == password)))
                                        .Returns(mock);

            var result = sut.IsValidUserToRegister(user, email, password);

            Assert.AreEqual(isValid, result);
        }

        #endregion
    }
}
