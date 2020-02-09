using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;

namespace TgimbaSeleniumTests.Tests
{
    [TestClass]
    public class BaseHappyPath : BaseTest
    {
        public BaseHappyPath() {}

        protected void TestHappyPath(RemoteWebDriver browser)
        {
            browser.Manage().Window.Maximize();

            //welcome page -----------------------------------------------------
            LaunchPageTest(browser, url);
            System.Threading.Thread.Sleep(_testStepInterval);
            ClickAction(browser, "htmlVanillaJsLogin");
            System.Threading.Thread.Sleep(_testStepInterval);

            //login/registration -----------------------------------------------
            LoginTest(browser, "test", "test", true);
            System.Threading.Thread.Sleep(_testStepInterval);

            TestRegistration(browser, "testUser", "testUser23", "test@aol.com", false);
            System.Threading.Thread.Sleep(_testStepInterval);

            LoginTest(browser, "testUser", "testUser23", false);
            System.Threading.Thread.Sleep(_testStepInterval);

            //menu tests -------------------------------------------------------  
            ClickAction(browser, "btnMainMenu");
            ClickAction(browser, "hvJsCancelBtn");

            // show add screen, cancel and reshow add screen
            ClickAction(browser, "btnMainMenu");
            ClickAction(browser, "hvJsAddBucketListItemBtn");
            ClickAction(browser, "hvJsAddCancellBtn");

            // main grid tests --------------------------------------------------
            // add item	  	
            AddItem(browser, "Bucket item test 1", "Hot", true, "1.2", "2.1");
            System.Threading.Thread.Sleep(_testStepInterval);

            // edit item
            EditItem(browser, "Updated Bucket item test 1", "Warm", "3.4", "10.9");
            System.Threading.Thread.Sleep(_testStepInterval);

            // delete item
            ClickAction(browser, "hvJsFormDeleteBtn");

            //sort ----------------------------------------------------------
            // show sort menu and return to main bucket list
            ClickAction(browser, "btnMainMenu");                    // main menu button
            ClickAction(browser, "hvJsSortBucketListItemBtn");      // sort button				  
            ClickAction(browser, "hvJsCancelBtn");                  // cancel button		

            AddSortCategoryTestItems(browser);
            System.Threading.Thread.Sleep(_testStepInterval);

            Sort(browser);
            System.Threading.Thread.Sleep(_testStepInterval);

            //search -------------------------------------------------------
            Search(browser);

            // logout and close browser
            ClickAction(browser, "btnMainMenu");
            ClickAction(browser, "hvJsLogOutBtn");  // logout 	
            Utilities.CloseBrowser(browser);
        }

        protected void Search(RemoteWebDriver browser)
        {
			//search 1 - find item
            browser.FindElement(By.Id("USER_CONTROL_SEARCH_TEXT_BOX")).SendKeys("Bucket item test 1");
            System.Threading.Thread.Sleep(_testStepInterval);

            IWebElement link = browser.FindElement(By.Id("USER_CONTROL_SEARCH_BUTTON"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

            link = browser.FindElement(By.Id("USER_CONTROL_CANCEL_BUTTON"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

			//search 2 - do not find item				 			   	   
            browser.FindElement(By.Id("USER_CONTROL_SEARCH_TEXT_BOX")).Clear();
            System.Threading.Thread.Sleep(_testStepInterval);
            browser.FindElement(By.Id("USER_CONTROL_SEARCH_TEXT_BOX")).SendKeys("drive");
            System.Threading.Thread.Sleep(_testStepInterval);

            link = browser.FindElement(By.Id("USER_CONTROL_SEARCH_BUTTON"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

            link = browser.FindElement(By.Id("USER_CONTROL_CANCEL_BUTTON"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

			//search 3 - find item and edit it								   
            browser.FindElement(By.Id("USER_CONTROL_SEARCH_TEXT_BOX")).Clear();
            System.Threading.Thread.Sleep(_testStepInterval);
            browser.FindElement(By.Id("USER_CONTROL_SEARCH_TEXT_BOX")).SendKeys("Bucket item test 1");
            System.Threading.Thread.Sleep(_testStepInterval);

            link = browser.FindElement(By.Id("USER_CONTROL_SEARCH_BUTTON"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);
																	
            link = browser.FindElement(By.Id("hvJsFormEditBtn"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

            browser.FindElement(By.Id("USER_CONTROL_EDIT_ITEM_NAME")).SendKeys("Edited item value");
            System.Threading.Thread.Sleep(_testStepInterval);	  

            link = browser.FindElement(By.Id("hvJsEditSubmitBtn"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);
								 
			//search 4 - find item and delete it			   
            browser.FindElement(By.Id("USER_CONTROL_SEARCH_TEXT_BOX")).Clear();
            System.Threading.Thread.Sleep(_testStepInterval);
            browser.FindElement(By.Id("USER_CONTROL_SEARCH_TEXT_BOX")).SendKeys("Bucket item test 2");
            System.Threading.Thread.Sleep(_testStepInterval);

            link = browser.FindElement(By.Id("USER_CONTROL_SEARCH_BUTTON"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);
																	
            link = browser.FindElement(By.Id("hvJsFormDeleteBtn"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);
        }
    }
}
