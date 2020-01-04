using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TgimbaNetCoreWebShared.Controllers;
using TgimbaNetCoreWebShared.Models;

namespace TestTgimbaNetCoreWeb
{
    [TestClass]
    public class SharedWelcomeControllerTest : BaseTest
    {
        [TestMethod]
        [Ignore]
        public void TestSharedWelcomeControllerIndex()
        {
            SharedWelcomeController welcomeController = new SharedWelcomeController(this.mockWebClient.Object);

            IActionResult result = welcomeController.Index();
            ViewResult view = (ViewResult)result;

            Assert.IsNotNull(view);
            Assert.IsNotNull(view.Model);

            SharedWelcomeModel model = (SharedWelcomeModel)view.Model;

            // TODO - revisit this test...still relevant?
            Assert.IsNotNull(model);
        }
    }
}
