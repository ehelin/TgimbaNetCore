using System.Linq;
using DALNetCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.interfaces;
using Shared.misc;
using Shared.exceptions;

namespace TestDALNetCore_Integration
{
    [TestClass]
    public class BucketListTests : BaseTest
    {
        [TestMethod]
        public void BucketListItem_HappyPath_Test()
        {
            // set up ------------------------------------------------------
            RemoveTestUser();
            
            var user = GetUser("token");
            IBucketListData bd = new BucketListData(this.GetDbContext(), this.userHelper);
            var bucketListItemToSave = GetBucketListItem();

            // test ---------------------------------------------------------
            var userId = bd.AddUser(user);
            bd.UpsertBucketListItem(bucketListItemToSave, user.UserName);
            var savedBucketListItem = bd.GetBucketList(user.UserName, null).FirstOrDefault();
            
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
            var savedBucketListItemUpdated = bd.GetBucketList(user.UserName, null).FirstOrDefault();
            Assert.AreEqual(savedBucketListItem.Name, savedBucketListItemUpdated.Name);

            // we can delete the bucket list item
            bd.DeleteBucketListItem(savedBucketListItemUpdated.Id.Value);
            var deletedBucketListItem = bd.GetBucketList(user.UserName, null).FirstOrDefault();
            Assert.IsNotNull(savedBucketListItem);

            //clean up user
            bd.DeleteUser(userId);
        }

        [TestMethod]
        public void BucketListItem_Sort_HappyPath_Test()
        {
            // set up ------------------------------------------------------
            RemoveTestUser();

            var user = GetUser("token");
            IBucketListData bd = new BucketListData(this.GetDbContext(), this.userHelper);

            var userId = bd.AddUser(user);
            bd.UpsertBucketListItem(GetBucketListItem("Bucket List Item 1"), user.UserName);
            bd.UpsertBucketListItem(GetBucketListItem("Bucket List Item 2"), user.UserName);
            bd.UpsertBucketListItem(GetBucketListItem("Bucket List Item 3"), user.UserName);

            // test ---------------------------------------------------------
            //asc 
            var savedBucketListItems = bd.GetBucketList(user.UserName, Enums.SortColumns.ListItemName, true, "");
            Assert.IsNotNull(savedBucketListItems);
            Assert.AreEqual(savedBucketListItems.FirstOrDefault().Name, "Bucket List Item 1");

            if (savedBucketListItems != null && savedBucketListItems.Count > 0 )
            {
                savedBucketListItems.Clear();
                savedBucketListItems = null;
            }

            //desc 
            savedBucketListItems = bd.GetBucketList(user.UserName, Enums.SortColumns.ListItemName, false, "");
            Assert.IsNotNull(savedBucketListItems);
            Assert.AreEqual(savedBucketListItems.FirstOrDefault().Name, "Bucket List Item 3");

            //clean up
            foreach(var savedBucketListItem in savedBucketListItems) 
            {
                bd.DeleteBucketListItem(savedBucketListItem.Id.Value);
            }
            bd.DeleteUser(userId);
        }
        
        [TestMethod]
        public void BucketListItem_Search_HappyPath_Test()
        {
            // set up ------------------------------------------------------
            RemoveTestUser();

            var user = GetUser("token");
            IBucketListData bd = new BucketListData(this.GetDbContext(), this.userHelper);

            var userId = bd.AddUser(user);
            bd.UpsertBucketListItem(GetBucketListItem("African Safari"), user.UserName);
            bd.UpsertBucketListItem(GetBucketListItem("Fly Paris"), user.UserName);
            bd.UpsertBucketListItem(GetBucketListItem("Sky diving"), user.UserName);

            // test ---------------------------------------------------------
            //asc 
            var savedBucketListItems = bd.GetBucketList(user.UserName, null, true, "Safari");
            Assert.IsNotNull(savedBucketListItems);
            Assert.IsNotNull(savedBucketListItems.Count == 1);
            Assert.AreEqual(savedBucketListItems.FirstOrDefault().Name, "African Safari");

            //clean up
            foreach (var savedBucketListItem in savedBucketListItems)
            {
                bd.DeleteBucketListItem(savedBucketListItem.Id.Value);
            }
            bd.DeleteUser(userId);
        }
        
        [TestMethod]
        [ExpectedException(typeof(RecordDoesNotExistException))]
        public void BucketListItem_AddBucketListItem_UserDoesNotExist_Test()
        {
            // set up ------------------------------------------------------
            RemoveTestUser();

            IBucketListData bd = new BucketListData(this.GetDbContext(), this.userHelper);
            var bucketListItemToSave = GetBucketListItem();

            // test ---------------------------------------------------------
            bd.UpsertBucketListItem(bucketListItemToSave, "NonExistantUser");
           
            // NOTE: RecordDoesNotExistException is expected
        }

        [TestMethod]
        [ExpectedException(typeof(RecordDoesNotExistException))]
        public void BucketListItem_DeleteBucketListItem_UserDoesNotExist_Test()
        {
            // set up ------------------------------------------------------
            RemoveTestUser();

            IBucketListData bd = new BucketListData(this.GetDbContext(), this.userHelper);

            // test ---------------------------------------------------------
            var nonExistantBucketListItemId = -12412;
            bd.DeleteBucketListItem(nonExistantBucketListItemId);

            // NOTE: RecordDoesNotExistException is expected
        }
    }
}
