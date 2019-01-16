using Microsoft.AspNetCore.Mvc;									 

namespace TgimbaNetCoreWeb.Controllers
{ 
	//[RequireHttpsAttribute]
    public class SpanishController : Controller
    {			
        public SpanishController() {}

        public IActionResult Index()
        {
            return View();
        }
    }
}