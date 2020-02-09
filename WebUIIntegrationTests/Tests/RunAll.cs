using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TgimbaSeleniumTests.Tests
{
    [TestClass]
    public class RunAll
    {        
        [TestMethod]
        public void RunAllLocalTests()
        {				  
			foreach (string url in Utilities.GetUrls())
			{
				CleanUpLocal();
				RunAllTestsLocalDesktop(url);
			}
		}
        
        public void CleanUpLocal()
        {
            BaseTest bt = new BaseTest();
            bt.CleanUpLocal();
        }
        
        private void RunAllTestsLocalDesktop(string url)
        {
			Chrome.Chrome chromeDesk = new Chrome.Chrome(url);
			chromeDesk.TestHappyPathChrome();
			CleanUpLocal();

			//Firefox.Firefox firefoxDesk = new Firefox.Firefox(url);
            //firefoxDesk.TestHappyPathFireFox();
            //CleanUpLocal();				
        }    
    }
}
