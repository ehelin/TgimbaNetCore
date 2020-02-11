using OpenQA.Selenium.Remote;
using System.Collections.Generic;

namespace TgimbaSeleniumTests
{
    public class Utilities
    {
        public static void CloseBrowser(RemoteWebDriver browser)
        {
            if (browser != null)
            {
                browser.Close();
                browser.Dispose();
                browser = null;
            }
        }

		public static List<string> GetUrls() {
			return new List<string>{
                //"https://www.tgimba.com/"
                "http://localhost:56675/",	// Vanilla JS
				//"http://localhost:62356/",							// Angular 6
				//"http://localhost:50359/",							// React JS
			};
		}
    }
}
