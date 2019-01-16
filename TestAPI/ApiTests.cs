using API;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.interfaces;
using Shared.misc;
using System;

namespace TestsAPIIntegration
{
    [TestClass]
    public class ApiTests : BaseTest
    {
        private ITgimbaService service = null;
   
        private string user = "ApianAwesomeUser";
        private string password = "ApianAwesomeUserPass0rd1";
        private string email = "ApianAwesomeUser@awesomeuser.com";

        public ApiTests()
        {
            service = new TgimbaService();
        }

        [TestMethod]
        public void LoginDemoUserTest()
        {
            var token = service.LoginDemoUser();
            Assert.IsNotNull(token);
        }

        [TestMethod]
        public void GetDashboardTest()
        {
            string[] dashboard = service.GetDashboard();
            Assert.IsNotNull(dashboard);
            Assert.IsTrue(dashboard.Length > 0);
        }

        [TestMethod]
        public void RunApiIntegrationTest()
        {
            //clean up in case these tests get our of sync
            DeleteUser(user, email, password);

            ProcessUserRegistrationTest();                          
            string token = ProcessUserTest();                      
            UpsertBucketListItemTest(token, "list item name");                    
            string dbIdStr = GetBucketListItemsTest(token, "list item name", "");
            UpsertBucketListItemTest(token, "list item name 2", dbIdStr);
            GetBucketListItemsTest(token, "list item name 2", dbIdStr);                        
            UpsertBucketListItemV2Test(token, "list item name 3", dbIdStr);
            GetBucketListItemsV2Test(token, "list item name 3", dbIdStr);
            DeleteBucketListItemTest(token, dbIdStr);
            DeleteUser(user, email, password);
        }

        private void ProcessUserRegistrationTest()
        {
            bool result = service.ProcessUserRegistration
            (
                Utilities.EncodeClientBase64String(user),
                Utilities.EncodeClientBase64String(email),
                Utilities.EncodeClientBase64String(password)
            );

            Assert.IsTrue(result);
        }
        private string ProcessUserTest()
        {
            string token = service.ProcessUser
            (
                Utilities.EncodeClientBase64String(user),
                Utilities.EncodeClientBase64String(password)
            );
            Assert.IsNotNull(token);

            return token;
        }
        private void UpsertBucketListItemTest(string token, string listItemName, string dbIdStr = "")
        {
            string singleLineBucketListItem = TestUtilities.GetBucketListItemSingleString(user, listItemName, dbIdStr, false);

            var result = service.UpsertBucketListItem
            (
                Utilities.EncodeClientBase64String(singleLineBucketListItem),
                Utilities.EncodeClientBase64String(user),
                Utilities.EncodeClientBase64String(token)
            );

            Assert.IsNotNull(result);
            Assert.IsTrue(result[0] == "TokenValid");
        }
        private string GetBucketListItemsTest(string token, string expectedListItemName, string dbIdStr)
        {
            var bucketListItem = service.GetBucketListItems
            (
                Utilities.EncodeClientBase64String(user),
                Utilities.EncodeClientBase64String(""),
                Utilities.EncodeClientBase64String(token)
            );

            Assert.IsNotNull(bucketListItem);
            Assert.IsTrue(bucketListItem[0].IndexOf(expectedListItemName) != -1);

            if (!string.IsNullOrEmpty(dbIdStr))
            {
                Assert.IsTrue(bucketListItem[0].IndexOf(dbIdStr) != -1);
            }

            return TestUtilities.GetBucketListItemDbId(bucketListItem[0]);
        }
        private void UpsertBucketListItemV2Test(string token, string listItemName, string dbIdStr)
        {
            string singleLineBucketListItem = TestUtilities.GetBucketListItemSingleString(user, listItemName, dbIdStr, true);

            var result = service.UpsertBucketListItemV2
             (
                 Utilities.EncodeClientBase64String(singleLineBucketListItem),
                 Utilities.EncodeClientBase64String(user),
                 Utilities.EncodeClientBase64String(token)
             );

            Assert.IsNotNull(result);
            Assert.IsTrue(result[0] == "TokenValid");
        }
        private void GetBucketListItemsV2Test(string token, string listItemName, string dbIdStr)
        {
            var bucketListItem = service.GetBucketListItemsV2
             (
                 Utilities.EncodeClientBase64String(user),
                 Utilities.EncodeClientBase64String(""),
                 Utilities.EncodeClientBase64String(token)
             );

            Assert.IsNotNull(bucketListItem);
            Assert.IsTrue(bucketListItem[0].IndexOf(listItemName) != -1);
            Assert.IsTrue(bucketListItem[0].IndexOf(dbIdStr) != -1);
        }
        private void DeleteBucketListItemTest(string token, string dbId)
        {
            var result = service.DeleteBucketListItem
             (
                 Convert.ToInt32(dbId),
                 Utilities.EncodeClientBase64String(user),
                 Utilities.EncodeClientBase64String(token)
             );

            Assert.IsNotNull(result);
            Assert.IsTrue(result[0] == "TokenValid");
        }
    }
}
