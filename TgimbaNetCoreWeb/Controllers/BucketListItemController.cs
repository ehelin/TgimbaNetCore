using Microsoft.AspNetCore.Mvc;
using Shared.interfaces;		
using TgimbaNetCoreWebShared; 
using TgimbaNetCoreWebShared.Controllers;
using TgimbaNetCoreWebShared.Models;	
using System.Collections.Generic;   

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

        [HttpPost]
        public bool AddBucketListItem(SharedBucketListModel model, string encodedUser, string encodedToken)
        {
            return sharedBucketListController.AddBucketListItem(model, encodedUser,	encodedToken);
        }
		   
        [HttpGet]
        public List<SharedBucketListModel> GetBucketListItems(string encodedUserName, string encoderedSortString, string encodedToken)
        {
            return sharedBucketListController.GetBucketListItems(encodedUserName, encoderedSortString, encodedToken);
        }
    }
}
