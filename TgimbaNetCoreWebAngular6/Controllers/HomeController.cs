using Microsoft.AspNetCore.Mvc;               
using Shared.interfaces;   
using SharedControllers = TgimbaNetCoreWebShared.Controllers;
using Microsoft.AspNetCore.Mvc;
using Shared.interfaces;
using TgimbaNetCoreWebShared;
using TgimbaNetCoreWebShared.Models;
using TgimbaNetCoreWebShared.Controllers;

namespace TgimbaNetCoreWebAngular6.Controllers
{
#if !DEBUG
    [RequireHttpsAttribute]
#endif
    public class HomeController : Controller
    {
        private IWebClient client;

        //public HomeController() {}
        public HomeController(IWebClient webClient)
        {
            this.client = webClient;
            this.client.LogMessage("HomeController Constructor");
        }

        public IActionResult Index()
        {
            this.client.LogMessage("HomeController Index()");
            return View();
        }

    }
}
