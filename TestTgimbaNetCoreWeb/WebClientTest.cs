using Microsoft.VisualStudio.TestTools.UnitTesting;
using TgimbaNetCoreWebShared;
using Shared.interfaces;
using Shared.misc;									  

namespace TestTgimbaNetCoreWeb
{
    [TestClass]
    public class WebClientTest : BaseTest
    {			 																				   
		[TestMethod]
		public void Test_GoodRegistration()
		{				
			bool goodRegistration = GetWebClient().Registration(
																"base64EncodedGoodUser", 
																"base64EncodedGoodEmail", 
																"base64EncodedGoodPass"
																);
									  
			Assert.AreEqual(true, goodRegistration);
		}

		[TestMethod]
		public void Test_BadRegistration()
		{
			bool goodRegistration = GetWebClient().Registration(
																"base64EncodedBadUser", 
																"base64EncodedBadEmail", 
																"base64EncodedBadPass"
																);
									  
			Assert.AreEqual(false, goodRegistration);
		}

		[TestMethod]
		public void Test_GoodLogin()
		{
			string token = GetWebClient().Login("base64EncodedGoodUser", "base64EncodedGoodPass");
									  
			Assert.AreEqual("token", token);
		}

		[TestMethod]
		public void Test_BadLogin()
		{
			string token = GetWebClient().Login("base64EncodedBadUser", "base64EncodedBadPass");
									  
			Assert.AreEqual("", token);
		}

		[TestMethod]
		public void Test_GoodAddBucketListItem()
		{
			// TODO - complete test
			Assert.IsTrue(false);
		}	

		[TestMethod]
		public void Test_BadAddBucketListItem()
		{
			// TODO - complete test	   
			Assert.IsTrue(false);
		}

		[TestMethod]
		public void Test_GoodGetBucketListItems()
		{
			// TODO - complete test	   
			Assert.IsTrue(false);
		}

		[TestMethod]
		public void Test_BadGetBucketListItems()
		{
			// TODO - complete test
			Assert.IsTrue(false);
		}			  
		  				
		private IWebClient GetWebClient() {
			IWebClient webClient = new WebClient(this.mockITgimbaService.Object);

			return webClient;
		}		 
    }
}
