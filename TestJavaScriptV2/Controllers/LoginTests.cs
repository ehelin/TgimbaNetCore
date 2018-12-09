using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JSTest;                   
using Newtonsoft.Json;

namespace TestJavaScriptV2
{
    [TestClass]
    public class LoginTests : BaseTest
    {
        [TestMethod]   
		[Ignore]
        public void Test_Login_Login_Login_HappyPath()
        {
            var script = SetUpScript();

            script.AppendBlock(@"
                                 function HasValue(ctrlId, type)  { return true; }
                                 function SetToken(view, params) {   
                                    if (view == '/Home/Login' && params.length == 2) { return true; }
                                    return false;
                                 }             
                                 var textBox = { value: 'a value' };
                                 var document = {
                                    getElementById: function(id) {
                                        return textBox;
                                    }
                                 }; 
                                ");

            string test = @"                                                   
                            return Login_Login();
                           ";

            var rawResult = script.RunTest(test);
            var result = JsonConvert.DeserializeObject(rawResult);

            Assert.IsTrue(Convert.ToBoolean(result));
            script = null;
        }

        [TestMethod]		   
		[Ignore]
        public void Test_Login_Login_Login_NoUserName()
        {
            var script = SetUpScript();

            script.AppendBlock(@"                                                 
                                function HasValue(ctrlId, type)  
                                { 
                                    if (ctrlId == 'tbLoginUsername') { return false; }
                                    return true; 
                                }
                                ");

            string test = @"                                                   
                            return Login_Login();
                           ";

            var rawResult = script.RunTest(test);
            var result = JsonConvert.DeserializeObject(rawResult);

            Assert.IsNull(result);                               
            script = null;
        }

        [TestMethod]		  
		[Ignore]
        public void Test_Login_Login_Login_NoPassword()
        {
            var script = SetUpScript();

            script.AppendBlock(@"                                                 
                                function HasValue(ctrlId, type)  
                                { 
                                    if (ctrlId == 'tbLoginPassword') { return false; }
                                    return true; 
                                }
                                ");

            string test = @"                                                   
                            return Login_Login();
                           ";

            var rawResult = script.RunTest(test);
            var result = JsonConvert.DeserializeObject(rawResult);

            Assert.IsNull(result);
            script = null;
        }

        // ======================================================

        [TestMethod]			 
		[Ignore]
        public void Test_Login_IsLoggedIn_True()
        {
            var script = SetUpScript();
            string test = @"
                            SessionSetToken(SESSION_TOKEN, 'myAwesomeToken');
                            return IsLoggedIn();
                           ";
            script.AppendBlock(GetSessionMock());
            EvaluateResult(script, test, true);
        }

        [TestMethod]   
		[Ignore]
        public void Test_Login_IsLoggedIn_False()
        {
            var script = SetUpScript();
            string test = @"
                            return IsLoggedIn();
                          ";
            script.AppendBlock(GetSessionMock());
            EvaluateResult(script, test, false);
        }

        [TestMethod]	   
		[Ignore]
        public void Test_Login_Login_Index()
        {
            var script = CreateJsTestScript(@"..\..\..\..\TgimbaNetCoreWeb\wwwroot\Scripts\Common\Controllers\Login.js");
            script.AppendFile(@"..\..\..\..\TgimbaNetCoreWeb\wwwroot\Scripts\Common\Constants.js");

            script.AppendBlock(@"
                                function LoadView(view) {
                                    if (view === '/Markup/HtmlVanillaJs/Views/Login/Index.html') {
                                        return true;
                                    }
                                    return false;
                                }
                              ");

            var rawResult = script.RunTest(@"return Login_Index();");
            var result = JsonConvert.DeserializeObject(rawResult);

            Assert.IsTrue(Convert.ToBoolean(result));
            script = null;
        }                                                           

        [TestMethod]   
		[Ignore]
        public void Test_Login_Login_Cancel()
        {
            var script = CreateJsTestScript(@"..\..\..\..\TgimbaNetCoreWeb\wwwroot\Scripts\Common\Controllers\Login.js");
            script.AppendFile(@"..\..\..\..\TgimbaNetCoreWeb\wwwroot\Scripts\Common\Constants.js");

            script.AppendBlock(@"
                                function SetView(view) {
                                    if (view === '/Welcome/Index') {
                                        return true;
                                    }
                                    return false;
                                }
                              ");

            var rawResult = script.RunTest(@"return Login_Cancel();");
            var result = JsonConvert.DeserializeObject(rawResult);

            Assert.IsTrue(Convert.ToBoolean(result));
            script = null;
        }

        private void EvaluateResult(TestScript script, string test, bool expectedOutcome)
        {
            var rawResult = script.RunTest(test);
            var result = JsonConvert.DeserializeObject(rawResult);
            var isLoggedIn = Convert.ToBoolean(result);

            Assert.AreEqual(expectedOutcome, isLoggedIn);
            script = null;
        }

        private TestScript SetUpScript()
        {
            var script = CreateJsTestScript(@"..\..\..\..\TgimbaNetCoreWeb\wwwroot\Scripts\Common\Controllers\Login.js");
            script.AppendFile(@"..\..\..\..\TgimbaNetCoreWeb\wwwroot\Scripts\Common\Constants.js");

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
