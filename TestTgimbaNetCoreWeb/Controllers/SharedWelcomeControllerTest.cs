using Microsoft.VisualStudio.TestTools.UnitTesting;
using TgimbaNetCoreWebShared.Controllers;
using TgimbaNetCoreWebShared.Models;
using Microsoft.AspNetCore.Mvc;

namespace TestTgimbaNetCoreWeb
{
    [TestClass]
    public class SharedWelcomeControllerTest : BaseTest
    {
		[TestMethod]
		public void TestSharedWelcomeControllerIndex()
		{
			SharedWelcomeController welcomeController = new SharedWelcomeController(
				this.mockITgimbaService.Object, 
				this.mockWebClient.Object
			);

			IActionResult result = welcomeController.Index();
			ViewResult view = (ViewResult)result;

			Assert.IsNotNull(view);
			Assert.IsNotNull(view.Model);

			SharedWelcomeModel model = (SharedWelcomeModel)view.Model;

			Assert.IsNotNull(model.DashboardData);
			Assert.IsTrue(model.DashboardData.Length > 0);
		}
	}
}
