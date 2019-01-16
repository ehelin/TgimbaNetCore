using Microsoft.AspNetCore.Mvc;
using Shared.interfaces;		 
using SharedControllers = TgimbaNetCoreWebShared.Controllers;	
using SharedModels = TgimbaNetCoreWebShared.Models;

namespace TgimbaNetCoreWeb.Controllers
{				 
	//[RequireHttpsAttribute]
    public class HomeController : Controller
    {                    
        public IActionResult HtmlVanillaJsIndex()
        {
            return View();
        }
 
        public IActionResult HtmlJQueryIndex()
        {
            return View();
        }
    }
}
