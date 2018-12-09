using Microsoft.AspNetCore.Mvc;               
using Shared.interfaces;   
using SharedControllers = TgimbaNetCoreWebShared.Controllers;

namespace TgimbaNetCoreWeb.Controllers
{		  				
    public class HomeController : Controller
    {                                      
		private SharedControllers.SharedHomeController sharedHomeController = null;

        public HomeController(ITgimbaService service, IWebClient webClient)
        {
			sharedHomeController = new SharedControllers.SharedHomeController(service, webClient);
		}

        public IActionResult Index()
        {
            return View();
        }         
				
        [HttpPost]
        public string Login([FromQuery] string encodedUser, string encodedPass)
        {							 
            return sharedHomeController.Login(encodedUser, encodedPass);
        }		
															   
		[HttpPost]
		public bool Registration(
			string encodedUser,  
			string encodedPass,
			string encodedEmail
		) {						 	   
            return sharedHomeController.Registration(encodedUser, encodedEmail, encodedPass);
		}
    }
}
