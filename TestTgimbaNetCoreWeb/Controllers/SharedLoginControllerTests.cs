using Microsoft.VisualStudio.TestTools.UnitTesting;
using TgimbaNetCoreWebShared;
using TgimbaNetCoreWebShared.Controllers;

namespace TestTgimbaNetCoreWeb
{
    [TestClass]
    public class SharedLoginControllerTests : BaseTest
    {
        [TestMethod]
        public void TestSharedLoginController_GoodLogin()
        {
            var homeController = GetController();

            string token = homeController.Login("base64EncodedGoodUser", "base64EncodedGoodPass");

            Assert.AreEqual("token", token);
        }

        [TestMethod]
        public void TestSharedLoginController_BadLogin()
        {
            var homeController = GetController();

            string token = homeController.Login("base64EncodedBadUser", "base64EncodedBadPass");

            Assert.AreEqual("", token);
        }

        private SharedLoginController GetController()
        {
            SharedLoginController controller = new SharedLoginController(new WebClient("https://api.tgimba.com"));

            return controller;
        }
    }
}
