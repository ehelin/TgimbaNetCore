using Shared.interfaces;		
using TgimbaNetCoreWebShared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TgimbaNetCoreWebShared.Controllers
{
    public class SharedBucketListController : SharedBaseController
    {
		public SharedBucketListController(ITgimbaService service, IWebClient webClient)
            : base(service, webClient) { }

		[HttpPost]
		public bool AddBucketListItem(SharedBucketListModel bucketListItem, string encodedUser, string encodedToken)
		{
			var itemAdded = webClient.AddBucketListItem(bucketListItem, encodedUser, encodedToken);

			return itemAdded;
		}

		[HttpGet]
		public List<SharedBucketListModel> GetBucketListItems(string encodedUserName, string encodedSortString, string encodedToken) 
		{					
			var bucketListItem = webClient.GetBucketListItems(encodedUserName, encodedSortString, encodedToken);

			return bucketListItem;
		}
	}
}