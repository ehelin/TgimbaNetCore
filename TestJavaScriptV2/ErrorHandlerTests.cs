using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JSTest;
using JSTest.ScriptElements;
using JSTest.ScriptLibraries;

namespace TestJavaScriptV2
{
    [TestClass]
    public class ErrorHandlerTests : BaseTest
    {
        [TestMethod]
        public void Test_ErrorHandler_ThrowsError()
        {
            var script = CreateJsTestScript(@"..\..\..\..\TgimbaNetCoreWeb\wwwroot\Scripts\HtmlVanillaJs\ErrorHandler.js");

            Assert.IsTrue(TestErrorThrow(script, @" Error('error')"));
            script = null;
        }
    }
}
