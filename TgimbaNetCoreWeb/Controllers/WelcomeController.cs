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
		private ITgimbaService_Old service = null;

        public WelcomeController(ITgimbaService_Old service, IWebClient webClient)
        {
			sharedWelcomeController = new SharedWelcomeController(service, webClient);
			this.service = service;
		}

        public IActionResult Index()
        {
            return View();
        }
       
        [HttpGet]
        public SystemStatistics GetSystemStatistics()
        {
            var systemStatistics = new SystemStatistics();

            systemStatistics.SystemStats = this.service.GetSystemStatistics();
            systemStatistics.SystemBuildStats = this.service.GetSystemBuildStatistics();

            return systemStatistics;
        }
    }
}