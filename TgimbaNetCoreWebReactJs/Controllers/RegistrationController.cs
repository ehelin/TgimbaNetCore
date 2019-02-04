using Microsoft.AspNetCore.Mvc;
using Shared.interfaces;		 							 		  
using TgimbaNetCoreWebShared;  	 					  
using TgimbaNetCoreWebShared.Models;
using TgimbaNetCoreWebShared.Controllers;

namespace TgimbaNetCoreWeb.Controllers
{				 
	//[RequireHttpsAttribute]
    public class RegistrationController	: Controller
    {
		private SharedRegistrationController sharedRegistrationController = null;

        public RegistrationController(ITgimbaService service, IWebClient webClient)
        {
			sharedRegistrationController = new SharedRegistrationController(service, webClient);
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
