using Microsoft.AspNetCore.Mvc;
using Shared.interfaces;	  

namespace TgimbaNetCoreWebShared.Controllers
{
    public class SharedBaseController : Controller
    {
        protected ITgimbaService service = null;
		protected IWebClient webClient = null;

        public SharedBaseController(ITgimbaService service, IWebClient webClient)
        {
            this.service = service;
			this.webClient = webClient;
        }
    }
}