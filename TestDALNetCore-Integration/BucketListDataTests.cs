using System.Linq;
using DALNetCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.interfaces;

namespace TestDALNetCore_Integration
{
    [TestClass]
    public class BucketListTests : BaseTest
    {
        // TODO Error Tests to add
        // - Unknown Sort Error
        // - Bucket list Delete Item not found
        // - Bucket list user Delete Item not found

        [TestMethod]
        public void BucketListItemHappyPath_Test()
        {
            // set up ------------------------------------------------------
            var user = GetUser("token");
            var dbContext = new BucketListContext();
            IBucketListData bd = new BucketListData(dbContext);
            var bucketListItemToSave = GetBucketListItem();

            // test ---------------------------------------------------------
            var userId = bd.AddUser(user);
            bd.UpsertBucketListItem(bucketListItemToSave, user.UserName);
            var savedBucketListItem = bd.GetBucketList(user.UserName, "").FirstOrDefault();
            
            // we have a saved object that object matches our created object
            Assert.IsNotNull(savedBucketListItem);
            Assert.AreEqual(bucketListItemToSave.Name, savedBucketListItem.Name);
            Assert.AreEqual(bucketListItemToSave.Created, savedBucketListItem.Created);
            Assert.AreEqual(bucketListItemToSave.Category, savedBucketListItem.Category);
            Assert.AreEqual(bucketListItemToSave.Achieved, savedBucketListItem.Achieved);
            Assert.AreEqual(bucketListItemToSave.Latitude, savedBucketListItem.Latitude);
            Assert.AreEqual(bucketListItemToSave.Longitude, savedBucketListItem.Longitude);

            // we can update that object and save it
            // TODO - upsert update part not working...fix
            savedBucketListItem.Name = savedBucketListItem.Name + " modified";
            bd.UpsertBucketListItem(savedBucketListItem, user.UserName);
            var savedBucketListItemUpdated = bd.GetBucketList(user.UserName, "").FirstOrDefault();
            Assert.AreEqual(savedBucketListItem.Name, savedBucketListItemUpdated.Name);

            // we can delete the bucket list item
            bd.DeleteBucketListItem(savedBucketListItemUpdated.Id);
            var deletedBucketListItem = bd.GetBucketList(user.UserName, "").FirstOrDefault();
            Assert.IsNotNull(savedBucketListItem);

            //clean up user
            bd.DeleteUser(userId);
        }

        [TestMethod]
        public void BucketListItemSortHappyPath_Test()
        {
            // set up ------------------------------------------------------
            var user = GetUser("token");
            var dbContext = new BucketListContext();
            IBucketListData bd = new BucketListData(dbContext);

            var userId = bd.AddUser(user);
            bd.UpsertBucketListItem(GetBucketListItem("Bucket List Item 1"), user.UserName);
            bd.UpsertBucketListItem(GetBucketListItem("Bucket List Item 2"), user.UserName);
            bd.UpsertBucketListItem(GetBucketListItem("Bucket List Item 3"), user.UserName);

            // test ---------------------------------------------------------
            //asc 
            var savedBucketListItems = bd.GetBucketList(user.UserName, "ListItemName", true, "");
            Assert.IsNotNull(savedBucketListItems);
            Assert.AreEqual(savedBucketListItems.FirstOrDefault().Name, "Bucket List Item 1");

            if (savedBucketListItems != null && savedBucketListItems.Count > 0 )
            {
                savedBucketListItems.Clear();
                savedBucketListItems = null;
            }

            //desc 
            savedBucketListItems = bd.GetBucketList(user.UserName, "ListItemName", false, "");
            Assert.IsNotNull(savedBucketListItems);
            Assert.AreEqual(savedBucketListItems.FirstOrDefault().Name, "Bucket List Item 3");

            //clean up
            foreach(var savedBucketListItem in savedBucketListItems) 
            {
                bd.DeleteBucketListItem(savedBucketListItem.Id);
            }
            bd.DeleteUser(userId);
        }
        
        [TestMethod]
        public void BucketListItemSearchHappyPath_Test()
        {
            // set up ------------------------------------------------------
            var user = GetUser("token");
            var dbContext = new BucketListContext();
            IBucketListData bd = new BucketListData(dbContext);

            var userId = bd.AddUser(user);
            bd.UpsertBucketListItem(GetBucketListItem("African Safari"), user.UserName);
            bd.UpsertBucketListItem(GetBucketListItem("Fly Paris"), user.UserName);
            bd.UpsertBucketListItem(GetBucketListItem("Sky diving"), user.UserName);

            // test ---------------------------------------------------------
            //asc 
            var savedBucketListItems = bd.GetBucketList(user.UserName, "", true, "Safari");
            Assert.IsNotNull(savedBucketListItems);
            Assert.IsNotNull(savedBucketListItems.Count == 1);
            Assert.AreEqual(savedBucketListItems.FirstOrDefault().Name, "African Safari");

            //clean up
            foreach (var savedBucketListItem in savedBucketListItems)
            {
                bd.DeleteBucketListItem(savedBucketListItem.Id);
            }
            bd.DeleteUser(userId);
        }
    }
}
