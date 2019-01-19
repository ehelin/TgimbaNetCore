using Microsoft.VisualStudio.TestTools.UnitTesting;
using TgimbaNetCoreWebShared.Controllers;  
using TestsAPIIntegration;	

namespace TestTgimbaNetCoreWeb
{
    [TestClass]
    public class SharedBucketListControllerTests : BaseTest
    {			  		
		[TestMethod]
		public void TestSharedBucketListController_AddBucketListItem_GoodParameters()
		{						
			var bucketListItem = TestUtilities.GetBucketListItemModel("base64EncodedGoodUser", "newBucketListItem", null, true);
			var itemAdded =  GetController().AddBucketListItem(bucketListItem, "base64EncodedGoodUser", "base64EncodedGoodToken");

			Assert.IsTrue(itemAdded);					 
		}
		
		[TestMethod]
		public void TestSharedBucketListController_AddBucketListItem_BadParameters()
		{
			var itemAdded =  GetController().AddBucketListItem(null, "base64EncodedBadUser", "base64EncodedBadToken");

			Assert.IsFalse(itemAdded);	
		}

		// TODO - add a test for multiple items
		[TestMethod]
		public void TestSharedBucketListController_GetBucketListItems_GoodParameters()
		{													  
			var bucketListItems =  GetController().GetBucketListItems("base64EncodedGoodUser", 
																	  "base64EncodedGoodSortString", 
																      "base64EncodedGoodToken");

			Assert.IsNotNull(bucketListItems);
			Assert.AreEqual(1, bucketListItems.Count);
		}

		[TestMethod]
		public void TestSharedBucketListController_GetBucketListItems_BadParameters()
		{													  
			var bucketListItems =  GetController().GetBucketListItems("base64EncodedBadUser", 
																	  "base64EncodedBadSortString", 
																      "base64EncodedBadToken");

			Assert.IsNull(bucketListItems);				
		}
				 
		private SharedBucketListController GetController() {												
			SharedBucketListController controller = new SharedBucketListController(
				this.mockITgimbaService.Object, 
				this.mockWebClient.Object
			);

			return controller;
		}
	}
}
