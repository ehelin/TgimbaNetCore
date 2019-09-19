using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace TestAPINetCore_Unit
{
    [TestClass]
    public class MiscTests : BaseTest
    {
        [TestMethod]
        public void Log_HappyPathTest()
        {
            var msg = "I am a message";
            this.service.Log(msg);
            this.mockBucketListData.Verify(x => x.LogMsg(It.Is<string>(s => s.Contains(msg))), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Log_NullMessageTest()
        {
            string msg = null;
            this.service.Log(msg);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Log_EmptyMessageTest()
        {
            var msg = "";
            this.service.Log(msg);
        }
    }
}
