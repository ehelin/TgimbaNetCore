using Microsoft.AspNetCore.Mvc;
using Shared.interfaces;		
using TgimbaNetCoreWebShared; 
using TgimbaNetCoreWebShared.Controllers;	   

namespace TgimbaNetCoreWeb.Controllers
{				 
	//[RequireHttpsAttribute]
    public class BucketListItemController : Controller
    {
		private SharedBucketListController sharedBucketListController = null;

        public BucketListItemController(ITgimbaService service, IWebClient webClient)
        {
			sharedBucketListController = new SharedBucketListController(service, webClient);
		}
    }
}
