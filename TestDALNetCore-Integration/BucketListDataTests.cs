using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.interfaces;
using DALNetCore;
using DALNetCore.Models;
using System.Linq;
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

        public void GetSystemBuildStatisticsTest()
        {
            var dbContext = new BucketListContext();
            IBucketListData bd = new BucketListData(dbContext);

            // TODO - complete test
        }
        public void GetSystemSystemStatisticsTest()
        {
            var dbContext = new BucketListContext();
            IBucketListData bd = new BucketListData(dbContext);

            // TODO - complete test
        }
    }
}
