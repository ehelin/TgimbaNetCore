using Microsoft.VisualStudio.TestTools.UnitTesting;
using HttpAPINetCore.Controllers;
using Moq;
using APINetCore;
using System.Net.Http;

namespace TestHttpAPINetCore_Unit
{
    [TestClass]
    public class MiscTests 
    {
        [TestMethod]
        [Ignore]
        public void Log_NullMessageTest()
        {
            var tgimbaService = new Mock<TgimbaService>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object);
            string msg = null;
            // TODO - test with httpclient to verify 400
            //tgimbaApi.Log(msg);
        }

        [TestMethod]
        [Ignore]
        public void Log_EmptyMessageTest()
        {
            var tgimbaService = new Mock<TgimbaService>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object);
            string msg = "";
            // TODO - test with httpclient to verify 400
            //tgimbaApi.Log(msg);
        }
    }
}
