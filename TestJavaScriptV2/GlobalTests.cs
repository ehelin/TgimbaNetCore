using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace TestJavaScriptV2
{
    [TestClass]
    public class GlobalTests : BaseTest
    {   
        [TestMethod]
		[Ignore]
        public void Test_Global_Init_SetView()
        {
            var script = CreateJsTestScript(@"..\..\..\..\TgimbaNetCoreWeb\wwwroot\Scripts\HtmlVanillaJs\Global.js");
           
            script.AppendBlock(@"
                                function SetView() {
                                    return true;
                                }
                              ");

            var rawResult = script.RunTest(@"return Init();");
            var result = JsonConvert.DeserializeObject(rawResult);

            Assert.IsTrue(Convert.ToBoolean(result));
            script = null;
        }
    }
}
