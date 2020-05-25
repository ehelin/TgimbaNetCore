using System.Linq;
using DALNetCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.exceptions;
using Shared.interfaces;
using Shared.misc.testUtilities;

namespace TestDALNetCore_Integration
{
    [TestClass]
    public class BucketListTests : BaseTest
    {
        [TestCleanup]
        public void Cleanup()
        {
            TestUtilities.ClearEnvironmentalVariablesForIntegrationTests();
        }

        [TestInitialize]
        public void SetUp()
        {
            TestUtilities.SetEnvironmentalVariablesForIntegrationTests();
        }

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
            var savedBucketListItem = bd.GetBucketList(user.UserName).FirstOrDefault();
            
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
            var savedBucketListItemUpdated = bd.GetBucketList(user.UserName).FirstOrDefault();
            Assert.AreEqual(savedBucketListItem.Name, savedBucketListItemUpdated.Name);

            // we can delete the bucket list item
            bd.DeleteBucketListItem(savedBucketListItemUpdated.Id.Value);
            var deletedBucketListItem = bd.GetBucketList(user.UserName).FirstOrDefault();
            Assert.IsNotNull(savedBucketListItem);

            //clean up user
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
