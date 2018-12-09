using Microsoft.AspNetCore.Mvc;	  				   
using Shared.interfaces;		 
using SharedControllers = TgimbaNetCoreWebShared.Controllers;	
using SharedModels = TgimbaNetCoreWebShared.Models;

namespace TgimbaNetCoreWeb.Controllers
{
    public class WelcomeController : Controller
    {
		private SharedControllers.SharedWelcomeController sharedWelcomeController = null;
		private ITgimbaService service = null;

        public WelcomeController(ITgimbaService service, IWebClient webClient)
        {
			sharedWelcomeController = new SharedControllers.SharedWelcomeController(service, webClient);
			this.service = service;
		}
				
        public IActionResult Index()
        {
            SharedModels.SharedWelcomeModel model = new SharedModels.SharedWelcomeModel(this.service);
            return View(model);
        }
    }
}