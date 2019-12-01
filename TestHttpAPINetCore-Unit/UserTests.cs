using HttpAPINetCore.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Shared.interfaces;
using Shared.dto;
using Shared.dto.api;
using System.Collections.Generic;
using Shared;

namespace TestHttpAPINetCore_Unit
{
    [TestClass]
    public class UserTests
    {
        #region Process User

        [TestMethod]
        public void ProcessUser_HappyPathTest()
        {
            var userName = "userName";
            var password = "password";
            var login = new LoginRequest() { EncodedUserName  = userName, EncodedPassword = password };
            var tokenToReturn = "token";
            var tgimbaService = new Mock<ITgimbaService>();
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);
            tgimbaService.Setup(x => x.ProcessUser
                                    (It.Is<string>(s => s == userName),
                                      It.Is<string>(s => s == password)
                                        )).Returns(tokenToReturn);

            IActionResult result = tgimbaApi.ProcessUser(login);
            OkObjectResult requestResult = (OkObjectResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(200, requestResult.StatusCode);
            tgimbaService.Verify(x => x.ProcessUser
                                        (It.Is<string>(s => s == userName),
                                            It.Is<string>(s => s == password)
                                                ), Times.Once);
            var token = (string)requestResult.Value;
            Assert.AreEqual(tokenToReturn, token);
        }

        [TestMethod]
        public void ProcessUser_NullUserName()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);
            var login = new LoginRequest() { EncodedUserName = null, EncodedPassword = "password" };
            
            validationHelper.Setup(x => x.IsValidRequest
                                    (It.IsAny<LoginRequest>()))
                                        .Throws(new ArgumentNullException(""));

