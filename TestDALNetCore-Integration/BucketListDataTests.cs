using DALNetCore;
using DALNetCore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.interfaces;
using System.Linq;
using System;
using dto = Shared.dto;

namespace TestDALNetCore_Integration
{
    [TestClass]
    public class TokenTests
    {
        [TestMethod]
        public void UserHappyPath_Test()
        {
            var token = "token";
            var user = new dto.User()
            {
                UserName = "user",
                Salt = "salt",
                Password = "password",
                Email = "user@email.com",
                Token = token
            };

            var dbContext = new BucketListContext();
            IBucketListData bd = new BucketListData(dbContext);

            var userId = bd.AddUser(user);
            bd.AddToken(userId, token);

            var savedUser = bd.GetUser(userId);

            Assert.AreEqual(user.UserName, savedUser.UserName);
            Assert.AreEqual(user.Password, savedUser.Password);
            Assert.AreEqual(user.Salt, savedUser.Salt);
            Assert.AreEqual(user.Email, savedUser.Email);
            Assert.AreEqual(token, savedUser.Token);

            bd.DeleteUser(savedUser.UserId);
        }

        [TestMethod]
        public void GetSystemBuildStatisticsTest()
        {
            //set up ------------------------------------------------------
            var dbContext = new BucketListContext();
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
            IBucketListData bd = new BucketListData(dbContext);
            var buildStatistics = bd.GetSystemBuildStatistics();

            Assert.IsNotNull(buildStatistics);
            var buildStatistic = buildStatistics
                                    .OrderByDescending(x => x.Start)
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
        public void GetSystemSystemStatisticsTest()
        {
            var dbContext = new BucketListContext();
            IBucketListData bd = new BucketListData(dbContext);

            // TODO - complete test
        }
    }
}
