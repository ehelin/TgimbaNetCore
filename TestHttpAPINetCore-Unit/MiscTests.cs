using HttpAPINetCore.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Shared.interfaces;
using Shared.dto;
using System.Collections.Generic;
using Shared;
using Shared.dto.api;

namespace TestHttpAPINetCore_Unit
{
    [TestClass]
    public class MiscTests
    {
        #region GetSystemBuildStatistics

        [TestMethod]
        public void GetSystemBuildStatistics_HappyPathTest()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);
            var createdDate = DateTime.UtcNow.ToString();
            var systemBuildStatisticsToReturn = new List<SystemBuildStatistic>();
            systemBuildStatisticsToReturn.Add(new SystemBuildStatistic()
            {
                Start = createdDate,
                End = createdDate,
                BuildNumber = "I am a build number",
                Status = "I am a status",
            });

            tgimbaService.Setup(x => x.GetSystemBuildStatistics(It.IsAny<string>(), 
                                                                  It.IsAny<string>()))
                                                                     .Returns(systemBuildStatisticsToReturn);

            IActionResult result = tgimbaApi.GetSystemBuildStatistics("encodedUser", "encodedToken");
            OkObjectResult requestResult = (OkObjectResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(200, requestResult.StatusCode);
            tgimbaService.Verify(x => x.GetSystemBuildStatistics("encodedUser", "encodedToken"), Times.Once);
            var systemStatistics = (List<SystemBuildStatistic>)requestResult.Value;
            Assert.AreEqual(1, systemStatistics.Count);
            Assert.AreEqual(systemBuildStatisticsToReturn, systemStatistics);
        }

