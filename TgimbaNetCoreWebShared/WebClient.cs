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

		public bool AddBucketListItem(SharedBucketListModel bucketListItem) {
			// TODO - handle the model to string[] conversion
			throw new NotImplementedException();
		}

		public List<SharedBucketListModel> GetBucketListItems
		(
			string encodedUserName, 
			string encodedSortString, 
			string encodedToken
		){	 											
			// TODO - handle the string[] to model conversion
			throw new NotImplementedException();
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
