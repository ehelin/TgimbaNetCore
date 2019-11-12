using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shared;
using Shared.dto;

namespace TestAPINetCore_Unit
{
    [TestClass]
    public class UserTests : BaseTest
    {
        #region ProcessUser(args)

        [DataTestMethod]
        [DataRow(true)]         // token is returned by generator helper
        [DataRow(false)]        // token is not returned by generator helper (only covers null...not empty string)
        public void ProcessUser_HappyPathTest(bool tokenIsGenerated)
        {
            var encodedUserName = "base64=>userName";
            var encodedPassword = "base64=>password";
            var decodedUserNameToReturn = "userName";
            var decodedPasswordToReturn = "password";       
            var salt = "IAmAReallyLongSaltValueToComplicateAPassword";
            var hashedUserPassword = "0W32zG7AdYwR1e3pgZbupRZjvuXOmNhOJcY/B8rm77L23knzTsDD4EeZS6ll5UjbMJUzTmrLNEJmnC07/jCthA2XVBBre1C3LYEo2dhi0s2f4CAWYMW9YT9tC8rcfpyp5FWSH2DAe/kdD3h/qXrrA8utTRD54au09a1heocVCdrZJdwkDXHMnGtLj40nRs8dnGRpKB1Xe9fuDmWLfWSdjRiSr/lWG+v1fMk+LYq51GF44RYL6QofcebRVolAetAkOabFGvLzaUuo5p77RXehNRHUWbT01pFZWrzEYAksNCBFqaXsbUxK488J+/o9MF3XySKBAPoHz/tG6w==";
            var jwtIssuerToReturn = "jwtIssuer";
            var jwtPrivateKeyToReturn = "jwtPrivateKey";
            var jwtTokenToReturn = "IAmAJwtToken";
            var userToReturn = GetUser(1, decodedUserNameToReturn, hashedUserPassword, salt);
            var hashPasswordDtoToReturn = new Password(decodedPasswordToReturn, userToReturn.Salt);
            hashPasswordDtoToReturn.SaltedHashedPassword = hashedUserPassword;

            ProcessUser_HappyPathTest_SetUps(encodedUserName, encodedPassword, decodedUserNameToReturn,
                                              decodedPasswordToReturn, userToReturn, jwtPrivateKeyToReturn, 
                                              jwtIssuerToReturn, hashPasswordDtoToReturn, jwtTokenToReturn,
                                              tokenIsGenerated);

            var token = this.service.ProcessUser(encodedUserName, encodedPassword);
           
            this.mockPassword.Verify(x => x.HashPassword(
                                        It.Is<Password>(s => s.GetPassword() == decodedPasswordToReturn ))
                                        , Times.Once);

            ProcessUser_HappyPathTest_Asserts(token, encodedUserName, encodedPassword, decodedUserNameToReturn,
                                               decodedPasswordToReturn, jwtPrivateKeyToReturn, jwtIssuerToReturn,
                                                userToReturn, tokenIsGenerated);
        }

        [TestMethod]
        public void ProcessUser_UserIsNull()
        {
            var encodedUserName = "base64=>userName";
            var encodedPassword = "base64=>password";
            var decodedUserNameToReturn = "userName";

            this.mockString.Setup(x => x.DecodeBase64String
                     (It.Is<string>(s => s == encodedUserName)))
                         .Returns(decodedUserNameToReturn);

            var token = this.service.ProcessUser(encodedUserName, encodedPassword);

            Assert.IsTrue(token == "");
            this.mockString.Verify(x => x.DecodeBase64String
                                                   (It.Is<string>(s => s == encodedUserName))
                                                       , Times.Once);
            this.mockString.Verify(x => x.DecodeBase64String
                                                    (It.Is<string>(s => s == encodedPassword))
                                                        , Times.Once);
            this.mockBucketListData.Verify(x => x.GetUser
                                                    (It.IsAny<string>())
                                                        , Times.Once);
        }
        
