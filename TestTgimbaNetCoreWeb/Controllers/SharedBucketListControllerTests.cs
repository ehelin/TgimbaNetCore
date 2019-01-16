using Microsoft.VisualStudio.TestTools.UnitTesting;
using TgimbaNetCoreWebShared.Controllers;
using Microsoft.AspNetCore.Mvc;
using Shared.interfaces;

namespace TestTgimbaNetCoreWeb
{
    [TestClass]
    public class SharedBucketListControllerTests : BaseTest
    {			  		
		[TestMethod]
		public void TestSharedBucketListController_AddGoodBucketListItem()
		{
			var bucketListController =  GetController();
	
			//string token = bucketListController.Login("badUser", "badPass");
									  
			//Assert.AreEqual("", token);
		}

		[TestMethod]
		public void TestSharedBucketListController_GetBucketListItems()
		{													  
			var bucketListController =  GetController();
	
			//string token = bucketListController.Login("badUser", "badPass");
									  
			//Assert.AreEqual("", token);
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
