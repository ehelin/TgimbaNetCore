using DALNetCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.interfaces;

namespace TestDALNetCore_Integration
{
    [TestClass]
    public class UserTests : BaseTest
    {
        // TODO Error Tests to add
        // - User not found on add token
        // - User does not exist on get user
        // - User does not exist on delete user

        [TestMethod]
        public void UserHappyPath_Test()
        {
            var token = "token";
            var user = GetUser(token);

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
    }
}
