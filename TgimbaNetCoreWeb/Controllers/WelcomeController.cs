using Microsoft.AspNetCore.Mvc;	  				   
using Shared.interfaces;		 					 		  
using TgimbaNetCoreWebShared;  	 					  
using TgimbaNetCoreWebShared.Models;
using TgimbaNetCoreWebShared.Controllers;

namespace TgimbaNetCoreWeb.Controllers
{			 
	[RequireHttpsAttribute]
    public class WelcomeController : Controller
    {
		private SharedWelcomeController sharedWelcomeController = null;
		private ITgimbaService service = null;

        public WelcomeController(ITgimbaService service, IWebClient webClient)
        {
			sharedWelcomeController = new SharedWelcomeController(service, webClient);
			this.service = service;
		}
				
        public IActionResult Index()
        {
            var model = new SharedWelcomeModel(this.service);
            return View(model);
        }
    }
}