using Microsoft.AspNetCore.Mvc;
using Shared.interfaces;		
using Shared;			   
using TgimbaNetCoreWebShared.Models;

namespace TgimbaNetCoreWebShared.Controllers
{
    public class SharedHomeController : SharedBaseController
    {
        public SharedHomeController(ITgimbaService service, IWebClient webClient)
            : base(service, webClient) { }

        [HttpPost]
        public string Login(string user, string pass)
        {
            string token = this.webClient.Login(user, pass);

            return token;
        }
															   
		[HttpPost]
		public bool Registration(
			string user,  
			string email,
			string pass
		) {							 
			bool registered = this.webClient.Registration(user, email, pass);

            return registered;
		} 
		   
        [HttpPost]
        public string JQueryLogin([FromBody] SharedLoginModel login)
        {
            string token = this.webClient.Login(login.Username, login.Password);

            return token;
        }
				   	   
        [HttpPost]
        public bool JQueryRegistration([FromBody] SharedRegistrationModel registration)
        {
            bool goodRegistration = this.webClient.Registration(registration.Username, registration.Email, registration.Password);

            return goodRegistration;
        }
    }
}