        [TestMethod]
        public void GetSystemBuildStatistics_NoResultNullCollection()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);
            List<SystemBuildStatistic> systemBuildStatisticsToReturn = null;

            tgimbaService.Setup(x => x.GetSystemBuildStatistics(It.IsAny<string>(),
                                                                  It.IsAny<string>()))
                                                                    .Returns(systemBuildStatisticsToReturn);

            IActionResult result = tgimbaApi.GetSystemBuildStatistics("encodedUser", "encodedToken");
            StatusCodeResult requestResult = (StatusCodeResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(404, requestResult.StatusCode);
        }

        [TestMethod]
        public void GetSystemBuildStatistics_NoResultEmptyCollection()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);
            var systemBuildStatisticsToReturn = new List<SystemBuildStatistic>();

            tgimbaService.Setup(x => x.GetSystemBuildStatistics(It.IsAny<string>(),
                                                                  It.IsAny<string>()))
                                                                    .Returns(systemBuildStatisticsToReturn);

            IActionResult result = tgimbaApi.GetSystemBuildStatistics("encodedUser", "encodedToken");
            StatusCodeResult requestResult = (StatusCodeResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(404, requestResult.StatusCode);
        }

        [TestMethod]
        public void GetSystemBuildStatistics_GeneralErrorTest()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);
            var exception = "I am an exception";
            tgimbaService.Setup(x => x.GetSystemBuildStatistics(It.IsAny<string>(),
                                                                  It.IsAny<string>()))
                                                                     .Throws(new Exception(exception));
            IActionResult result = tgimbaApi.GetSystemBuildStatistics("encodedUser", "encodedToken");
            StatusCodeResult requestResult = (StatusCodeResult)result;

            tgimbaService.Verify(x => x.Log(It.Is<string>(s => s == exception)), Times.Once);
            Assert.IsNotNull(requestResult);
            Assert.AreEqual(500, requestResult.StatusCode);
        }

        #endregion

        #region GetSystemStatistics

        [TestMethod]
        public void GetSystemStatistics_HappyPathTest()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);
            var createdDate = DateTime.UtcNow.ToString();
            var systemStatisticsToReturn = new List<SystemStatistic>();
            systemStatisticsToReturn.Add(new SystemStatistic()
            {
                WebSiteIsUp = true,
                DatabaseIsUp = true,
                AzureFunctionIsUp = true,
                Created = createdDate,
            });
            tgimbaService.Setup(x => x.GetSystemStatistics(It.IsAny<string>(),
                                                                  It.IsAny<string>()))
                                                                        .Returns(systemStatisticsToReturn);

            IActionResult result = tgimbaApi.GetSystemStatistics("encodedUser", "encodedToken");
            OkObjectResult requestResult = (OkObjectResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(200, requestResult.StatusCode);
            tgimbaService.Verify(x => x.GetSystemStatistics(It.IsAny<string>(),
                                                                  It.IsAny<string>())
                                                                       , Times.Once);
            var systemStatistics = (List<SystemStatistic>)requestResult.Value;
            Assert.AreEqual(1, systemStatistics.Count);
            Assert.AreEqual(systemStatisticsToReturn, systemStatistics);
        }

        [TestMethod]
        public void GetSystemStatistics_NoResultNullCollection()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);
            List<SystemStatistic> systemStatisticsToReturn = null;

            tgimbaService.Setup(x => x.GetSystemStatistics(It.IsAny<string>(),
                                                                  It.IsAny<string>()))
                                                                    .Returns(systemStatisticsToReturn);

            IActionResult result = tgimbaApi.GetSystemStatistics("encodedUser", "encodedToken");
            StatusCodeResult requestResult = (StatusCodeResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(404, requestResult.StatusCode);
        }

        [TestMethod]
        public void GetSystemStatistics_NoResultEmptyCollection()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);
            var systemStatisticsToReturn = new List<SystemStatistic>();

            tgimbaService.Setup(x => x.GetSystemStatistics(It.IsAny<string>(),
                                                                  It.IsAny<string>()))
                                                                        .Returns(systemStatisticsToReturn);

            IActionResult result = tgimbaApi.GetSystemStatistics("encodedUser", "encodedToken");
            StatusCodeResult requestResult = (StatusCodeResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(404, requestResult.StatusCode);
        }

        [TestMethod]
        public void GetSystemStatistics_GeneralErrorTest()
        {
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaService = new Mock<ITgimbaService>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);
            var exception = "I am an exception";
            tgimbaService.Setup(x => x.GetSystemStatistics(It.IsAny<string>(),
                                                                  It.IsAny<string>()))
                                                                        .Throws(new Exception(exception));
            IActionResult result = tgimbaApi.GetSystemStatistics("encodedUser", "encodedToken");
            StatusCodeResult requestResult = (StatusCodeResult)result;

            tgimbaService.Verify(x => x.Log(It.Is<string>(s => s == exception)), Times.Once);
            Assert.IsNotNull(requestResult);
            Assert.AreEqual(500, requestResult.StatusCode);
        }

        #endregion

        #region Log

        [TestMethod]
        public void Log_HappyPathTest()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);
            var request = new LogMessageRequest() 
            {
                Token = new TokenRequest() 
                {
                    EncodedUserName = "encodeUser",
                    EncodedToken = "encodedToken"
                },
                Message = "IAmALogMessage"
            };
            IActionResult result = tgimbaApi.Log(request);
            OkResult requestResult = (OkResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(200, requestResult.StatusCode);
            tgimbaService.Verify(x => x.LogAuthenticated(It.Is<string>(s => s == request.Message),
                                                            It.IsAny<string>(),
                                                              It.IsAny<string>())
                                                               , Times.Once);
        }

        [TestMethod]
        public void Log_GeneralErrorTest()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);
            tgimbaService.Setup(x => x.LogAuthenticated(It.IsAny<string>(),
                                                          It.IsAny<string>(),
                                                            It.IsAny<string>()))
                                                                  .Throws(new Exception("I am an exception"));
            var request = new LogMessageRequest()
            {
                Token = new TokenRequest()
                {
                    EncodedUserName = "encodeUser",
                    EncodedToken = "encodedToken"
                },
                Message = "IAmALogMessage"
            };
            IActionResult result = tgimbaApi.Log(request);
            StatusCodeResult requestResult = (StatusCodeResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(500, requestResult.StatusCode);
        }

        #endregion

        #region Test Result

        [TestMethod]
        public void GetTestResult_HappyPathTest()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);
            tgimbaService.Setup(x => x.GetTestResult())
                            .Returns(Constants.API_TEST_RESULT);

            IActionResult result = tgimbaApi.GetTestResult();
            OkObjectResult requestResult = (OkObjectResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(200, requestResult.StatusCode);
            tgimbaService.Verify(x => x.GetTestResult(), Times.Once);
            var testResult = (string)requestResult.Value;
            Assert.AreEqual(Constants.API_TEST_RESULT, testResult);
        }

        [TestMethod]
        public void GetTestResult_GeneralErrorTest()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);
            var exception = "I am an exception";
            tgimbaService.Setup(x => x.GetTestResult())
                            .Throws(new Exception(exception));

            IActionResult result = tgimbaApi.GetTestResult();
            StatusCodeResult requestResult = (StatusCodeResult)result;

            tgimbaService.Verify(x => x.Log(It.Is<string>(s => s == exception)), Times.Once);
            Assert.IsNotNull(requestResult);
            Assert.AreEqual(500, requestResult.StatusCode);
        }

        #endregion

        #region LoginDemoUser

        [TestMethod]
        public void LoginDemoUser_HappyPathTest()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var tokenToReturn = "IAmAToken";
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);
            tgimbaService.Setup(x => x.LoginDemoUser())
                            .Returns(tokenToReturn);

            IActionResult result = tgimbaApi.LoginDemoUser();
            OkObjectResult requestResult = (OkObjectResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(200, requestResult.StatusCode);
            tgimbaService.Verify(x => x.LoginDemoUser(), Times.Once);
            var token = (string)requestResult.Value;
            Assert.AreEqual(tokenToReturn, token);
        }

        [TestMethod]
        public void LoginDemoUser_GeneralErrorTest()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);
            var exception = "I am an exception";
            tgimbaService.Setup(x => x.LoginDemoUser())
                            .Throws(new Exception(exception));

            IActionResult result = tgimbaApi.LoginDemoUser();
            StatusCodeResult requestResult = (StatusCodeResult)result;

            tgimbaService.Verify(x => x.Log(It.Is<string>(s => s == exception)), Times.Once);
            Assert.IsNotNull(requestResult);
            Assert.AreEqual(500, requestResult.StatusCode);
        }

        #endregion
    }
}