        [TestMethod]
        public void ProcessUser_PasswordsDoNotMatch()
        {
            var encodedUserName = "base64=>userName";
            var encodedPassword = "base64=>password";
            var decodedUserNameToReturn = "userName";
            var decodedPasswordToReturn = "password";
            var userToReturn = GetUser(1, decodedUserNameToReturn, decodedPasswordToReturn);
            var passwordDtoToReturn = new Password(decodedPasswordToReturn, userToReturn.Salt);

            this.mockString.Setup(x => x.DecodeBase64String
             (It.Is<string>(s => s == encodedUserName)))
                 .Returns(decodedUserNameToReturn);
            this.mockString.Setup(x => x.DecodeBase64String
                        (It.Is<string>(s => s == encodedPassword)))
                            .Returns(decodedPasswordToReturn);
            this.mockBucketListData.Setup(x => x.GetUser
                        (It.Is<string>(s => s == decodedUserNameToReturn)))
                            .Returns(userToReturn);
            this.mockPassword.Setup(x => x.PasswordsMatch(It.IsAny<Password>(),
                                                                It.IsAny<User>()))
                                                                     .Returns(false);

            var token = this.service.ProcessUser(encodedUserName, encodedPassword);

            Assert.IsTrue(token == "");
            this.mockString.Verify(x => x.DecodeBase64String
                                                   (It.Is<string>(s => s == encodedUserName))
                                                       , Times.Once);
            this.mockString.Verify(x => x.DecodeBase64String
                                                    (It.Is<string>(s => s == encodedPassword))
                                                        , Times.Once);
            this.mockBucketListData.Verify(x => x.GetUser
                                                    (It.IsAny<string>())
                                                        , Times.Once);
            this.mockBucketListData.Setup(x => x.GetUser
                        (It.Is<string>(s => s == decodedUserNameToReturn)))
                            .Returns(userToReturn);

        }

        private void ProcessUser_HappyPathTest_SetUps
        (
            string encodedUserName,
            string encodedPassword,
            string decodedUserNameToReturn,
            string decodedPasswordToReturn,
            User userToReturn,
            string jwtPrivateKeyToReturn,
            string jwtIssuerToReturn,
            Password hashPasswordDtoToReturn, 
            string jwtTokenToReturn, 
            bool tokenIsGenerated
        ) 
        {
            this.mockString.Setup(x => x.DecodeBase64String
                         (It.Is<string>(s => s == encodedUserName)))
                             .Returns(decodedUserNameToReturn);
            this.mockString.Setup(x => x.DecodeBase64String
                        (It.Is<string>(s => s == encodedPassword)))
                            .Returns(decodedPasswordToReturn);
            this.mockBucketListData.Setup(x => x.GetUser
                        (It.Is<string>(s => s == decodedUserNameToReturn)))
                            .Returns(userToReturn);
            this.mockGenerator.Setup(x => x.GetJwtIssuer()).Returns(jwtIssuerToReturn);
            this.mockGenerator.Setup(x => x.GetJwtPrivateKey()).Returns(jwtPrivateKeyToReturn);
            this.mockGenerator.Setup(x => x.GetJwtToken(It.Is<string>(s => s == jwtPrivateKeyToReturn),
                                                               It.Is<string>(s => s == jwtIssuerToReturn)
                                                                , It.Is<int>(s => s == Constants.TOKEN_LIFE)))
                                                                    .Returns(tokenIsGenerated ? jwtTokenToReturn : null);
            this.mockPassword.Setup(x => x.PasswordsMatch
                        (It.Is<Password>(s => s.GetPassword() == decodedPasswordToReturn
                                                && s.Salt == userToReturn.Salt),
                                            It.Is<User>(s => s.UserName == decodedUserNameToReturn)))
                                                 .Returns(true);
            this.mockPassword.Setup(x => x.HashPassword(
                                        It.Is<Password>(s => s.GetPassword() == decodedPasswordToReturn)))
                                            .Returns(hashPasswordDtoToReturn);
        }

