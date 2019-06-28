using Microsoft.VisualStudio.TestTools.UnitTesting;
using TgimbaNetCoreWebShared.Models;  

namespace TestTgimbaNetCoreWeb
{
	[TestClass]
	public class WelcomeModelTest : BaseTest
	{
		[TestMethod]
        [Ignore]
		public void TestWelcomeModel()
		{
			SharedWelcomeModel welcomeModel = new SharedWelcomeModel(this.mockITgimbaService.Object);

			Assert.IsNotNull(welcomeModel);
			//Assert.IsNotNull(welcomeModel.DashboardData);
			//Assert.IsTrue(welcomeModel.DashboardData.Length > 0);
		}
	}
}
