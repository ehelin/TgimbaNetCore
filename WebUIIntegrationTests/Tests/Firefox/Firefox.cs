using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;

namespace TgimbaSeleniumTests.Tests.Firefox
{
    [TestClass]
    public class Firefox : BaseHappyPath
    {
        public Firefox(string pUrl)
        {
            url = pUrl;
        }

        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
						   
        public void TestHappyPathFireFox()
        {
            TestHappyPath(new FirefoxDriver());
        }
    }
}
