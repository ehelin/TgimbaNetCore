using Microsoft.AspNetCore.Mvc;               
using Shared.interfaces;   
using SharedControllers = TgimbaNetCoreWebShared.Controllers;

namespace TgimbaNetCoreWeb.Controllers
{		  				
    public class HomeController : Controller
    {                                      
		public HomeController() {}

        public IActionResult Index()
        {
            return View();
        }         
    }
}
