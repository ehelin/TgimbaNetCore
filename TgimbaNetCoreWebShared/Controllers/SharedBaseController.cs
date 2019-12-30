using Microsoft.AspNetCore.Mvc;
using Shared.interfaces;	  

namespace TgimbaNetCoreWebShared.Controllers
{
    public class SharedBaseController : Controller
    {
        // TODO - needs to be callable from vanilla javascript, typescript and react project controllers...does it have to be public?
		public IWebClient webClient = null;

        public SharedBaseController(IWebClient webClient)
        {
			this.webClient = webClient;
        }
    }
}