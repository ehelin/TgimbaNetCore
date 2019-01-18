using Shared.interfaces;
using System;
using TgimbaNetCoreWebShared.Models;
using System.Collections.Generic;

namespace TgimbaNetCoreWebShared
{
    public class WebClient : IWebClient
    {
        private ITgimbaService service = null;

        public WebClient(ITgimbaService service)
        {
            this.service = service;
        }

		public bool AddBucketListItem(SharedBucketListModel bucketListItem, string encodedUser, string encodedToken) 
		{
			var bucketListItemArray = Utilities.ConvertModelToString(bucketListItem);

			var result = this.service.UpsertBucketListItemV2(bucketListItemArray, encodedUser, encodedToken);

			if (result != null && result.Length == 1 && result[0] == "TokenValid")
			{		 
				return true;
			}
			else 
			{	   
				return false;
			}				
		}

		public List<SharedBucketListModel> GetBucketListItems
		(
			string encodedUserName, 
			string encodedSortString, 
			string encodedToken
		){	 											
			var result = this.service.GetBucketListItemsV2(encodedUserName, encodedSortString, encodedToken);
			
			// TODO - handle multiple bucket list items
			var convertedModel = Utilities.ConvertStringArrayToModel(result);
			var list = new List<SharedBucketListModel>();
			list.Add(convertedModel);

			return list;
		}

        public string Login(string encodedUser, string encodedPass)
        {
            string token = string.Empty;

            token = service.ProcessUser(encodedUser, encodedPass);

            return token;
        }

		// Encrypt username/email/password/and all data points
		public bool Registration(
			string encodedUser, 
			string encodedEmail, 
			string encodedPassword
		) {
			bool registered = false;

			registered = service.ProcessUserRegistration(encodedUser, encodedEmail, encodedPassword);

			return registered;
		} 

		public string[] AddBucketListItem(
			string encodedBucketListItems, 
			string encodedUser, 
			string encodedToken
		)
		{
			string[] items = service.UpsertBucketListItemV2(encodedBucketListItems, encodedUser, encodedToken);
			
			return items;
		}
	}
}
