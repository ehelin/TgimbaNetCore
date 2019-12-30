using Microsoft.AspNetCore.Mvc;

namespace TgimbaNetCoreWebShared.Controllers
{
    public class SharedRegistrationController : SharedBaseController
    {
		public SharedRegistrationController(IWebClient webClient)
            : base(webClient) { }
											   
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