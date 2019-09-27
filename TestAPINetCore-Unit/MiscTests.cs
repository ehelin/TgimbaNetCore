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
            throw new NotImplementedException();
        }
    }
}
