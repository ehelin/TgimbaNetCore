using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Data.SqlClient;
using OpenQA.Selenium.Support.UI;
using Shared.misc;

namespace TgimbaSeleniumTests.Tests
{
    public class BaseTest
    {
        protected int _testStepInterval = 3000;
        protected string url = string.Empty;

        #region Base Test Methods		

		protected void ClickAction(RemoteWebDriver browser, string buttonName)
		{			
            IWebElement link = browser.FindElement(By.Id(buttonName));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);
		}	
        protected void LogOut(RemoteWebDriver browser)
        {
            IWebElement link = browser.FindElement(By.Id("MenuRequest"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

            link = browser.FindElement(By.Id("LogOut"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);
        }  
        protected void AddItem(RemoteWebDriver browser, string bucketListName, string category, bool completed, string latitude, string longitude)
        {	   									 
			ClickAction(browser, "btnMainMenu");				
			ClickAction(browser, "hvJsAddBucketListItemBtn");
			 										   
            browser.FindElement(By.Id("USER_CONTROL_ADD_ITEM_NAME")).SendKeys(bucketListName);
            System.Threading.Thread.Sleep(_testStepInterval);

            IWebElement rankingItemSelect = browser.FindElement(By.Id("USER_CONTROL_ADD_ITEM_CATEGORY"));
            SelectElement selectElement = new SelectElement(rankingItemSelect);
            selectElement.SelectByText(category);
            System.Threading.Thread.Sleep(_testStepInterval);

			if (completed) 
			{
				IWebElement radioBtn = browser.FindElement(By.Id("USER_CONTROL_ADD_COMPLETED"));
				radioBtn.Click();																 
				System.Threading.Thread.Sleep(_testStepInterval);
			}

            browser.FindElement(By.Id("USER_CONTROL_ADD_LATITUDE")).SendKeys(latitude);
            System.Threading.Thread.Sleep(_testStepInterval);

            browser.FindElement(By.Id("USER_CONTROL_ADD_LONGITUDE")).SendKeys(longitude);
            System.Threading.Thread.Sleep(_testStepInterval);
																  
			ClickAction(browser, "hvJsAddSubmitBtn");	
        }
        protected void EditItem(RemoteWebDriver browser, string bucketListName, string category, string latitude, string longitude)
        {	   																   			
			ClickAction(browser, "hvJsFormEditBtn");				
			ClickAction(browser, "hvJsEditCancellBtn");				
			ClickAction(browser, "hvJsFormEditBtn");			
																								  
            browser.FindElement(By.Id("USER_CONTROL_EDIT_ITEM_NAME")).Clear();	  
            System.Threading.Thread.Sleep(_testStepInterval);
            browser.FindElement(By.Id("USER_CONTROL_EDIT_ITEM_NAME")).SendKeys(bucketListName);
            System.Threading.Thread.Sleep(_testStepInterval);

			IWebElement radioBtn = browser.FindElement(By.Id("USER_CONTROL_EDIT_COMPLETED"));
			radioBtn.Click();																 
            System.Threading.Thread.Sleep(_testStepInterval);

            IWebElement rankingItemSelect = browser.FindElement(By.Id("USER_CONTROL_EDIT_ITEM_CATEGORY"));
            SelectElement selectElement = new SelectElement(rankingItemSelect);
            selectElement.SelectByText(category);
            System.Threading.Thread.Sleep(_testStepInterval);
																							
            browser.FindElement(By.Id("USER_CONTROL_EDIT_LATITUDE")).Clear();		 
            System.Threading.Thread.Sleep(_testStepInterval);
            browser.FindElement(By.Id("USER_CONTROL_EDIT_LATITUDE")).SendKeys(latitude);
            System.Threading.Thread.Sleep(_testStepInterval);
																						   
            browser.FindElement(By.Id("USER_CONTROL_EDIT_LONGITUDE")).Clear();	   
            System.Threading.Thread.Sleep(_testStepInterval);
            browser.FindElement(By.Id("USER_CONTROL_EDIT_LONGITUDE")).SendKeys(longitude);
            System.Threading.Thread.Sleep(_testStepInterval);
																  
			ClickAction(browser, "hvJsEditSubmitBtn");	
        }
		protected void LaunchPageTest(RemoteWebDriver browser, string url)
		{
			browser.Navigate().GoToUrl(url);
		}
		protected void SetUsernamePassword(RemoteWebDriver browser, string userName, string passWord) 
		{
            browser.FindElement(By.Id("USER_CONTROL_LOGIN_USERNAME")).SendKeys(userName);
            browser.FindElement(By.Id("USER_CONTROL_LOGIN_PASSWORD")).SendKeys(passWord);
		}
        protected void LoginTest(RemoteWebDriver browser, string userName, string passWord, bool expectedAlert)
        {
			SetUsernamePassword(browser, userName, passWord);

            System.Threading.Thread.Sleep(_testStepInterval);

            IWebElement link = browser.FindElement(By.Id("hvJsLoginBtn"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

            if (expectedAlert)
                browser.SwitchTo().Alert().Accept();
        }
		protected void CancelLoginTest(RemoteWebDriver browser, string cancelBtnId)
		{
			IWebElement link = browser.FindElement(By.Id(cancelBtnId));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

            browser.SwitchTo().Alert().Accept();
		}
        protected void TestRegistration(RemoteWebDriver browser, string userName, string passWord, string email, bool expectedAlert)
        {
            IWebElement link = browser.FindElement(By.Id("hvJsRegisterPanelBtn"));	//hvJsRegisterBtn
            link.Click();

            System.Threading.Thread.Sleep(_testStepInterval);

            browser.FindElement(By.Id("USER_CONTROL_REGISTRATION_USERNAME")).SendKeys(userName);
            browser.FindElement(By.Id("USER_CONTROL_REGISTRATION_EMAIL")).SendKeys(email);
            browser.FindElement(By.Id("USER_CONTROL_REGISTRATION_PASSWORD")).SendKeys(passWord);
            browser.FindElement(By.Id("USER_CONTROL_REGISTRATION_CONFIRM_PASSWORD")).SendKeys(passWord);
            System.Threading.Thread.Sleep(_testStepInterval);

            link = browser.FindElement(By.Id("hvJsRegisterBtn"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

            if (expectedAlert)
                browser.SwitchTo().Alert().Accept();			 
        }
        protected void Sort(RemoteWebDriver browser, bool useBubbleSort = false)
        {
            SelectSort(browser, "hvJsSortItemBtn", false, useBubbleSort);
            SelectSort(browser, "hvJsSortItemBtn", true, useBubbleSort);

            SelectSort(browser, "hvJsSortCreatedBtn", false, useBubbleSort);
            SelectSort(browser, "hvJsSortCreatedBtn", true, useBubbleSort);

            SelectSort(browser, "hvJsSortCategoryBtn", false, useBubbleSort);
            SelectSort(browser, "hvJsSortCategoryBtn", true, useBubbleSort);

            SelectSort(browser, "hvJsSortAchievedBtn", false, useBubbleSort);
            SelectSort(browser, "hvJsSortAchievedBtn", true, useBubbleSort);

            SelectSort(browser, "hvJsCancelBtn", false);	
        }
        private void SelectSort(RemoteWebDriver browser, string buttonName, bool desc, bool useBubbleSort = false)
        {
            IWebElement link = browser.FindElement(By.Id("btnMainMenu"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

            link = browser.FindElement(By.Id("hvJsSortBucketListItemBtn"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

            if (useBubbleSort)
            {
                var selectBox = browser.FindElement(By.Id("hvJsSortAvailableSortAlgorithmsSelect"));
                var selectElement = new SelectElement(selectBox);
                selectElement.SelectByText("Bubble");
                System.Threading.Thread.Sleep(_testStepInterval);
            }

            if (desc)
            {
                link = browser.FindElement(By.Id("hvJsDescCheckbox"));
                link.Click();
                System.Threading.Thread.Sleep(_testStepInterval);
            }

            link = browser.FindElement(By.Id(buttonName));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);
        }
        protected void AddSortCategoryTestItems(RemoteWebDriver browser)
        {	
			AddItem(browser, "Bucket item test 3", "Hot", true, "3.2", "3.1");
			System.Threading.Thread.Sleep(_testStepInterval);

			AddItem(browser, "Bucket item test 1", "Cool", false, "1.2", "2.1");
			System.Threading.Thread.Sleep(_testStepInterval);

			AddItem(browser, "Bucket item test 7", "Warm", true, "7.2", "7.1");
			System.Threading.Thread.Sleep(_testStepInterval);

			AddItem(browser, "Bucket item test 5", "Hot", false, "5.2", "5.1");
			System.Threading.Thread.Sleep(_testStepInterval);

			AddItem(browser, "Bucket item test 4", "Warm", true, "4.2", "4.1");
			System.Threading.Thread.Sleep(_testStepInterval);

            // TODO bug appears to be here...
			AddItem(browser, "Bucket item test 2", "Cool", false, "2.2", "2.1");
			System.Threading.Thread.Sleep(_testStepInterval);

			AddItem(browser, "Bucket item test 6", "Hot", true, "6.2", "6.1");
			System.Threading.Thread.Sleep(_testStepInterval);
		}
      
		#endregion

        #region Support 
        
        public void CleanUpLocal()
        {
            var connectionString = Shared.misc.Utilities.GetTestDbSetting();
            DeleteTestUser(Constants.TEST_USER, connectionString);
        }
    	protected void DeleteTestUser(string userName, string connectionString)
		{
			SqlConnection conn = null;
			SqlCommand cmd = null;

			try
			{
				conn = new SqlConnection(connectionString);
				cmd = conn.CreateCommand();
				cmd.CommandText = Constants.DELETE_TEST_USER;
				cmd.CommandType = System.Data.CommandType.Text;

				cmd.Parameters.Add(new SqlParameter("@userName", userName));

				cmd.Connection.Open();

				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (conn != null)
				{
					conn.Close();
					conn.Dispose();
					conn = null;
				}

				if (cmd != null)
				{
					cmd.Dispose();
					cmd = null;
				}
			}
		}

		#endregion
	}
}
