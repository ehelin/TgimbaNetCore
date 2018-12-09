using Shared.interfaces;
using Moq;

namespace TestTgimbaNetCoreWeb
{
    public class BaseTest
    {
        protected Mock<ITgimbaService> mockITgimbaService { get; set; }
		protected Mock<IWebClient> mockWebClient { get; set; }

        public BaseTest()
        {
            mockITgimbaService = new Mock<ITgimbaService>();  
            mockWebClient = new Mock<IWebClient>();

            SetupGetDashboard();	 
			SetupWebClient();
        }

        private void SetupGetDashboard()
        {
            string[] data = new string[]
            {
                "result 1", "result 2", "result 3", "result 4", "result 5",
                "result 6", "result 7", "result 8", "result 9", "result 10"
            };
            mockITgimbaService.Setup(x => x.GetDashboard()).Returns(data);
        }

		private void SetupWebClient() {
			mockWebClient.Setup(x => x.Login("goodUser", "goodPass")).Returns("token");	
			mockWebClient.Setup(x => x.Login("badUser", "badPass")).Returns("");
			mockWebClient.Setup(x => x.Registration("goodUser", "goodEmail", "goodPass")).Returns(true); 
			mockWebClient.Setup(x => x.Registration("badUser", "badEmail", "badPass")).Returns(false);	
		}
    }
}
