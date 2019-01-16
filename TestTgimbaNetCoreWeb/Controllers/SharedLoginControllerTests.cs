using Microsoft.VisualStudio.TestTools.UnitTesting;
using TgimbaNetCoreWebShared.Controllers;
using TgimbaNetCoreWebShared;	

namespace TestTgimbaNetCoreWeb
{
    [TestClass]
    public class SharedLoginControllerTests : BaseTest
    {
		[TestMethod]
		public void TestSharedLoginController_GoodLogin()
		{
			var homeController =  GetController();
	
			string token = homeController.Login("base64EncodedGoodUser", "base64EncodedGoodPass");
									  
			Assert.AreEqual("token", token);
		}

		[TestMethod]
		public void TestSharedLoginController_BadLogin()
		{
			var homeController =  GetController();
	
			string token = homeController.Login("base64EncodedBadUser", "base64EncodedBadPass");
									  
			Assert.AreEqual("", token);
		}

		private SharedLoginController GetController() {												
			SharedLoginController controller = new SharedLoginController(
				this.mockITgimbaService.Object, 
				new WebClient(this.mockITgimbaService.Object)
			);

			return controller;
		}
	}
}
