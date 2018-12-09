using Shared.dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsDAL
{
    [TestClass]
    public class MemberShipDataTests : BaseTest
    {
        public MemberShipDataTests() : base() { }

        [TestMethod]
        public void RunMemberShipDataTests()
        {   
            string userName = "memberShipanAwesomeUser";
            string email = "memberShipanAwesomeUser@test.com";
            string password = "memberShipanAwesomePassword";
            string salt = "memberShipsalt";

            AddUserTest(userName, email, password, salt, "");
            AddTokenTest(userName, email, password, salt, "token");
            DeleteUserTest(userName, email, password);
        }

        private void AddUserTest(string userName, string email, string password, string salt, string token)
        {
            Assert.IsTrue(mdb.AddUser(userName, email, password, salt));
            isSameUser(mdb.GetUser(userName), userName, email, password, salt, token);
        }
        private void AddTokenTest(string userName, string email, string password, string salt, string token)
        {
            mdb.AddToken(userName, token);
            isSameUser(mdb.GetUser(userName), userName, email, password, salt, token);
        }
        private void DeleteUserTest(string userName, string email, string password)
        {
            Assert.IsTrue(mdb.DeleteUser(userName, password, email));
            Assert.IsNull(mdb.GetUser(userName));
        }
        private void isSameUser(User user, string userName, string email, string password, string salt, string token)
        {
            Assert.AreEqual(user.Email, email);
            Assert.AreEqual(user.UserName, userName);
            Assert.AreEqual(user.Password, password);
            Assert.AreEqual(user.Salt, salt);
            Assert.AreEqual(user.Token, token);
        }
    }
}
