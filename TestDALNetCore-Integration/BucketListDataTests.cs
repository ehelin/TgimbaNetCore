using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.interfaces;
using DALNetCore;
using DALNetCore.Models;
using System.Linq;

namespace TestDALNetCore_Integration
{
    [TestClass]
    public class TokenTests
    {
        [TestMethod]
        public void UserHappyPath_Test()
        {
            var user = "user";
            var password = "password";
            var salt = "salt";
            var email = "user@email.com";
            var token = "token";

            var dbContext = new BucketListContext();
            IBucketListData bd = new BucketListData(dbContext);

            bd.AddUser(user, email, password, salt);
            bd.AddToken(user, token);

            // TODO - work the GetUser(args)

            var dbContextResult = new BucketListContext();
            var result = dbContextResult.User
                                    .Where(x => x.UserName == user)
                                    .FirstOrDefault();

            // TODO - token is NOT being saved and the password/salt returned looks hashed
            Assert.AreEqual(user, result.UserName);
            Assert.AreEqual(password, result.PassWord);
            Assert.AreEqual(salt, result.Salt);
            Assert.AreEqual(email, result.Email);
            Assert.AreEqual(token, result.Token);

            bd.DeleteUser(user, password, email);
        }
    }
}