        private void ProcessUser_HappyPathTest_Asserts
        (
            string token, 
            string encodedUserName, 
            string encodedPassword,
            string decodedUserNameToReturn,
            string decodedPasswordToReturn,
            string jwtPrivateKeyToReturn,
            string jwtIssuerToReturn,
            User user, 
            bool tokenIsGenerated
        ) {
            this.mockString.Verify(x => x.DecodeBase64String
                        (It.Is<string>(s => s == encodedUserName))
                            , Times.Once);
            this.mockString.Verify(x => x.DecodeBase64String
                        (It.Is<string>(s => s == encodedPassword))
                            , Times.Once);
            this.mockBucketListData.Verify(x => x.GetUser
                        (It.Is<string>(s => s == decodedUserNameToReturn))
                            , Times.Once);

            this.mockPassword.Verify(x => x.PasswordsMatch(It.Is<Password>(s => s.GetPassword() == decodedPasswordToReturn
                                                            && s.Salt == user.Salt),
                                                                It.Is<User>(s => s.UserName == decodedUserNameToReturn)), 
                                                                    Times.Once);

            this.mockGenerator.Verify(x => x.GetJwtPrivateKey(), Times.Once);
            this.mockGenerator.Verify(x => x.GetJwtIssuer(), Times.Once);
            this.mockGenerator.Verify(x => x.GetJwtToken(
                                        It.Is<string>(s => s == jwtPrivateKeyToReturn),
                                            It.Is<string>(s => s == jwtIssuerToReturn)
                                             , It.Is<int>(s => s == Constants.TOKEN_LIFE))
                                                , Times.Once);

            if (tokenIsGenerated)
            {
                Assert.IsNotNull(token);
                Assert.IsTrue(token.Length > 0);
                this.mockBucketListData.Verify(x => x.AddToken(It.Is<int>(s => s == user.UserId),
                                                            It.Is<string>(s => s == token))
                                                            , Times.Once);
            } else
            {
                Assert.IsNull(token);
                this.mockBucketListData.Verify(x => x.AddToken(It.Is<int>(s => s == user.UserId),
                                                                It.Is<string>(s => s == token))
                                                                , Times.Never);
            }
        }

        #endregion

        #region ProcessUserRegistration(args)

        [TestMethod]
        public void ProcessUserRegistration_HappyPathTest()
        {
            var encodedUserName = "base64=>userName";
            var encodedPassword = "base64=>password";
            var encodedEmail = "base64=>email";

            var decodedUserNameToReturn = "userName";
            var decodedPasswordToReturn = "password";
            var decodedEmailToReturn = "email";
            var saltToReturn = "IAmAUserAssignedSaltValue";
            var saltedPasswordToReturn = "IAmASaltedUserPassword";
            var userIdToReturn = 1;

            ProcessUserRegistration_SetUps(encodedUserName, encodedPassword, encodedEmail,
                                                        decodedUserNameToReturn, decodedPasswordToReturn,
                                                        decodedEmailToReturn, saltToReturn, 
                                                        saltedPasswordToReturn, userIdToReturn);

            var userRegistered = this.service.ProcessUserRegistration(encodedUserName, encodedEmail, encodedPassword);

            Assert.IsTrue(userRegistered);

            ProcessUserRegistration_Asserts(encodedUserName, encodedPassword, encodedEmail,
                                                        decodedUserNameToReturn, decodedPasswordToReturn,
                                                        decodedEmailToReturn, saltToReturn, saltedPasswordToReturn);
        }

        [TestMethod]
        public void ProcessUserRegistration_NotValidUserRegistration()
        {
            var userRegistered = this.service.ProcessUserRegistration(null, null, null);

            Assert.IsFalse(userRegistered);
            
            this.mockPassword.Verify(x => x.IsValidUserToRegister
                        (It.Is<string>(s => s == null),
                            It.Is<string>(s => s == null),
                                It.Is<string>(s => s == null))
                                    , Times.Once);

            this.mockPassword.Verify(x => x.GetSalt(It.IsAny<int>()), Times.Never);
            this.mockPassword.Verify(x => x.HashPassword(It.IsAny<Password>()) , Times.Never);
            this.mockBucketListData.Verify(x => x.AddUser(It.IsAny<User>()), Times.Never);
        }

        [TestMethod]
        public void ProcessUserRegistration_UserNotAdded()
        {
            var encodedUserName = "base64=>userName";
            var encodedPassword = "base64=>password";
            var encodedEmail = "base64=>email";

            var decodedUserNameToReturn = "userName";
            var decodedPasswordToReturn = "password";
            var decodedEmailToReturn = "email";
            var saltToReturn = "IAmAUserAssignedSaltValue";
            var saltedPasswordToReturn = "IAmASaltedUserPassword";
            var userIdToReturn = 0;

            ProcessUserRegistration_SetUps(encodedUserName, encodedPassword, encodedEmail,
                                                        decodedUserNameToReturn, decodedPasswordToReturn,
                                                        decodedEmailToReturn, saltToReturn, 
                                                        saltedPasswordToReturn, userIdToReturn);

            var userRegistered = this.service.ProcessUserRegistration(encodedUserName, encodedEmail, encodedPassword);

            Assert.IsFalse(userRegistered);

            ProcessUserRegistration_Asserts(encodedUserName, encodedPassword, encodedEmail,
                                                        decodedUserNameToReturn, decodedPasswordToReturn,
                                                        decodedEmailToReturn, saltToReturn, saltedPasswordToReturn);
        }

