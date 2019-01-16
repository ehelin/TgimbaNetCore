using Shared.interfaces;		
using TgimbaNetCoreWebShared.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TgimbaNetCoreWebShared.Controllers
{
    public class SharedBucketListController : SharedBaseController
    {
		public SharedBucketListController(ITgimbaService service, IWebClient webClient)
            : base(service, webClient) { }

		[HttpPost]
		public bool AddBucketListItem()
		{
			throw new NotImplementedException();
		}

		[HttpGet]
		public SharedBucketListModel GetBucketListItems()
		{
			throw new NotImplementedException();
		}
	}
}