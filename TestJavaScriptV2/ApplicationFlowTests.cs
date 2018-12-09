using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;    
using Newtonsoft.Json;

namespace TestJavaScriptV2
{
    [TestClass]
    public class ApplicationFlowTests : BaseTest
    {
        [TestMethod]			
		[Ignore]
        public void Test_ApplicationFlow_SetView_LoggedIn_LoggedInScreen()
        {
            var script = CreateJsTestScript(@"..\..\..\..\TgimbaNetCoreWeb\wwwroot\Scripts\Common\ApplicationFlow.js");

            script.AppendFile(@"..\..\..\..\TgimbaNetCoreWeb\wwwroot\Scripts\Common\Constants.js");
            script.AppendBlock(GetSessionMock());

            script.AppendBlock(@" 
                                 function Login_Index() { return null; }
                                 function IsLoggedIn() { return false; }
                                ");

            string test = @"
                            SessionSetToken(SESSION_TOKEN, 'value');
                            return SetView();
                            ";
            var rawResult = script.RunTest(test);
            var result = JsonConvert.DeserializeObject(rawResult);

            Assert.AreEqual(result, null);
            script = null;
        }

        [TestMethod]	  
		[Ignore]
        public void Test_ApplicationFlow_SetView_WelcomeView()
        {                                                            
            var script = CreateJsTestScript(@"..\..\..\..\TgimbaNetCoreWeb\wwwroot\Scripts\Common\ApplicationFlow.js");
            script.AppendFile(@"..\..\..\..\TgimbaNetCoreWeb\wwwroot\Scripts\Common\Constants.js");

            script.AppendBlock(@" 
                                function GetHost() {
                                    return 'http://localhost:60398';
                                }

                                function IsLoggedIn() { return false; }

                                var window = {
                                    location: {
                                        replace: function(url) {
                                            return url;
                                        }
                                    } 
                                }
                               ");
                                                    
            var rawResult = script.RunTest(@"return SetView(VIEW_WELCOME);");
            var result = JsonConvert.DeserializeObject(rawResult);

            Assert.AreEqual(result, "http://localhost:60398/Welcome/Index");
            script = null;
        }

        [TestMethod]  
		[Ignore]
        public void Test_ApplicationFlow_SetView_NotLoggedIn_LoginScreen()
        {
            var script = CreateJsTestScript(@"..\..\..\..\TgimbaNetCoreWeb\wwwroot\Scripts\Common\ApplicationFlow.js");
            script.AppendFile(@"..\..\..\..\TgimbaNetCoreWeb\wwwroot\Scripts\Common\Constants.js");
            script.AppendBlock(@" 
                                function IsLoggedIn() { return false; }

                                var window = {
                                    location: {
                                        replace: function(url) {
                                            return url;
                                        }
                                    } 
                                }
        
                                function Login_Index() { return true; }
                               ");
            var rawResult = script.RunTest(@"return SetView();");
            var result = JsonConvert.DeserializeObject(rawResult);

            Assert.IsTrue(Convert.ToBoolean(result));
            script = null;
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

                                    function SessionSetToken(key, value) {
                                        sessionStorage.setItem(key, value);
                                    }
                                    function SessionGetToken(key) {    
                                        var val = sessionStorage.getItem(key);
                                        return val;
                                    }            
                               ");

            return sessionJsMock;
        }
    }
}
