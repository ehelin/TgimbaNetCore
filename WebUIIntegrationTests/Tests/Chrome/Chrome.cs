using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace TgimbaSeleniumTests.Tests.Chrome
{
    [TestClass]
    public class Chrome : BaseHappyPath
    {
        public Chrome(string pUrl)
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
					  
        public void TestHappyPathChrome()
        {
            ChromeOptions co = new ChromeOptions();
            co.AddArgument("--test-type");
            ChromeDriver cd = new ChromeDriver();
            TestHappyPath(cd);
        }
    }
}
