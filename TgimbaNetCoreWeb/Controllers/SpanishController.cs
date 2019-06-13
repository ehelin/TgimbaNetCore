using Microsoft.AspNetCore.Mvc;									 

namespace TgimbaNetCoreWeb.Controllers
{
    #if !DEBUG
    [RequireHttpsAttribute]
    #endif
    public class SpanishController : Controller
    {			
        public SpanishController() {}

        public IActionResult Index()
        {
            return View();
        }
    }
}