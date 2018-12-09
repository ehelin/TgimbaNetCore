using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.interfaces;
using Shared.misc;									  

namespace TestShared
{
    [TestClass]
    public class WebClientTest : BaseTest
    {									  
		[TestMethod]
		public void TestSharedHomeController_GoodRegistration()
		{											  
			bool goodRegistration = this.webClient.Registration("goodUser", "goodEmail", "goodPass");
									  
			Assert.AreEqual(true, goodRegistration);
		}

		[TestMethod]
		public void TestSharedHomeController_BadRegistration()
		{
			bool goodRegistration = this.webClient.Registration("badUser", "badEmail", "badPass");
									  
			Assert.AreEqual(false, goodRegistration);
		}

		[TestMethod]
		public void TestSharedHomeController_GoodLogin()
		{
			string token = this.webClient.Login("goodUser", "goodPass");
									  
			Assert.AreEqual("token", token);
		}

		[TestMethod]
		public void TestSharedHomeController_BadLogin()
		{
			string token = this.webClient.Login("badUser", "badPass");
									  
			Assert.AreEqual("", token);
		}
    }
}
