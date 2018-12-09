using Microsoft.VisualStudio.TestTools.UnitTesting;
using TgimbaNetCoreWebShared.Controllers;
using Microsoft.AspNetCore.Mvc;
using Shared.interfaces;

namespace TestTgimbaNetCoreWeb
{
    [TestClass]
    public class SharedHomeControllerTest : BaseTest
    {
		[TestMethod]
		public void TestSharedHomeController_GoodRegistration()
		{
			var homeController =  GetController();
	
			bool goodRegistration = homeController.Registration("goodUser", "goodEmail", "goodPass");
									  
			Assert.AreEqual(true, goodRegistration);
		}

		[TestMethod]
		public void TestSharedHomeController_BadRegistration()
		{
			var homeController =  GetController();
	
			bool goodRegistration = homeController.Registration("badUser", "badEmail", "badPass");
									  
			Assert.AreEqual(false, goodRegistration);
		}

		[TestMethod]
		public void TestSharedHomeController_GoodLogin()
		{
			var homeController =  GetController();
	
			string token = homeController.Login("goodUser", "goodPass");
									  
			Assert.AreEqual("token", token);
		}

		[TestMethod]
		public void TestSharedHomeController_BadLogin()
		{
			var homeController =  GetController();
	
			string token = homeController.Login("badUser", "badPass");
									  
			Assert.AreEqual("", token);
		}

		private SharedHomeController GetController() {
			SharedHomeController homeController = new SharedHomeController(
				this.mockITgimbaService.Object, 
				this.mockWebClient.Object
			);

			return homeController;
		}
	}
}
