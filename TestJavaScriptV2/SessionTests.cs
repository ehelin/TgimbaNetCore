using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JSTest;                      
using Newtonsoft.Json;

namespace TestJavaScriptV2
{
    [TestClass]
    public class SessionTests : BaseTest
    {
        [TestMethod]
        public void Test_Session_SessionSetToken_SessionGetToken()
        {
            var script = SetUpScript();
            string test = @"
                            SessionSetToken('key', 'value');
                            return SessionGetToken('key');
                        ";

            var rawResult = script.RunTest(test);
            var result = JsonConvert.DeserializeObject(rawResult);

            Assert.AreEqual(result, "value");
            script = null;
        }

        [TestMethod]	
        public void Test_Session_SessionClearStorage()
        {
            var script = SetUpScript();	  
            script.AppendFile(@"..\..\..\..\TgimbaNetCoreWeb\wwwroot\Scripts\Common\Constants.js");
            string test = @"
                            SessionSetToken('key', 'value');
                            SessionClearStorage();
                            return SessionGetToken('key');
                        ";

            var rawResult = script.RunTest(test);
            var result = JsonConvert.DeserializeObject(rawResult);

            Assert.AreEqual(result, null);
            script = null;
        }
        
        private TestScript SetUpScript()
        {
            var script = CreateJsTestScript(@"..\..\..\..\TgimbaNetCoreWeb\wwwroot\Scripts\Common\Session.js");
            script.AppendBlock(GetSessionMock());

            return script;
        }

        private string GetSessionMock()
        {
            string sessionJsMock = (@"
                                    var sessionStorage = {
                                        session: null,
                                        setItem: function(key, value) {
                                            this.session[key] = value;
                                        },
                                        getItem: function(key) {
                                            return this.session[key];
                                        },
                                        clear: function() {
                                            this.session = [];
                                        }
                                    };    

                                    sessionStorage.session = [];
                                 ");

            return sessionJsMock;
        }
    }
}
