using Microsoft.AspNetCore.Mvc;
using Shared.dto;
using Shared.interfaces;
using TgimbaNetCoreWebShared;
using TgimbaNetCoreWebShared.Controllers;

namespace TgimbaNetCoreWeb.Controllers
{
#if !DEBUG
    [RequireHttpsAttribute]
#endif
    public class WelcomeController : Controller
    {
		private SharedWelcomeController sharedWelcomeController = null;

        public WelcomeController(IWebClient webClient)
        {
			sharedWelcomeController = new SharedWelcomeController(webClient);
		}

        public IActionResult Index()
        {
            return View();
        }
       
        [HttpGet]
        public SystemStatistics GetSystemStatistics()
        {
            var systemStatistics = new SystemStatistics();

            systemStatistics.SystemStats = this.sharedWelcomeController.webClient.GetSystemStatistics();
            systemStatistics.SystemBuildStats = this.sharedWelcomeController.webClient.GetSystemBuildStatistics();

            return systemStatistics;
        }
    }
}