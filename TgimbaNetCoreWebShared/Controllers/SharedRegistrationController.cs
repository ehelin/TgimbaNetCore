using Shared.interfaces;					 
using Microsoft.AspNetCore.Mvc;	
using TgimbaNetCoreWebShared.Models;	   

namespace TgimbaNetCoreWebShared.Controllers
{
    public class SharedRegistrationController : SharedBaseController
    {
		public SharedRegistrationController(ITgimbaService service, IWebClient webClient)
            : base(service, webClient) { }
											   
		[HttpPost]
		public bool Registration(
			string user,  
			string email,
			string pass
		) {							 
			bool registered = this.webClient.Registration(user, email, pass);

            return registered;
		} 
    }
}