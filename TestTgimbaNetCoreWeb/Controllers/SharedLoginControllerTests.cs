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

            Assert.AreEqual(null, token);
        }

        private SharedLoginController GetController()
        {
            SharedLoginController controller = new SharedLoginController(mockWebClient.Object);

            return controller;
        }
    }
}
