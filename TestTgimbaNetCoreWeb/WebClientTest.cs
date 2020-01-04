using Microsoft.VisualStudio.TestTools.UnitTesting;
using TgimbaNetCoreWebShared;
//using TestsAPIIntegration;							  

namespace TestTgimbaNetCoreWeb
{
    [TestClass]
    public class WebClientTest : BaseTest
    {			 																				   
		[TestMethod]
		public void Test_GoodRegistration()
		{				
			bool goodRegistration = GetWebClient().Registration("base64EncodedGoodUser", "base64EncodedGoodEmail", "base64EncodedGoodPass");
							  
			Assert.AreEqual(true, goodRegistration);
		}

		[TestMethod]
		public void Test_BadRegistration()
		{
			bool goodRegistration = GetWebClient().Registration("base64EncodedBadUser", "base64EncodedBadEmail", "base64EncodedBadPass");
									  
			Assert.AreEqual(false, goodRegistration);
		}

		[TestMethod]
		public void Test_GoodLogin()
		{
			string token = GetWebClient().Login("base64EncodedGoodUser", "base64EncodedGoodPass");
									  
			Assert.AreEqual("token", token);
		}

		[TestMethod]
		public void Test_BadLogin()
		{
			string token = GetWebClient().Login("base64EncodedBadUser", "base64EncodedBadPass");
									  
			Assert.AreEqual("", token);
		}

		[TestMethod]
		public void Test_GoodAddBucketListItem()
		{						   																							  
			var bucketListItemModel = TestUtilities.GetBucketListItemModel("base64EncodedGoodUser", "newBucketListItem", null, true);
			
			var bucketListAdded = GetWebClient().AddBucketListItem(bucketListItemModel, "base64EncodedGoodUser", "base64EncodedGoodToken");
	   
			Assert.IsTrue(bucketListAdded);
		}	

		[TestMethod]
		public void Test_BadAddBucketListItem()
		{		  																												  
			var bucketListItemModel = TestUtilities.GetBucketListItemModel("base64EncodedGoodUser", "newBucketListItem", null, true);
			
			var bucketListAdded = GetWebClient().AddBucketListItem(bucketListItemModel, "base64EncodedBadUser", null);
	   
			Assert.IsFalse(bucketListAdded);
		}
										   
		[TestMethod]
		public void Test_GoodEditBucketListItem()
		{						   																										 
			var bucketListItemModel = TestUtilities.GetBucketListItemModel("base64EncodedGoodUser", "editedBucketListItem", "123", true); 			
			var bucketListAdded = GetWebClient().EditBucketListItem(bucketListItemModel, "base64EncodedGoodUser", "base64EncodedGoodToken");
	   
			Assert.IsTrue(bucketListAdded);
		}	

		[TestMethod]
		public void Test_BadEditBucketListItem()
		{		  																												  
			var bucketListItemModel = TestUtilities.GetBucketListItemModel("base64EncodedGoodUser", "newBucketListItem", null, true);  			
			var bucketListAdded = GetWebClient().EditBucketListItem(bucketListItemModel, "base64EncodedBadUser", null);
	   
			Assert.IsFalse(bucketListAdded);
		}									

		[TestMethod]
		public void Test_GoodGetBucketListItems()
		{
			var user = Shared.misc.Utilities.EncodeClientBase64String("base64EncodedGoodUser");
			var bucketListItem = GetWebClient().GetBucketListItems(user, 
																	"base64EncodedGoodSortString", 
																	"base64EncodedGoodToken", 
																	"base64EncodedGoodSrchTerm");
	   
			Assert.IsNotNull(bucketListItem); 			
			Assert.AreEqual("newBucketListItem", bucketListItem[0].Name);
		}

		[TestMethod]
		public void Test_BadGetBucketListItems()
		{							
			var bucketItemList = GetWebClient().GetBucketListItems("", "", "");
	   
			Assert.IsNull(bucketItemList); 									   
		}		
		
		private IWebClient GetWebClient() {
			IWebClient webClient = new WebClient("https://api.tgimba.com");

			return webClient;
		}		 
    }
}
