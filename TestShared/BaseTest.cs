using Shared.interfaces;
using Shared;
using Moq;

namespace TestShared
{
    public class BaseTest
    {
        protected Mock<ITgimbaService> mockITgimbaService { get; set; }
		protected IWebClient webClient { get; set; }

        public BaseTest()
        {
            mockITgimbaService = new Mock<ITgimbaService>(); 

			webClient = new WebClient(mockITgimbaService.Object);

            SetupTgimbaService();	
        }			  

		private void SetupTgimbaService() {
			mockITgimbaService.Setup(x => x.ProcessUser("goodUser", "goodPass")).Returns("token");	
			mockITgimbaService.Setup(x => x.ProcessUser("badUser", "badPass")).Returns("");
			mockITgimbaService.Setup(x => x.ProcessUserRegistration("goodUser", "goodEmail", "goodPass")).Returns(true); 
			mockITgimbaService.Setup(x => x.ProcessUserRegistration("badUser", "badEmail", "badPass")).Returns(false);	
		}
    }
}
