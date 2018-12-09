using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JSTest;                        
using Newtonsoft.Json;

namespace TestJavaScriptV2
{
    [TestClass]
    public class DisplayTests : BaseTest
    {
        [TestMethod] 
		[Ignore]
        public void Test_Global_LoadView_HappyPath()
        {
            var script = SetUpHappyPathScript();

            script.AppendBlock(@"
                               function isNullUndefined(object, location, expectedObj) {}   
                            ");

            var rawResult = script.RunTest(@"return LoadView(VIEW_LOGIN);");
            var result = JsonConvert.DeserializeObject(rawResult);  

            Assert.IsTrue(Convert.ToBoolean(result));
            script = null;                                                          
        }

        [TestMethod]  
		[Ignore]
        public void Test_Display_GetContentDiv_HappyPath()
        {
            var script = SetUpHappyPathScript();

            script.AppendBlock(@"
                               function isNullUndefined(object, location, expectedObj) {}   
                            ");

            var rawResult = script.RunTest(@"return GetContentDiv();");
            var result = JsonConvert.DeserializeObject(rawResult);
           
            Assert.IsTrue(result.ToString() == "<div id='csHtmlContentDiv'></div>");
            script = null;
        }

        [TestMethod]	    
		[Ignore]
        public void Test_Display_GetContentDiv_ThrowsContentDivIsNullError()
        {
            var script = SetUpHappyPathScript();              

            script.AppendBlock(@"
                                    var document = {
                                    getElementById: function(id) {
                                        return null;
                                    }
                                }; 

                                function isNullUndefined(object, location, expectedObj) {
                                    throw expectedObj + ' is null  at ' + location     
                                } 
                         ");
            
            Assert.IsTrue(TestErrorThrow(script, @"return GetContentDiv();", "contentDiv", "null", "Display.js"));
            script = null;
        }

        [TestMethod]   
		[Ignore]
        public void Test_Display_GetContentDiv_ThrowsContentDivIsUndefinedError()
        {
            var script = SetUpHappyPathScript();

            script.AppendBlock(@"
                                var document = {
                                    getElementById: function(id) {
                                        return undefined;
                                    }
                                };
                                    
                                function isNullUndefined(object, location, expectedObj) {
                                    throw expectedObj + ' is undefined  at ' + location     
                                } 
                         ");

            Assert.IsTrue(TestErrorThrow(script, @"return GetContentDiv();", "contentDiv", "undefined", "Display.js"));
            script = null;
        }

        private TestScript SetUpHappyPathScript()
        {
            var script = CreateJsTestScript(@"..\..\..\..\TgimbaNetCoreWeb\wwwroot\Scripts\HtmlVanillaJs\Display.js"); 
			script.AppendFile(@"..\..\..\..\TgimbaNetCoreWeb\wwwroot\Scripts\Common\Constants.js"); 

            script.AppendBlock(GetMock());

            return script;
        }        

        private string GetMock()
        {
            string mock = (@"
                                var document = {
                                    getElementById: function(id) {
                                        return '<div id=\'csHtmlContentDiv\'></div>';
                                    }
                                };   
                                
                                function GetView(view, contentDiv) {
                                    if (view === '/Markup/HtmlVanillaJs/Views/Login/Index.html'
                                            && contentDiv != null && contentDiv != undefined) {
                                        return true;
                                    } else {
                                        return false;
                                    }
                                }                                                           
                            ");

            return mock;
        }
    }
}
