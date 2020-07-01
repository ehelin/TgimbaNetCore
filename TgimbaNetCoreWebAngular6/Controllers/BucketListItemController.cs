using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Shared.dto;
using TgimbaNetCoreWebShared;
using TgimbaNetCoreWebShared.Controllers;
using TgimbaNetCoreWebShared.Models;

namespace TgimbaNetCoreWeb.Controllers
{
#if !DEBUG
    [RequireHttpsAttribute]
#endif
    public class BucketListItemController : Controller
    {
        private SharedBucketListController sharedBucketListController = null;
		private IWebClient client;

		public BucketListItemController(IWebClient webClient)
        {
            sharedBucketListController = new SharedBucketListController(webClient);
			this.client = webClient;
			this.client.LogMessage("BucketListItemController Constructor");
		}

		[HttpGet]
		public InitializeResult Initialize(string userAgent)
		{
			this.client.LogMessage("BucketListItemController Initialize(args)");
			return sharedBucketListController.Initialize(userAgent);
		}

		[HttpPost]
		public bool AddBucketListItem(string Name, string DateCreated, string BucketListItemType, string Completed,
									string Latitude, string Longitude, string DatabaseId, string UserName,
									string encodedUser, string encodedToken)
		{
			var model = ConvertArgsToModel(Name, DateCreated, BucketListItemType, Completed,
												Latitude, Longitude, DatabaseId, UserName);

			return sharedBucketListController.AddBucketListItem(model, encodedUser, encodedToken);
		}

		[HttpPost]
		public bool EditBucketListItem(string Name, string DateCreated, string BucketListItemType, string Completed,
									string Latitude, string Longitude, string DatabaseId, string UserName,
									string encodedUser, string encodedToken)
		{
			var model = ConvertArgsToModel(Name, DateCreated, BucketListItemType, Completed,
												Latitude, Longitude, DatabaseId, UserName);

			return sharedBucketListController.EditBucketListItem(model, encodedUser, encodedToken);
		}

		[HttpDelete]
		public bool DeleteBucketListItem(int id)
		{
			return this.sharedBucketListController.DeleteBucketListItem
			(
				id.ToString(),
				Utilities.GetHeaderValue("EncodedUserName", this.Request),
				Utilities.GetHeaderValue("EncodedToken", this.Request)
			 );
		}

		[HttpGet]
		public List<SharedBucketListModel> GetBucketListItems
		(
			string encodedUserName,
			string encoderedSortString,
			string encodedToken,
			string encodedSrchTerm = "",
			string encodedSortType = "",
			string encodedSearchType = ""
		)
		{
			var result = sharedBucketListController.GetBucketListItems(encodedUserName,
																	   encoderedSortString,
																	   encodedToken,
																	   encodedSrchTerm,
																	   encodedSortType,
																	   encodedSearchType);
			return result;
		}

		// TODO - temp solution - figure out why Vanilla javascript model has null values
		private SharedBucketListModel ConvertArgsToModel(string Name, string DateCreated, string BucketListItemType, string Completed,
														string Latitude, string Longitude, string DatabaseId, string UserName)
		{
			var model = new SharedBucketListModel()
			{
				Name = Name,
				DateCreated = DateCreated,
				BucketListItemType = Utilities.ConvertCategoryToEnum(BucketListItemType),
				Completed = System.Convert.ToBoolean(Completed),
				Latitude = Latitude,
				Longitude = Longitude,
				DatabaseId = DatabaseId,
				UserName = UserName
			};

			return model;
		}

	}
}
