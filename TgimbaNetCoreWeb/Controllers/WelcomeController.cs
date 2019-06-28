using Microsoft.AspNetCore.Mvc;	  				   
using Shared.interfaces;		 					 		  
using TgimbaNetCoreWebShared;  	 					  
using TgimbaNetCoreWebShared.Models;
using TgimbaNetCoreWebShared.Controllers;
using Shared.dto;
using System.Collections.Generic;

namespace TgimbaNetCoreWeb.Controllers
{
    #if !DEBUG
    [RequireHttpsAttribute]
    #endif
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
       
        [HttpGet]
        public List<SystemStatistic> GetSystemStatistics()
        {
            var result = this.service.GetSystemStatistics();
            return result;
        }
    }
}