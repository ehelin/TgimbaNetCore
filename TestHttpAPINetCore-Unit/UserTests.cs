using HttpAPINetCore.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Shared.interfaces;
using Shared.dto;
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
            var tokenToReturn = "token";
            var tgimbaService = new Mock<ITgimbaService>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object);
            tgimbaService.Setup(x => x.ProcessUser
                                    (It.Is<string>(s => s == userName), 
                                      It.Is<string>(s => s == password)
                                        )).Returns(tokenToReturn);

            IActionResult result = tgimbaApi.ProcessUser(userName, password);
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
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object);

            IActionResult result = tgimbaApi.ProcessUser(null, "password");
            BadRequestResult requestResult = (BadRequestResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(400, requestResult.StatusCode);
            tgimbaService.Verify(x => x.ProcessUser(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            tgimbaService.Verify(x => x.Log(It.Is<string>(s => s.Contains("encodedUser"))), Times.Once);
        }

        [TestMethod]
        public void ProcessUser_EmptyUserName()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object);

            IActionResult result = tgimbaApi.ProcessUser("", "password");
            BadRequestResult requestResult = (BadRequestResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(400, requestResult.StatusCode);
            tgimbaService.Verify(x => x.ProcessUser(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            tgimbaService.Verify(x => x.Log(It.Is<string>(s => s.Contains("encodedUser"))), Times.Once);
        }

        [TestMethod]
        public void ProcessUser_NullPassword()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object);

            IActionResult result = tgimbaApi.ProcessUser("userName", null);
            BadRequestResult requestResult = (BadRequestResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(400, requestResult.StatusCode);
            tgimbaService.Verify(x => x.ProcessUser(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            tgimbaService.Verify(x => x.Log(It.Is<string>(s => s.Contains("encodedPass"))), Times.Once);
        }

        [TestMethod]
        public void ProcessUser_EmptyPassword()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object);

            IActionResult result = tgimbaApi.ProcessUser("userName", "");
            BadRequestResult requestResult = (BadRequestResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(400, requestResult.StatusCode);
            tgimbaService.Verify(x => x.ProcessUser(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            tgimbaService.Verify(x => x.Log(It.Is<string>(s => s.Contains("encodedPass"))), Times.Once);
        }

        [TestMethod]
        public void ProcessUser_GeneralErrorTest()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object);
            tgimbaService.Setup(x => x.ProcessUser
                                (It.IsAny<string>(), It.IsAny<string>()))
                                     .Throws(new Exception("I am an exception"));
            IActionResult result = tgimbaApi.ProcessUser("userName", "password");
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
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object);
            tgimbaService.Setup(x => x.ProcessUserRegistration
                                        (It.Is<string>(s => s == userName),
                                            It.Is<string>(s => s == email),
                                                It.Is<string>(s => s == password)
                                                    )).Returns(userRegisteredToReturn);

            IActionResult result = tgimbaApi.ProcessUserRegistration(userName, email, password);
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
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object);

            IActionResult result = tgimbaApi.ProcessUserRegistration(null, "email", "password");
            BadRequestResult requestResult = (BadRequestResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(400, requestResult.StatusCode); 
            tgimbaService.Verify(x => x.ProcessUserRegistration(It.IsAny<string>(), It.IsAny<string>()
                                                                    , It.IsAny<string>()), Times.Never);
            tgimbaService.Verify(x => x.Log(It.Is<string>(s => s.Contains("encodedUser"))), Times.Once);
        }

        [TestMethod]
        public void ProcessUserRegistration_EmptyUserName()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object);

            IActionResult result = tgimbaApi.ProcessUser("", "password");
            BadRequestResult requestResult = (BadRequestResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(400, requestResult.StatusCode);
            tgimbaService.Verify(x => x.ProcessUser(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            tgimbaService.Verify(x => x.Log(It.Is<string>(s => s.Contains("encodedUser"))), Times.Once);
        }
        
        [TestMethod]
        public void ProcessUserRegistration_NullEmail()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object);

            IActionResult result = tgimbaApi.ProcessUserRegistration("userName", null, "password");
            BadRequestResult requestResult = (BadRequestResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(400, requestResult.StatusCode);
            tgimbaService.Verify(x => x.ProcessUserRegistration(It.IsAny<string>(), It.IsAny<string>()
                                                                    , It.IsAny<string>()), Times.Never);
            tgimbaService.Verify(x => x.Log(It.Is<string>(s => s.Contains("encodedEmail"))), Times.Once);
        }

        [TestMethod]
        public void ProcessUserRegistration_EmptyEmail()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object);

            IActionResult result = tgimbaApi.ProcessUserRegistration("userName", "", "password");
            BadRequestResult requestResult = (BadRequestResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(400, requestResult.StatusCode);
            tgimbaService.Verify(x => x.ProcessUser(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            tgimbaService.Verify(x => x.Log(It.Is<string>(s => s.Contains("encodedEmail"))), Times.Once);
        }
        
        [TestMethod]
        public void ProcessUserRegistration_NullPassword()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object);

            IActionResult result = tgimbaApi.ProcessUserRegistration("userName", "email", null);
            BadRequestResult requestResult = (BadRequestResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(400, requestResult.StatusCode);
            tgimbaService.Verify(x => x.ProcessUserRegistration(It.IsAny<string>(), It.IsAny<string>()
                                                                    , It.IsAny<string>()), Times.Never);
            tgimbaService.Verify(x => x.Log(It.Is<string>(s => s.Contains("encodedPass"))), Times.Once);
        }

        [TestMethod]
        public void ProcessUserRegistration_EmptyPassword()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object);

            IActionResult result = tgimbaApi.ProcessUserRegistration("userName", "email", "");
            BadRequestResult requestResult = (BadRequestResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(400, requestResult.StatusCode);
            tgimbaService.Verify(x => x.ProcessUser(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            tgimbaService.Verify(x => x.Log(It.Is<string>(s => s.Contains("encodedPass"))), Times.Once);
        }

        [TestMethod]
        public void ProcessUserRegistration_GeneralErrorTest()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object);
            tgimbaService.Setup(x => x.ProcessUserRegistration
                                    (It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                                        .Throws(new Exception("I am an exception"));
            IActionResult result = tgimbaApi.ProcessUserRegistration("userName", "email", "password");
            StatusCodeResult requestResult = (StatusCodeResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(500, requestResult.StatusCode);
            tgimbaService.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
        }

        #endregion

    }
}
