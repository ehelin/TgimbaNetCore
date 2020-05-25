 using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.misc.testUtilities;

namespace TgimbaSeleniumTests.Tests
{
    [TestClass]
    public class RunAll
    {
        [TestCleanup]
        public void Cleanup()
        {
            TestUtilities.ClearEnvironmentalVariablesForIntegrationTests();
        }

        [TestInitialize]
        public void SetUp()
        {
            TestUtilities.SetEnvironmentalVariablesForIntegrationTests();
        }

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
            var utilities = new Shared.misc.testUtilities.TestUtilities();
            utilities.CleanUpLocal(Constants.TEST_USER);
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
