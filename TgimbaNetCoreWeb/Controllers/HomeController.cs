using Microsoft.AspNetCore.Mvc;
using Shared.interfaces;		 
using SharedControllers = TgimbaNetCoreWebShared.Controllers;	
using SharedModels = TgimbaNetCoreWebShared.Models;

namespace TgimbaNetCoreWeb.Controllers
{
    public class HomeController	: Controller
    {
		private SharedControllers.SharedHomeController sharedHomeController = null;

        public HomeController(ITgimbaService service, IWebClient webClient)
        {
			sharedHomeController = new SharedControllers.SharedHomeController(service, webClient);
		}
                  
        public IActionResult HtmlVanillaJsIndex()
        {
            return View();
        }
 
        public IActionResult HtmlJQueryIndex()
        {
            return View();
        }

        [HttpPost]
        public string Login(string user, string pass)
        {
            return sharedHomeController.Login(user, pass);
        }
															   
		[HttpPost]
		public bool Registration(
			string user,  
			string email,
			string pass
		) {					
            return sharedHomeController.Registration(user, email, pass);
		} 
		   
        [HttpPost]
        public string JQueryLogin([FromBody] SharedModels.SharedLoginModel login)
        {												   
            return sharedHomeController.JQueryLogin(login);	 
        }
				   	   
        [HttpPost]
        public bool JQueryRegistration([FromBody] SharedModels.SharedRegistrationModel registration)
        {								  
            return sharedHomeController.JQueryRegistration(registration);	
        }
    }
}