        private void ProcessUserRegistration_SetUps
        (
            string encodedUserName,
            string encodedPassword,
            string encodedEmail,
            string decodedUserNameToReturn,
            string decodedPasswordToReturn,
            string decodedEmailToReturn,
            string saltToReturn,
            string saltedPasswordToReturn,
            int userIdToReturn
        ) {
            this.mockString.Setup(x => x.DecodeBase64String
                         (It.Is<string>(s => s == encodedUserName)))
                             .Returns(decodedUserNameToReturn);
            this.mockString.Setup(x => x.DecodeBase64String
                        (It.Is<string>(s => s == encodedPassword)))
                            .Returns(decodedPasswordToReturn);
            this.mockString.Setup(x => x.DecodeBase64String
                        (It.Is<string>(s => s == encodedEmail)))
                            .Returns(decodedEmailToReturn);

            this.mockPassword.Setup(x => x.IsValidUserToRegister
                        (It.Is<string>(s => s == decodedUserNameToReturn),
                        It.Is<string>(s => s == decodedEmailToReturn),
                        It.Is<string>(s => s == decodedPasswordToReturn)))
                            .Returns(true);
            
            var p = new Password(decodedPasswordToReturn, saltToReturn);
            p.SaltedHashedPassword = saltedPasswordToReturn;
            this.mockPassword.Setup(x => x.GetSalt(Constants.SALT_SIZE))
                                            .Returns(saltToReturn);
            this.mockPassword.Setup(x => x.HashPassword
                                        (It.Is<Password>(s => s.GetPassword() == decodedPasswordToReturn
                                            && s.Salt == saltToReturn)))
                                            .Returns(p);

            this.mockBucketListData.Setup(x => x.AddUser(It.Is<User>
                                            (s => s.Password == saltedPasswordToReturn
                                                && s.UserName == decodedUserNameToReturn
                                                    && s.Email == decodedEmailToReturn)))
                                                        .Returns(userIdToReturn);
        }

        private void ProcessUserRegistration_Asserts
        (
            string encodedUserName,
            string encodedPassword,
            string encodedEmail,
            string decodedUserNameToReturn,
            string decodedPasswordToReturn,
            string decodedEmailToReturn,
            string saltToReturn,
            string saltedPasswordToReturn
        ) {           
            this.mockString.Verify(x => x.DecodeBase64String
                        (It.Is<string>(s => s == encodedUserName))
                            , Times.Once);
            this.mockString.Verify(x => x.DecodeBase64String
                        (It.Is<string>(s => s == encodedEmail))
                            , Times.Once);
            this.mockString.Verify(x => x.DecodeBase64String
                        (It.Is<string>(s => s == encodedPassword))
                            , Times.Once);

            this.mockPassword.Verify(x => x.IsValidUserToRegister
                        (It.Is<string>(s => s == decodedUserNameToReturn),
                            It.Is<string>(s => s == decodedEmailToReturn),
                                It.Is<string>(s => s == decodedPasswordToReturn))
                                    , Times.Once);

            this.mockPassword.Verify(x => x.GetSalt
                                        (It.Is<int>(s => s == Constants.SALT_SIZE))
                                            , Times.Once);
            this.mockPassword.Verify(x => x.HashPassword
                                        (It.Is<Password>(s => s.GetPassword() == decodedPasswordToReturn
                                            && s.Salt == saltToReturn))
                                                , Times.Once);

            this.mockBucketListData.Verify(x => x.AddUser(It.Is<User>
                                            (s => s.Password == saltedPasswordToReturn
                                                && s.UserName == decodedUserNameToReturn
                                                    && s.Email == decodedEmailToReturn))
                                                        , Times.Once);
        }

        #endregion
    }
}
