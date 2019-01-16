using Shared.interfaces;
using DAL.providers;
using Shared;
using Shared.misc;

namespace TestsAPIIntegration
{
    public class BaseTest
    {
        protected IBucketListData bdb;
        protected IMemberShipData mdb;

        public BaseTest()
        {
            bdb = new BucketListData(Utilities.GetDbSetting());
            mdb = new MemberShipData(Utilities.GetDbSetting());
        }

        protected string AddUser(string userName, string email, string password, string salt = "salt")
        {
            mdb.AddUser(userName, email, password, salt);

            return userName;
        }
        protected void DeleteUser(string userName, string email, string password)
        {
            mdb.DeleteUser(userName, password, email);
        }
    }
}