            IActionResult result = tgimbaApi.ProcessUser(login);
            BadRequestResult requestResult = (BadRequestResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(400, requestResult.StatusCode);
            tgimbaService.Verify(x => x.ProcessUser(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            tgimbaService.Verify(x => x.Log(It.Is<string>(s => s.Contains("400 BadRequest"))), Times.Once);
        }

        [TestMethod]
        public void ProcessUser_EmptyUserName()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);

            var login = new LoginRequest() { EncodedUserName = "", EncodedPassword = "password" };

            validationHelper.Setup(x => x.IsValidRequest
                                    (It.IsAny<LoginRequest>()))
                                        .Throws(new ArgumentNullException(""));

            IActionResult result = tgimbaApi.ProcessUser(login);
            BadRequestResult requestResult = (BadRequestResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(400, requestResult.StatusCode);
            tgimbaService.Verify(x => x.ProcessUser(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            tgimbaService.Verify(x => x.Log(It.Is<string>(s => s.Contains("400 BadRequest"))), Times.Once);
        }

        [TestMethod]
        public void ProcessUser_NullPassword()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);

            var login = new LoginRequest() { EncodedUserName = "", EncodedPassword = "password" };

            validationHelper.Setup(x => x.IsValidRequest
                                    (It.IsAny<LoginRequest>()))
                                        .Throws(new ArgumentNullException(""));

            IActionResult result = tgimbaApi.ProcessUser(login);
            BadRequestResult requestResult = (BadRequestResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(400, requestResult.StatusCode);
            tgimbaService.Verify(x => x.ProcessUser(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            tgimbaService.Verify(x => x.Log(It.Is<string>(s => s.Contains("400 BadRequest"))), Times.Once);
        }

        [TestMethod]
        public void ProcessUser_EmptyPassword()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);

            var login = new LoginRequest() { EncodedUserName = "", EncodedPassword = "" };

            validationHelper.Setup(x => x.IsValidRequest
                                    (It.IsAny<LoginRequest>()))
                                        .Throws(new ArgumentNullException(""));

            IActionResult result = tgimbaApi.ProcessUser(login);
            BadRequestResult requestResult = (BadRequestResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(400, requestResult.StatusCode);
            tgimbaService.Verify(x => x.ProcessUser(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            tgimbaService.Verify(x => x.Log(It.Is<string>(s => s.Contains("400 BadRequest"))), Times.Once);
        }

        [TestMethod]
        public void ProcessUser_GeneralErrorTest()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);

            var login = new LoginRequest() { EncodedUserName = "", EncodedPassword = "password" };

            tgimbaService.Setup(x => x.ProcessUser
                                (It.IsAny<string>(), It.IsAny<string>()))
                                     .Throws(new Exception("I am an exception"));

            IActionResult result = tgimbaApi.ProcessUser(login);
            StatusCodeResult requestResult = (StatusCodeResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(500, requestResult.StatusCode);
            tgimbaService.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
        }

        #endregion

        #region Process User Registration

        [TestMethod]
        public void ProcessUserRegistration_HappyPathTest()
        {
            var userName = "userName";
            var email = "email";
            var password = "password";
            var userRegisteredToReturn = true;
            var tgimbaService = new Mock<ITgimbaService>();
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);
            var login = new LoginRequest() { EncodedUserName = userName, EncodedPassword = password };
            var registration = new RegistrationRequest() { Login = login, EncodedEmail = email };
            tgimbaService.Setup(x => x.ProcessUserRegistration
                                        (It.Is<string>(s => s == userName),
                                            It.Is<string>(s => s == email),
                                                It.Is<string>(s => s == password)
                                                    )).Returns(userRegisteredToReturn);

            IActionResult result = tgimbaApi.ProcessUserRegistration(registration);
            OkObjectResult requestResult = (OkObjectResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(200, requestResult.StatusCode);
            tgimbaService.Verify(x => x.ProcessUserRegistration
                                        (It.Is<string>(s => s == userName),
                                            It.Is<string>(s => s == email),
                                                It.Is<string>(s => s == password)
                                                    ), Times.Once);
            var userRegistered = (bool)requestResult.Value;
            Assert.AreEqual(userRegisteredToReturn, userRegistered);
        }

        [TestMethod]
        public void ProcessUserRegistration_NullUserName()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);
            var login = new LoginRequest() { EncodedUserName = null, EncodedPassword = "password" };
            var registration = new RegistrationRequest() { Login = login, EncodedEmail = "email" };

            validationHelper.Setup(x => x.IsValidRequest
                                    (It.IsAny<RegistrationRequest>()))
                                        .Throws(new ArgumentNullException(""));

            IActionResult result = tgimbaApi.ProcessUserRegistration(registration);
            BadRequestResult requestResult = (BadRequestResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(400, requestResult.StatusCode);
            tgimbaService.Verify(x => x.ProcessUserRegistration(It.IsAny<string>(), It.IsAny<string>()
                                                                    , It.IsAny<string>()), Times.Never);
            tgimbaService.Verify(x => x.Log(It.Is<string>(s => s.Contains("400 BadRequest"))), Times.Once);
        }

        [TestMethod]
        public void ProcessUserRegistration_EmptyUserName()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);

            var login = new LoginRequest() { EncodedUserName = "", EncodedPassword = "password" };

            validationHelper.Setup(x => x.IsValidRequest
                                    (It.IsAny<LoginRequest>()))
                                        .Throws(new ArgumentNullException(""));

            IActionResult result = tgimbaApi.ProcessUser(login);
            BadRequestResult requestResult = (BadRequestResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(400, requestResult.StatusCode);
            tgimbaService.Verify(x => x.ProcessUser(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            tgimbaService.Verify(x => x.Log(It.Is<string>(s => s.Contains("400 BadRequest"))), Times.Once);
        }

        [TestMethod]
        public void ProcessUserRegistration_NullEmail()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);
            var login = new LoginRequest() { EncodedUserName = "", EncodedPassword = "password" };
            var registration = new RegistrationRequest() { Login = login, EncodedEmail = null };
            
            validationHelper.Setup(x => x.IsValidRequest
                                    (It.IsAny<RegistrationRequest>()))
                                        .Throws(new ArgumentNullException(""));

            IActionResult result = tgimbaApi.ProcessUserRegistration(registration);
            BadRequestResult requestResult = (BadRequestResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(400, requestResult.StatusCode);
            tgimbaService.Verify(x => x.ProcessUserRegistration(It.IsAny<string>(), It.IsAny<string>()
                                                                    , It.IsAny<string>()), Times.Never);
            tgimbaService.Verify(x => x.Log(It.Is<string>(s => s.Contains("400 BadRequest"))), Times.Once);
        }

        [TestMethod]
        public void ProcessUserRegistration_EmptyEmail()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);
            var login = new LoginRequest() { EncodedUserName = "", EncodedPassword = "password" };
            var registration = new RegistrationRequest() { Login = login, EncodedEmail = "email" };

            validationHelper.Setup(x => x.IsValidRequest
                                    (It.IsAny<RegistrationRequest>()))
                                        .Throws(new ArgumentNullException(""));

            IActionResult result = tgimbaApi.ProcessUserRegistration(registration);
            BadRequestResult requestResult = (BadRequestResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(400, requestResult.StatusCode);
            tgimbaService.Verify(x => x.ProcessUser(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            tgimbaService.Verify(x => x.Log(It.Is<string>(s => s.Contains("400 BadRequest"))), Times.Once);
        }

        [TestMethod]
        public void ProcessUserRegistration_NullPassword()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);
            var login = new LoginRequest() { EncodedUserName = "", EncodedPassword = null };
            var registration = new RegistrationRequest() { Login = login, EncodedEmail = "email" };

            validationHelper.Setup(x => x.IsValidRequest
                                    (It.IsAny<RegistrationRequest>()))
                                        .Throws(new ArgumentNullException(""));

            IActionResult result = tgimbaApi.ProcessUserRegistration(registration);
            BadRequestResult requestResult = (BadRequestResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(400, requestResult.StatusCode);
            tgimbaService.Verify(x => x.ProcessUserRegistration(It.IsAny<string>(), It.IsAny<string>()
                                                                    , It.IsAny<string>()), Times.Never);
            tgimbaService.Verify(x => x.Log(It.Is<string>(s => s.Contains("400 BadRequest"))), Times.Once);
        }

        [TestMethod]
        public void ProcessUserRegistration_EmptyPassword()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);
            var login = new LoginRequest() { EncodedUserName = "userName", EncodedPassword = "" };
            var registration = new RegistrationRequest() { Login = login, EncodedEmail = "email" };

            validationHelper.Setup(x => x.IsValidRequest
                                    (It.IsAny<RegistrationRequest>()))
                                        .Throws(new ArgumentNullException(""));

            IActionResult result = tgimbaApi.ProcessUserRegistration(registration);
            BadRequestResult requestResult = (BadRequestResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(400, requestResult.StatusCode);
            tgimbaService.Verify(x => x.ProcessUser(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            validationHelper.Verify(x => x.IsValidRequest(
                            It.Is<RegistrationRequest>(s => s.Login.EncodedPassword == ""))
                                , Times.Once);
        }

        [TestMethod]
        public void ProcessUserRegistration_GeneralErrorTest()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);
            var login = new LoginRequest() { EncodedUserName = "", EncodedPassword = "password" };
            var registration = new RegistrationRequest() { Login = login, EncodedEmail = "email" };

            tgimbaService.Setup(x => x.ProcessUserRegistration
                                    (It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                                        .Throws(new Exception("I am an exception"));

            IActionResult result = tgimbaApi.ProcessUserRegistration(registration);
            StatusCodeResult requestResult = (StatusCodeResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(500, requestResult.StatusCode);
            tgimbaService.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
        }

        #endregion

    }
}
