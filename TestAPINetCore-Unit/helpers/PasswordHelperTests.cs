using System;
using BLLNetCore.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shared;
using Shared.dto;
using Shared.interfaces;

namespace TestAPINetCore_Unit.helpers
{
    [TestClass]
    public class PasswordHelperTests : BaseTest
    {
        private IPassword sut = null;

        public PasswordHelperTests() {
            sut = new PasswordHelper();
        }

        #region Passwords match

        [TestMethod]
        public void PasswordsMatch_True()
        {
            var existingUserPassword = "IAmAnExistingUserPassword";
            var existingUserSalt = "IAmAnExistingUserSalt";
            var existingPasswordDto = new Password(existingUserPassword, existingUserSalt);
            var hashedExistingUserSaltedPassword = sut.HashPassword(existingPasswordDto);

            var loginPassword = "IAmAnExistingUserPassword";
            var loginPasswordDto = new Password(loginPassword, existingUserSalt);
            var hashedLoginUserSaltedPassword = sut.HashPassword(loginPasswordDto);

            var user = new User();
            user.Password = hashedExistingUserSaltedPassword.SaltedHashedPassword;
            user.Salt = existingUserSalt;

            var passwordsMatch = sut.PasswordsMatch(hashedLoginUserSaltedPassword, user);

            Assert.IsTrue(passwordsMatch);
        }

        [TestMethod]
        public void PasswordsMatch_False()
        {
            var existingUserPassword = "IAmAnExistingUserPassword";
            var existingUserSalt = "IAmAnExistingUserSalt";
            var existingPasswordDto = new Password(existingUserPassword, existingUserSalt);
            var hashedExistingUserSaltedPassword = sut.HashPassword(existingPasswordDto);

            var loginPassword = "IAmAnExistingUserPasswordThatIsDifferent";
            var loginPasswordDto = new Password(loginPassword, existingUserSalt);
            var hashedLoginUserSaltedPassword = sut.HashPassword(loginPasswordDto);

            var user = new User();
            user.Password = hashedExistingUserSaltedPassword.SaltedHashedPassword;
            user.Salt = existingUserSalt;

            var passwordsMatch = sut.PasswordsMatch(hashedLoginUserSaltedPassword, user);

            Assert.IsFalse(passwordsMatch);
        }

        #endregion
        
        #region Salt

        [DataTestMethod]
        [DataRow(Constants.SALT_SIZE, false)]
        [DataRow(18, false)]
        [DataRow(64, false)]
        [DataRow(128, false)]
        [DataRow(2, true)]
        public void GetSalt_MultipleTests(int size, bool expectError)
        {
            if (expectError) 
            {
                try 
                {
                    var result = sut.GetSalt(size);

                    Assert.Fail("Exception not thrown");
                } 
                catch (Exception ex)
                {
                    Assert.IsNotNull(ex);
                    Assert.IsTrue(ex.Message.Length > 0);
                }
            } 
            else
            {
                var result = sut.GetSalt(size);

                Assert.IsNotNull(result);
                Assert.IsTrue(result.Length > 0);
            }
        }

        #endregion

        #region HashPassword

        [TestMethod]
        public void HashPassword_HappyPathTest()
        {
            var password = "IAmAPassword";
            var salt = "IAmAComplicatedSaltThatIsAtLeastEightBytesLong";
            var passwordDto = new Password(password, salt);
            var updatedPasswordDto = sut.HashPassword(passwordDto);
            Assert.IsNotNull(updatedPasswordDto.SaltedHashedPassword);
            Assert.IsTrue(updatedPasswordDto.SaltedHashedPassword.Length>0);
        }

        #endregion

        #region Contains a number

        [TestMethod]
        public void ContainsOneNumber_ValueContainsANumber()
        {
            var password = "IAmAPassword9";
            var passwordContainsANumber = sut.ContainsOneNumber(password);
            Assert.IsTrue(passwordContainsANumber);
        }

        [TestMethod]
        public void ContainsOneNumber_ValueDoesNotContainsANumber()
        {
            var password = "IAmAPassword";
            var passwordContainsANumber = sut.ContainsOneNumber(password);
            Assert.IsFalse(passwordContainsANumber);
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

        #region IsValidToken

        [TestMethod]
        public void IsValidToken_True()
        {
            var jwtToken = GetRealJwtToken();
            var user = GetUser();
            user.Token = jwtToken;

            var isValidToken = sut.IsValidToken(user, jwtToken);

            Assert.IsTrue(isValidToken);
        }

        [TestMethod]
        public void IsValidToken_Expired_False()
        {
            var jwtToken = GetRealJwtToken(-5);
            var user = GetUser();
            user.Token = jwtToken;

            var isValidToken = sut.IsValidToken(user, jwtToken);

            Assert.IsFalse(isValidToken);
        }

        [TestMethod]
        public void IsValidToken_NoToken_False()
        {
            string jwtToken = null;
            var user = GetUser();
            user.Token = jwtToken;

            var isValidToken = sut.IsValidToken(user, jwtToken);

            Assert.IsFalse(isValidToken);
        }

        [TestMethod]
        public void IsValidToken_NoUser_False()
        {
            string jwtToken = null;
            User user = null;

            var isValidToken = sut.IsValidToken(user, jwtToken);

            Assert.IsFalse(isValidToken);
        }

        [TestMethod]
        public void IsValidToken_UserTokenAndTokenDoNotMatch_False()
        {
            var jwtToken = GetRealJwtToken();
            var user = GetUser();

            var isValidToken = sut.IsValidToken(user, jwtToken);

            Assert.IsFalse(isValidToken);
        }

        #endregion
    }
}
