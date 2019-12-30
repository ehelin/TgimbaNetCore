using Microsoft.AspNetCore.Mvc;

namespace TgimbaNetCoreWebShared.Controllers
{
    public class SharedWelcomeController : SharedBaseController
    {
        public SharedWelcomeController(IWebClient webClient)
            : base(webClient) { }

        public IActionResult Index()
        {
            return View();
        }
    }
}