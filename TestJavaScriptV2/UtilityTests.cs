using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JSTest;                  
using Newtonsoft.Json;

namespace TestJavaScriptV2
{
    [TestClass]
    public class UtilityTests : BaseTest
    {                                                                                                                                                
        // Utility isNullUndefined Tests ======================================

        [TestMethod]
        public void Test_Utility_isNullUndefined_ThrowsNullError()
        {
            var script = SetUpTestScript();

            Assert.IsTrue(TestErrorThrow(script, @"return isNullUndefined(null, 'location', 'expectedObjectNull')", "expectedObjectNull", "null"));
            script = null;
        }

        [TestMethod]
        public void Test_Utility_isNullUndefined_ThrowsUndefinedError()
        {
            var script = SetUpTestScript();

            Assert.IsTrue(TestErrorThrow(script, @"isNullUndefined(undefined, 'location', 'expectedObjectNull')", "expectedObjectNull", "undefined"));
            script = null;
        }

        [TestMethod]
        public void Test_Utility_isNullUndefined_NoErrorThrown()
        {
            var script = SetUpTestScript();

            Assert.IsFalse(TestErrorThrow(script, @"isNullUndefined('I am an string', 'location', 'expectedObjectString')"));
            script = null;
        }

        [TestMethod]
        public void Test_Utility_isNullUndefined_NoValueReturned()
        {
            var script = SetUpTestScript();

            Assert.IsNull(TestNonErrorGetResult(script, @"isNullUndefined('I am an string', 'location', 'expectedObjectString')"));
            script = null;
        }

        // Utility HasValue Tests ======================================

        [TestMethod]
        public void Test_Utility_HasValue_True()
        {
            var script = SetUpTestScript();
            script = GetUtilityMock(script, true);

            script.AppendBlock(@" var textBox = { value: 'aValue' }; ");
            string test = @"return HasValue('csHtmlContentDiv', 'div');";

            Test_Utility_HasValue_CompleteTest(script, test, true);
        }

        [TestMethod]
        public void Test_Utility_HasValue_False_ContentDivIsNull()
        {
            var script = SetUpTestScript();
            script = GetUtilityMock(script, false);

            // mock specific to this test
            script.AppendBlock(@"   
                                 var document = {
                                    getElementById: function(id) { 
                                        return null;
                                    }
                                };              
                              ");

            Assert.IsTrue(TestErrorThrow(script, @"return HasValue('csHtmlContentDiv', 'div');"));
            script = null;
        }

        [TestMethod]
        public void Test_Utility_HasValue_False_ContentDivIsUndefined()
        {
            var script = SetUpTestScript();
            script = GetUtilityMock(script, false);

            // mock specific to this test
            script.AppendBlock(@"   
                                 var document = {
                                    getElementById: function(id) { 
                                        return undefined;
                                    }
                                };              
                              ");

            Assert.IsTrue(TestErrorThrow(script, @"return HasValue('csHtmlContentDiv', 'div');"));
            script = null;
        }

        [TestMethod]
        public void Test_Utility_HasValue_False_ValueIsNull()
        {
            var script = SetUpTestScript();
            script = GetUtilityMock(script, true);

            script.AppendBlock(@" var textBox = { value: null }; ");
            string test = @"return HasValue('csHtmlContentDiv', 'div');";

            Test_Utility_HasValue_CompleteTest(script, test, false);
        }

        [TestMethod]
        public void Test_Utility_HasValue_False_ValueIsUndefined()
        {
            var script = SetUpTestScript();
            script = GetUtilityMock(script, true);

            script.AppendBlock(@" var textBox = { value: undefined }; ");
            string test = @"return HasValue('csHtmlContentDiv', 'div');";

            Test_Utility_HasValue_CompleteTest(script, test, false);
        }

        [TestMethod]
        public void Test_Utility_HasValue_False_ValueIsEmpty()
        {
            var script = SetUpTestScript();
            script = GetUtilityMock(script, true);
            script.AppendBlock(@" var textBox = { value: '' }; ");
            string test = @"return HasValue('csHtmlContentDiv', 'div');";

            Test_Utility_HasValue_CompleteTest(script, test, false);
        }

        // Utility GetHost Tests ======================================

        [TestMethod]
        public void Test_Utility_GetHost()
        {
            var script = CreateJsTestScript(@"..\..\..\..\TgimbaNetCoreWeb\wwwroot\Scripts\Common\Utilities.js");

            script.AppendBlock(@"
                                var window = {
                                    location: {
                                        origin: 'myAwesomeHostOrigin'
                                    } 
                                }
                              ");

            var rawResult = script.RunTest(@"return GetHost();");
            var result = JsonConvert.DeserializeObject(rawResult);

            Assert.AreEqual(result, "myAwesomeHostOrigin");
            script = null;
        }

        // private =============================================

        private TestScript SetUpTestScript()
        {
            var script = CreateJsTestScript(@"..\..\..\..\TgimbaNetCoreWeb\wwwroot\Scripts\Common\Utilities.js");
          
            script = GetUtilityMock(script, true);

            return script;
        }

        private void Test_Utility_HasValue_CompleteTest(TestScript script, string test, bool assert)
        {
            var rawResult = script.RunTest(@"return HasValue('csHtmlContentDiv', 'div');");
            var result = JsonConvert.DeserializeObject(rawResult);

            if (assert)
            {
                Assert.IsTrue(Convert.ToBoolean(result));
            }
            else
            {
                Assert.IsFalse(Convert.ToBoolean(result));
            }
            script = null;
        }

        private TestScript GetUtilityMock(TestScript script, bool includeGetElementById)
        {
            script.AppendBlock(@"             
                                function alert(msg) {       
                                    if (msg === 'Please enter a value for div') {
                                        return false;
                                    }
                                    return true;
                                }

                                function Error(error) {
                                    throw error;
                                }          
                              ");

            if (includeGetElementById)
            {
                script.AppendBlock(@"
                                        var document = {
                                            getElementById: function(id) {
                                                return textBox;
                                            }
                                        }             
                                    ");
            }

            return script;
        }
    }
}
