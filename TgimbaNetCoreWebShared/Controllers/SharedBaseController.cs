using Microsoft.AspNetCore.Mvc;
using Shared.interfaces;	  

namespace TgimbaNetCoreWebShared.Controllers
{
    public class SharedBaseController : Controller
    {
        protected ITgimbaService_Old service = null;
		protected IWebClient webClient = null;

        public SharedBaseController(ITgimbaService_Old service, IWebClient webClient)
        {
            this.service = service;
			this.webClient = webClient;
        }
    }
}