using HttpAPINetCore.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shared.interfaces;

namespace TestHttpAPINetCore_Unit
{
    [TestClass]
    public class MiscTests 
    {
        [TestMethod]
        public void Log_HappyPathTest()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object);
            string msg = "I am a message";
            IActionResult result = tgimbaApi.Log(msg);
            OkResult requestResult = (OkResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(200, requestResult.StatusCode);
            tgimbaService.Verify(x => x.Log(It.Is<string>(s => s.Contains(msg))), Times.Once);
        }

        [TestMethod]
        public void Log_NullMessageTest()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object);
            string msg = null;
            IActionResult result = tgimbaApi.Log(msg);
            BadRequestResult requestResult = (BadRequestResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(400, requestResult.StatusCode);
        }

        [TestMethod]
        public void Log_EmptyMessageTest()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object);
            string msg = "";
            IActionResult result = tgimbaApi.Log(msg);
            BadRequestResult requestResult = (BadRequestResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(400, requestResult.StatusCode);
        }
    }
}
