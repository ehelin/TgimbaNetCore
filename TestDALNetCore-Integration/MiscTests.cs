using System;
using System.Linq;
using DALNetCore;
using DALNetCore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.interfaces;
using Shared.misc.testUtilities;

namespace TestDALNetCore_Integration
{
    [TestClass]
    public class MiscTests : BaseTest
    {
        [TestCleanup]
        public void Cleanup()
        {
            TestUtilities.ClearEnvironmentalVariablesForIntegrationTests();
        }

        [TestInitialize]
        public void SetUp()
        {
            TestUtilities.SetEnvironmentalVariablesForIntegrationTests();
        }

        [TestMethod]
        public void GetSystemBuildStatisticsHappyPath_Test()
        {
            //set up ------------------------------------------------------
            var dbContext = this.GetDbContext(true);
            var now = DateTime.Now;
            var buildStatisticsToSave = new BuildStatistics
            {
                Start = now,
                End = now.AddMinutes(1),
                BuildNumber = "123",
                Status = "Succeeded",
                Type = "CICD Pipeline - Website"
            };            
            dbContext.BuildStatistics.Add(buildStatisticsToSave);
            dbContext.SaveChanges();

            //test ---------------------------------------------------------
            IBucketListData bd = new BucketListData(dbContext, this.userHelper);
            var buildStatistics = bd.GetSystemBuildStatistics();

            Assert.IsNotNull(buildStatistics);
            var buildStatistic = buildStatistics
                                    .OrderByDescending(x => Convert.ToDateTime(x.Start))
                                    .FirstOrDefault();
            Assert.AreEqual(buildStatistic.Start, buildStatisticsToSave.Start.ToString());
            Assert.AreEqual(buildStatistic.End, buildStatisticsToSave.End.ToString());
            Assert.AreEqual(buildStatistic.BuildNumber, buildStatisticsToSave.BuildNumber);
            Assert.AreEqual(buildStatistic.Status, buildStatisticsToSave.Status);

            //clean up ------------------------------------------------------
            dbContext.Remove(buildStatisticsToSave);
            dbContext.SaveChanges();
        }

        [TestMethod]
        public void GetSystemSystemStatisticsGetSystemBuildStatisticsHappyPath_Test()
        {        
            //set up ------------------------------------------------------
            var dbContext = this.GetDbContext();
            var now = DateTime.Now;
            var systemStatisticsToSave = new SystemStatistics
            {
                WebsiteIsUp = true,
                DatabaseIsUp = true,
                AzureFunctionIsUp = true,
                Created = now
            };
            dbContext.SystemStatistics.Add(systemStatisticsToSave);
            dbContext.SaveChanges();

            //test ---------------------------------------------------------
            IBucketListData bd = new BucketListData(dbContext, this.userHelper);
            var systemStatistics = bd.GetSystemStatistics();

            Assert.IsNotNull(systemStatistics);
            var systemStatistic = systemStatistics
                                    .OrderByDescending(x => Convert.ToDateTime(x.Created))
                                    .FirstOrDefault();
            Assert.AreEqual(systemStatistic.WebSiteIsUp, systemStatisticsToSave.WebsiteIsUp);
            Assert.AreEqual(systemStatistic.DatabaseIsUp, systemStatisticsToSave.DatabaseIsUp);
            Assert.AreEqual(systemStatistic.AzureFunctionIsUp, systemStatisticsToSave.AzureFunctionIsUp);
            Assert.AreEqual(systemStatistic.Created, systemStatisticsToSave.Created.ToString());

            //clean up ------------------------------------------------------
            dbContext.Remove(systemStatisticsToSave);
            dbContext.SaveChanges();
        }

        [TestMethod]
        public void LogMsgHappyPath_Test()
        {
            var dbContext = this.GetDbContext();
            IBucketListData bd = new BucketListData(dbContext, this.userHelper);

            //test ----------------------------
            var msg = "I am a log message";
            bd.LogMsg(msg);
            dbContext.SaveChanges();

            var logModel = dbContext.Log
                                    .Where(x => x.LogMessage == msg)
                                    .FirstOrDefault();

            Assert.IsNotNull(logModel);
            Assert.AreEqual(msg, logModel.LogMessage);

            //clean up ------------------------------------------------------
            dbContext.Remove(logModel);
            dbContext.SaveChanges();
        }
    }
}
