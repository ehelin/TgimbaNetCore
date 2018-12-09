using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestsDAL
{
    [TestClass]
    public class BucketListDataV2Tests : BucketListDataV1Tests
    {
        public BucketListDataV2Tests() : base() { }

        [TestMethod]
        public void RunBucketListDataV2Tests()
        {
            AddUser(userName, email, password);

            var bucketListItems = GetBucketListItem(userName, "", "", true);

            var savedBucketListItems = UpsertGetBucketListItemV2Test(bucketListItems);

            int pos = savedBucketListItems[0].LastIndexOf(',');
            string dbIdStr = savedBucketListItems[0].Substring(pos + 1, savedBucketListItems[0].Length - (pos + 1));
            int dbId = Int32.Parse(dbIdStr);

            bdb.DeleteBucketListItem(dbId);
            mdb.DeleteUser(userName, password, email);
        }

        private string[] UpsertTest(string[] bucketListItems)
        {
            bdb.UpsertBucketListItemV2(bucketListItems);
            var savedBucketListItems = bdb.GetBucketListV2(userName, "");
            var listItemName = bucketListItems[0];
            int pos = savedBucketListItems[0].IndexOf(listItemName);
            Assert.IsTrue(pos != -1);

            return savedBucketListItems;
        }
        private string[] UpsertGetBucketListItemV2Test(string[] bucketListItems)
        {
            var savedBucketListItems = UpsertTest(bucketListItems);

            bucketListItems[0] = "an updated list item name";
            bucketListItems[6] = GetBucketListItemDbId(savedBucketListItems[0]);

            savedBucketListItems = UpsertTest(bucketListItems);

            return savedBucketListItems;
        }
    }
}
