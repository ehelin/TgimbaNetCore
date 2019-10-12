using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shared.dto;
using Shared;

namespace TestAPINetCore_Unit
{
    [TestClass]
    public class MiscTests : BaseTest
    {
        [TestMethod]
        public void Log_HappyPathTest()
        {
            var msg = "I am a message";
            this.service.Log(msg);
            this.mockBucketListData.Verify(x => x.LogMsg(It.Is<string>(s => s.Contains(msg))), Times.Once);
        }

        [TestMethod]
        public void GetSystemStatistics_HappyPathTest()
        {
            var systemStatisticToReturn = new SystemStatistic()
            {
                WebSiteIsUp = true,
                DatabaseIsUp = true,
                AzureFunctionIsUp = true,
                Created = DateTime.UtcNow.ToString()
            };
            IList<SystemStatistic> systemStatisticsToReturn = new List<SystemStatistic>();
            systemStatisticsToReturn.Add(systemStatisticToReturn);
            this.mockBucketListData.Setup(x => x.GetSystemStatistics()).Returns(systemStatisticsToReturn);

            var systemStatistics = this.service.GetSystemStatistics();

            Assert.IsNotNull(systemStatistics);
            Assert.AreEqual(systemStatisticToReturn.WebSiteIsUp, systemStatistics[0].WebSiteIsUp);
            Assert.AreEqual(systemStatisticToReturn.DatabaseIsUp, systemStatistics[0].DatabaseIsUp);
            Assert.AreEqual(systemStatisticToReturn.AzureFunctionIsUp, systemStatistics[0].AzureFunctionIsUp);
            Assert.AreEqual(systemStatisticToReturn.Created, systemStatistics[0].Created);
            this.mockBucketListData.Verify(x => x.GetSystemStatistics(), Times.Once);
        }

        [TestMethod]
        public void GetSystemBuildStatistics_HappyPathTest()
        {
            var commonDate = DateTime.UtcNow.ToString();
            var systemBuildStatisticToReturn = new SystemBuildStatistic()
            {
                Start = commonDate,
                End = commonDate,
                BuildNumber = "build",
                Status = "status"
            };
            var systemBuildStatisticsToReturn = new List<SystemBuildStatistic>();
            systemBuildStatisticsToReturn.Add(systemBuildStatisticToReturn);
            this.mockBucketListData.Setup(x => x.GetSystemBuildStatistics()).Returns(systemBuildStatisticsToReturn);

            var systemBuildStatistics = this.service.GetSystemBuildStatistics();

            Assert.IsNotNull(systemBuildStatistics);
            Assert.AreEqual(systemBuildStatisticToReturn.Start, systemBuildStatistics[0].Start);
            Assert.AreEqual(systemBuildStatisticToReturn.End, systemBuildStatistics[0].End);
            Assert.AreEqual(systemBuildStatisticToReturn.BuildNumber, systemBuildStatistics[0].BuildNumber);
            Assert.AreEqual(systemBuildStatisticToReturn.Status, systemBuildStatistics[0].Status);
            this.mockBucketListData.Verify(x => x.GetSystemBuildStatistics(), Times.Once);
        }

        [TestMethod]
        public void GetTestResult_HappyPathTest()
        {
            var testResult = this.service.GetTestResult();

            Assert.IsNotNull(testResult);
            Assert.AreEqual(Constants.API_TEST_RESULT, testResult);
        }

        [TestMethod]
        [Ignore]
        public void LoginDemoUser_HappyPathTest()
        {
            var jwtPrivateKey = "jwtPrivateKey";
            var jwtIssuer = "jwtIssuer";
            var jwtToken = "jwtToken";
            var demoUserToReturn = GetUser(1, Constants.DEMO_USER, Constants.DEMO_USER_PASSWORD);
            var expectedHashPasswordParameter = new Password(Constants.DEMO_USER_PASSWORD);
            var expectedHashPasswordToReturn = new Password(Constants.DEMO_USER_PASSWORD);
            expectedHashPasswordToReturn.SaltedHashedPassword = "saltedDemoUserPassword";

            this.mockBucketListData
                .Setup(x => x.GetUser(It.IsAny<string>()))
                .Returns(demoUserToReturn);
            this.mockGenerator.Setup(x => x.GetJwtPrivateKey()).Returns(jwtPrivateKey);
            this.mockGenerator.Setup(x => x.GetJwtIssuer()).Returns(jwtIssuer); 
            this.mockPassword.Setup(x =>
                x.HashPassword
                    (It.IsAny<Password>()))
                        .Returns(expectedHashPasswordToReturn);
            this.mockPassword.Setup(x =>
                    x.PasswordsMatch
                        (It.Is<Password>(z => z == expectedHashPasswordToReturn)
                        , It.Is<User>(s => s == demoUserToReturn))).Returns(true);
            this.mockGenerator.Setup(x =>
                    x.GetJwtToken
                        (It.Is<string>(z => z == jwtPrivateKey)
                        , It.Is<string>(s => s == jwtIssuer))).Returns(jwtToken);

            var token = this.service.LoginDemoUser();

            Assert.IsNotNull(token);
            Assert.IsTrue(token.Length > 0);
            Assert.AreEqual(jwtToken, token);

            this.mockPassword
                .Verify(x => x.HashPassword(
                    It.Is<Password>(s => s == expectedHashPasswordToReturn))
                            , Times.Once);

            this.mockPassword.Verify(x => 
                    x.PasswordsMatch
                        (It.Is<Password>(z => z == expectedHashPasswordParameter)
                        , It.Is<User>(s => s == demoUserToReturn))
                        , Times.Once);
            this.mockGenerator.Verify(x => x.GetJwtPrivateKey(), Times.Once);
            this.mockGenerator.Verify(x => x.GetJwtIssuer(), Times.Once);
            this.mockGenerator.Verify(x =>
                    x.GetJwtToken
                        (It.Is<string>(z => z == jwtPrivateKey)
                        , It.Is<string>(s => s == jwtIssuer))
                        , Times.Once);
        }
    }
}
