using DALNetCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.interfaces;
using Shared.exceptions;
using Shared.dto;
using models = DALNetCore.Models;

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
            IBucketListData bd = new BucketListData(this.GetDbContext(), this.userHelper);


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
        public void User_ConvertDbUserToUser_Test()
        {
            var token = "token";
            var dbUser = GetDbUser(token);

            Assert.IsInstanceOfType(dbUser, typeof(models.User));

            var user = this.userHelper.ConvertDbUserToUser(dbUser);

            Assert.IsInstanceOfType(user, typeof(User));
            Assert.IsNotNull(user);
            Assert.AreEqual(user.UserName, dbUser.UserName);
            Assert.AreEqual(user.Password, dbUser.PassWord);
            Assert.AreEqual(user.Salt, dbUser.Salt);
            Assert.AreEqual(user.Email, dbUser.Email);
            Assert.AreEqual(token, dbUser.Token);
        }

        [TestMethod]
        [ExpectedException(typeof(RecordDoesNotExistException))]
        public void User_AddToken_UserDoesNotExist_Test()
        {
            RemoveTestUser();

            var unknownUserId = -12521;
            IBucketListData bd = new BucketListData(this.GetDbContext(), this.userHelper);

            bd.AddToken(unknownUserId, this.Token);

            // NOTE: RecordDoesNotExistException is expected
        }

        [TestMethod]
        [ExpectedException(typeof(RecordDoesNotExistException))]
        public void User_GetUser_UserDoesNotExist_Test()
        {
            RemoveTestUser();

            var unknownUserId = -12521;
            IBucketListData bd = new BucketListData(this.GetDbContext(), this.userHelper);

            bd.GetUser(unknownUserId);

            // NOTE: RecordDoesNotExistException is expected
        }

        [TestMethod]
        [ExpectedException(typeof(RecordDoesNotExistException))]
        public void User_DeleteUser_UserDoesNotExist_Test()
        {
            RemoveTestUser();

            var unknownUserId = -12521;
            IBucketListData bd = new BucketListData(this.GetDbContext(), this.userHelper);

            bd.DeleteUser(unknownUserId);

            // NOTE: RecordDoesNotExistException is expected
        }
    }
}
