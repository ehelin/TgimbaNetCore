using Microsoft.VisualStudio.TestTools.UnitTesting;
using TgimbaNetCoreWebShared.Controllers;
using TgimbaNetCoreWebShared;
using Microsoft.AspNetCore.Mvc;
using Shared.interfaces;

namespace TestTgimbaNetCoreWeb
{
    [TestClass]
    public class SharedRegistrationControllerTests : BaseTest
    {
		[TestMethod]
		public void TestSharedRegistrationController_GoodRegistration()
		{
			bool goodRegistration = GetController().Registration("base64EncodedGoodUser", "base64EncodedGoodEmail", "base64EncodedGoodPass");
									  
			Assert.AreEqual(true, goodRegistration);
		}

		[TestMethod]
		public void TestSharedRegistrationController_BadRegistration()
		{
			bool goodRegistration = GetController().Registration("base64EncodedBadUser", "base64EncodedBadEmail", "base64EncodedBadPass");
									  
			Assert.AreEqual(false, goodRegistration);
		}  
				 
		private SharedRegistrationController GetController() {												
			SharedRegistrationController controller = new SharedRegistrationController(
				this.mockITgimbaService.Object, 
				new WebClient(this.mockITgimbaService.Object)
			);

			return controller;
		}
	}
}
