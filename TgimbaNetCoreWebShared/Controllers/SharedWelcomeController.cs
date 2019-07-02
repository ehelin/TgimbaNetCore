using Microsoft.AspNetCore.Mvc;
using TgimbaNetCoreWebShared.Models;
using Shared.interfaces;

namespace TgimbaNetCoreWebShared.Controllers
{
    public class SharedWelcomeController : SharedBaseController
    {
        public SharedWelcomeController(ITgimbaService service, IWebClient webClient)
            : base(service, webClient) { }

        public IActionResult Index()
        {
            //SharedWelcomeModel model = new SharedWelcomeModel(this.service);
            return View();
        }
    }
}