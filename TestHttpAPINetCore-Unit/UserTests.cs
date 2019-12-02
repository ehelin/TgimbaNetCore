using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shared.dto.api;

namespace TestHttpAPINetCore_Unit
{
    [TestClass]
    public class UserTests : BaseTest
    {
        #region Process User

        [TestMethod]
        public void ProcessUser_HappyPathTest()
        {
            var request = GetLoginRequest();
            var tokenToReturn = "token";
            tgimbaService.Setup(x => x.ProcessUser
                                    (It.Is<string>(s => s == request.EncodedUserName),
                                      It.Is<string>(s => s == request.EncodedPassword)
                                        )).Returns(tokenToReturn);

            IActionResult result = tgimbaApi.ProcessUser(request);
            OkObjectResult requestResult = (OkObjectResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(200, requestResult.StatusCode);
            tgimbaService.Verify(x => x.ProcessUser
                                        (It.Is<string>(s => s == request.EncodedUserName),
                                            It.Is<string>(s => s == request.EncodedPassword)
                                                ), Times.Once);
            var token = (string)requestResult.Value;
            Assert.AreEqual(tokenToReturn, token);
        }

        [TestMethod]
        public void ProcessUser_ValidationErrorTest()
        {
            var request = GetLoginRequest();

            validationHelper.Setup(x => x.IsValidRequest
                                    (It.IsAny<LoginRequest>()))
                                        .Throws(new ArgumentNullException(""));

            IActionResult result = tgimbaApi.ProcessUser(request);
            BadResultVerify(result);
            tgimbaService.Verify(x => x.ProcessUser(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public void ProcessUser_GeneralErrorTest()
        {
            var request = GetLoginRequest();

            tgimbaService.Setup(x => x.ProcessUser
                                (It.IsAny<string>(), It.IsAny<string>()))
                                     .Throws(new Exception("I am an exception"));

            IActionResult result = tgimbaApi.ProcessUser(request);
            BadResultVerify(result, 500);
        }

        #endregion

        #region Process User Registration

        [TestMethod]
        public void ProcessUserRegistration_HappyPathTest()
        {
            var email = "email";
            var userRegisteredToReturn = true;
            var registration = new RegistrationRequest() { Login = GetLoginRequest(), EncodedEmail = email };
            tgimbaService.Setup(x => x.ProcessUserRegistration
                                        (It.Is<string>(s => s == registration.Login.EncodedUserName),
                                            It.Is<string>(s => s == email),
                                                It.Is<string>(s => s == registration.Login.EncodedPassword)
                                                    )).Returns(userRegisteredToReturn);

            IActionResult result = tgimbaApi.ProcessUserRegistration(registration);
            OkObjectResult requestResult = (OkObjectResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(200, requestResult.StatusCode);
            tgimbaService.Verify(x => x.ProcessUserRegistration
                                        (It.Is<string>(s => s == registration.Login.EncodedUserName),
                                            It.Is<string>(s => s == email),
                                                It.Is<string>(s => s == registration.Login.EncodedPassword)
                                                    ), Times.Once);
            var userRegistered = (bool)requestResult.Value;
            Assert.AreEqual(userRegisteredToReturn, userRegistered);
        }

        [TestMethod]
        public void ProcessUserRegistration_ErrorTest()
        {
            var registration = new RegistrationRequest() { Login = GetLoginRequest(), EncodedEmail = "email" };

            validationHelper.Setup(x => x.IsValidRequest
                                    (It.IsAny<RegistrationRequest>()))
                                        .Throws(new ArgumentNullException(""));

            IActionResult result = tgimbaApi.ProcessUserRegistration(registration);
            BadResultVerify(result);
            tgimbaService.Verify(x => x.ProcessUserRegistration(It.IsAny<string>(), It.IsAny<string>()
                                                                    , It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public void ProcessUserRegistration_GeneralErrorTest()
        {
            var request = new RegistrationRequest() { Login = GetLoginRequest(), EncodedEmail = "email" };

            tgimbaService.Setup(x => x.ProcessUserRegistration
                                    (It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                                        .Throws(new Exception("I am an exception"));

            IActionResult result = tgimbaApi.ProcessUserRegistration(request);
            BadResultVerify(result, 500);
        }

        #endregion
    }
}
