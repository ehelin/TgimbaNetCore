using DALNetCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.interfaces;
using Shared.exceptions;

namespace TestDALNetCore_Integration
{
    [TestClass]
    public class UserTests : BaseTest
    {
        [TestMethod]
        public void User_HappyPath_Test()
        {
            RemoveTestUser();

            var token = "token";
            var user = GetUser(token);
            IBucketListData bd = new BucketListData(this.GetDbContext());

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
        [ExpectedException(typeof(RecordDoesNotExistException))]
        public void User_AddToken_UserDoesNotExist_Test()
        {
            RemoveTestUser();

            var unknownUserId = -12521;
            IBucketListData bd = new BucketListData(this.GetDbContext());

            bd.AddToken(unknownUserId, this.Token);

            // NOTE: RecordDoesNotExistException is expected
        }

        [TestMethod]
        [ExpectedException(typeof(RecordDoesNotExistException))]
        public void User_GetUser_UserDoesNotExist_Test()
        {
            RemoveTestUser();

            var unknownUserId = -12521;
            IBucketListData bd = new BucketListData(this.GetDbContext());

            bd.GetUser(unknownUserId);

            // NOTE: RecordDoesNotExistException is expected
        }

        [TestMethod]
        [ExpectedException(typeof(RecordDoesNotExistException))]
        public void User_DeleteUser_UserDoesNotExist_Test()
        {
            RemoveTestUser();

            var unknownUserId = -12521;
            IBucketListData bd = new BucketListData(this.GetDbContext());

            bd.DeleteUser(unknownUserId);

            // NOTE: RecordDoesNotExistException is expected
        }
    }
}
