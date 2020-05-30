using Microsoft.AspNetCore.Mvc;
using Shared.interfaces;		 							 		  
using TgimbaNetCoreWebShared;  	 					  
using TgimbaNetCoreWebShared.Models;
using TgimbaNetCoreWebShared.Controllers;

namespace TgimbaNetCoreWeb.Controllers
{
#if !DEBUG
    [RequireHttpsAttribute]
#endif
    public class RegistrationController : Controller
    {
        private SharedRegistrationController sharedRegistrationController = null;

        public RegistrationController(IWebClient webClient)
        {
            sharedRegistrationController = new SharedRegistrationController(webClient);
        }

        [HttpPost]
		public bool Registration(
			string encodedUser,  
			string encodedPass,
			string encodedEmail
		) {						 	   														   
            return sharedRegistrationController.Registration(encodedUser, encodedEmail, encodedPass);
		}  
    }
}
