using Microsoft.AspNetCore.Mvc;						  

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
	
		public IActionResult Index() 
		{
			return View();
		}
    }
}
