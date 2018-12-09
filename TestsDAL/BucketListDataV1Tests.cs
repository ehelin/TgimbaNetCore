using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestsDAL
{
    [TestClass]
    public class BucketListDataV1Tests : BaseTest
    {
        protected string userName = "bucketListDbanAwesomeUser";
        protected string email = "bucketListDbanAwesomeUser@test.com";
        protected string password = "bucketListDbanAwesomePassword";

        public BucketListDataV1Tests() : base() { }

        [TestMethod]
        public void RunBucketListDataV1Tests()
        {
            GetDashboardTest();

            AddUser(userName, email, password);
            var bucketListItems = GetBucketListItem(userName);

            var savedBucketListItems = UpsertBucketListItemTest(bucketListItems, userName);
      
            DeleteBucketListItemTest(savedBucketListItems, userName);

            mdb.DeleteUser(userName, password, email);
        }

        private void GetDashboardTest()
        {
            var dashboard = bdb.GetDashboard();

            Assert.IsNotNull(dashboard);
            Assert.IsTrue(dashboard.Length > 0);
        }
        private string[] UpsertTest(string[] bucketListItems, string userName)
        {
            bdb.UpsertBucketListItem(bucketListItems);
            var savedBucketListItems = bdb.GetBucketList(userName, "");
            var listItemName = bucketListItems[0];
            int pos = savedBucketListItems[0].IndexOf(listItemName);
            Assert.IsTrue(pos != -1);

            return savedBucketListItems;
        }
        private string[] UpsertBucketListItemTest(string[] bucketListItems, string userName)
        {
            var savedBucketListItem = UpsertTest(bucketListItems, userName);

            int pos = savedBucketListItem[0].LastIndexOf(',');
            string dbIdStr = savedBucketListItem[0].Substring(pos + 1, savedBucketListItem[0].Length - (pos + 1));
            bucketListItems[0] = "A new list item name";
            bucketListItems[4] = dbIdStr;

            var savedBucketListItems = UpsertTest(bucketListItems, userName);

            return savedBucketListItems;
        }
        private void DeleteBucketListItemTest(string[] bucketListItems, string userName)
        {
            foreach (string bucketListItem in bucketListItems)
            {
                int pos = bucketListItem.LastIndexOf(',');
                string dbIdStr = bucketListItem.Substring(pos+1, bucketListItem.Length - (pos+1));
                int dbId = Int32.Parse(dbIdStr);

                bdb.DeleteBucketListItem(dbId);
            }

            var savedBucketListItems = bdb.GetBucketList(userName, "");
            Assert.AreEqual(savedBucketListItems[0], "No Items");
        }
    }
}
