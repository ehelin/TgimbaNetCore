using Microsoft.AspNetCore.Mvc;									 

namespace TgimbaNetCoreWeb.Controllers
{
    public class SpanishController : Controller
    {			
        public SpanishController() {}

        public IActionResult Index()
        {
            return View();
        }
    }
}