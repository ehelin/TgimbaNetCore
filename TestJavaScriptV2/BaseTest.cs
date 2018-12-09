using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JSTest;
using JSTest.ScriptElements;
using JSTest.ScriptLibraries;
using Newtonsoft.Json;

namespace TestJavaScriptV2
{
    public class BaseTest
    {
        protected bool AssertTrueResult(TestScript script, string test)
        {
            var rawResult = script.RunTest(test);
            var result = JsonConvert.DeserializeObject(rawResult);
            bool loaded = Convert.ToBoolean(result);

            return loaded;
        }

        protected object TestNonErrorGetResult(TestScript script, string test)
        {
            var result = JsonConvert.DeserializeObject(script.RunTest(test));

            return result;
        }

        protected bool TestErrorThrow(
                TestScript script, 
                string test, 
                string error = null, 
                string errorType = null,
                string errorLocation = null
            )
        {
            try         
            {
                script.RunTest(test);
            }
            catch (Exception ex)
            {
                // TODO - simplify logic
                if (!string.IsNullOrEmpty(error) && ex.Message.IndexOf(error) != -1
                        && string.IsNullOrEmpty(errorType) && string.IsNullOrEmpty(errorType))
                {
                    return true;
                }
                else if (!string.IsNullOrEmpty(error) && ex.Message.IndexOf(error) != -1
                            && !string.IsNullOrEmpty(errorType) && ex.Message.IndexOf(errorType) != -1
                                && string.IsNullOrEmpty(errorLocation))
                {
                    return true;
                }
                else if (!string.IsNullOrEmpty(error) && ex.Message.IndexOf(error) != -1
                            && !string.IsNullOrEmpty(errorType) && ex.Message.IndexOf(errorType) != -1
                                && !string.IsNullOrEmpty(errorLocation) && ex.Message.IndexOf(errorLocation) != -1)
                {
                    return true;
                }
                else if (string.IsNullOrEmpty(error)
                                || string.IsNullOrEmpty(errorType)
                                    || string.IsNullOrEmpty(errorLocation))
                {
                    return true;
                }
            }

            return false;
        }

        protected TestScript CreateJsTestScript(string javaScriptFile)
        {
            var script = new TestScript { IncludeDefaultBreakpoint = false };

            script.AppendBlock(new JsAssertLibrary());

            script.AppendFile(javaScriptFile);

            return script;
        }                
    }
}
