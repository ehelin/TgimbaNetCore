using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TgimbaNetCoreWebShared.Models;
using Shared.dto;

namespace TgimbaNetCoreWebShared.Controllers
{
    public class SharedBucketListController : SharedBaseController
    {
		public SharedBucketListController(IWebClient webClient)
            : base(webClient) { }

        [HttpGet]
        public InitializeResult Initialize(string userAgent)
        {
            var initializeResult = new InitializeResult()
            {
                IsMobile = Utilities.IsMobile(userAgent),
                AvailableSortingAlgorithms = Utilities.GetAvailableSortingAlgorithms(),
                AvailableSearchingAlgorithms = Utilities.GetAvailableSearchingAlgorithms()
            };

            return initializeResult;
        }

        [HttpPost]
		public bool AddBucketListItem(SharedBucketListModel model, string encodedUser, string encodedToken)
		{ 
			var itemAdded = webClient.AddBucketListItem(model, encodedUser, encodedToken);

			return itemAdded;
		}
	
		[HttpPost]
		public bool EditBucketListItem(SharedBucketListModel model, string encodedUser, string encodedToken)
		{ 
			var itemEdited = webClient.EditBucketListItem(model, encodedUser, encodedToken);

			return itemEdited;
		}
			   
		[HttpDelete]
		public bool DeleteBucketListItem(string dbIt, string encodedUser, string encodedToken)
		{ 
			var itemDeleted = webClient.DeleteBucketListItem(dbIt, encodedUser, encodedToken);

			return itemDeleted;
		}

		[HttpGet]
		public List<SharedBucketListModel> GetBucketListItems
		(
			string encodedUserName, 
			string encodedSortString, 
			string encodedToken,
			string encodedSrchTerm = "",
            string encodedSortType = "",
            string encodedSearchType = ""
        ) 
		{					
			var bucketListItem = webClient.GetBucketListItems
			(
				encodedUserName, 
				encodedSortString, 
				encodedToken, 
				encodedSrchTerm,
                encodedSortType,
                encodedSearchType
            );

			return bucketListItem;
		}
	}
}