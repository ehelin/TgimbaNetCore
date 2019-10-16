using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shared.dto;
using Shared;

namespace TestAPINetCore_Unit
{
    [TestClass]
    public class UserTests : BaseTest
    {
        [TestMethod]
        public void ProcessUser_HappyPathTest()
        {
            var encodedUserName = "base64=>userName";
            var encodedPassword = "base64=>password";
            var decodedUserNameToReturn = "userName";
            var decodedPasswordToReturn = "password";            
            var jwtIssuerToReturn = "jwtIssuer";
            var jwtPrivateKeyToReturn = "jwtPrivateKey";
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
            this.mockGenerator.Setup(x => x.GetJwtIssuer()).Returns(jwtIssuerToReturn);
            this.mockGenerator.Setup(x => x.GetJwtPrivateKey()).Returns(jwtPrivateKeyToReturn);
            this.mockGenerator.Setup(x => x.GetJwtToken(It.Is<string>(s => s == jwtPrivateKeyToReturn),
                                                               It.Is<string>(s => s == jwtIssuerToReturn)))
                                                                    .Returns(jwtPrivateKeyToReturn);
            this.mockPassword.Setup(x => x.PasswordsMatch
                        (It.Is<Password>(s => s.GetPassword() == decodedPasswordToReturn
                                                && s.Salt == userToReturn.Salt),
                                            It.Is<User>(s => s.UserName == decodedUserNameToReturn)))
                                                 .Returns(true);

            var token = this.service.ProcessUser(encodedUserName, encodedPassword);

            Assert.IsNotNull(token);
            Assert.IsTrue(token.Length > 0);

            this.mockString.Verify(x => x.DecodeBase64String
                        (It.Is<string>(s => s == encodedUserName))
                            , Times.Once);
            this.mockString.Verify(x => x.DecodeBase64String
                        (It.Is<string>(s => s == encodedPassword))
                            , Times.Once);
            this.mockBucketListData.Verify(x => x.GetUser
                        (It.Is<string>(s => s == decodedUserNameToReturn))
                            , Times.Once);

            this.mockGenerator.Verify(x => x.GetJwtPrivateKey(), Times.Once);
            this.mockGenerator.Verify(x => x.GetJwtIssuer(), Times.Once);
            this.mockGenerator.Verify(x => x.GetJwtToken(
                                        It.Is<string>(s => s == jwtPrivateKeyToReturn),
                                            It.Is<string>(s => s == jwtIssuerToReturn))
                                             , Times.Once);
        }
    }
}
