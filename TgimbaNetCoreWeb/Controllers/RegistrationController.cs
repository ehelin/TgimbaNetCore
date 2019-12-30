using Microsoft.AspNetCore.Mvc;
using TgimbaNetCoreWebShared;
using TgimbaNetCoreWebShared.Controllers;

namespace TgimbaNetCoreWeb.Controllers
{
#if !DEBUG
    [RequireHttpsAttribute]
#endif
    public class RegistrationController	: Controller
    {
		private SharedRegistrationController sharedRegistrationController = null;

        public RegistrationController(IWebClient webClient)
        {
			sharedRegistrationController = new SharedRegistrationController(webClient);
		}	                   	
															   
		[HttpPost]
		public bool Registration(
			string user,  
			string email,
			string pass
		) {					
            return sharedRegistrationController.Registration(user, email, pass);
		} 
    }
}
