using Shared.interfaces;
using System;
using TgimbaNetCoreWebShared.Models;
using System.Collections.Generic;
using Shared.dto;

namespace TgimbaNetCoreWebShared
{
    public class WebClient : IWebClient
    {
        private ITgimbaService service = null;

        public WebClient(ITgimbaService service)
        {
            this.service = service;
        }

        public List<SystemStatistic> GetSystemStatistics()
        {
            var results = this.service.GetSystemStatistics();

            return results;
        }

        public List<SystemBuildStatistic> GetSystemBuildStatistics()
        {
            var results = this.service.GetSystemBuildStatistics();

            return results;
        }
        
        public bool AddBucketListItem(SharedBucketListModel bucketListItem, string encodedUser, string encodedToken) 
		{
			var bucketListItemArray = Utilities.ConvertModelToString(bucketListItem);
			var bucketListItemArrayBase64 = Shared.misc.Utilities.EncodeClientBase64String(bucketListItemArray);

			var result = this.service.UpsertBucketListItemV2(bucketListItemArrayBase64, encodedUser, encodedToken);

			if (result != null && result.Length == 1 && result[0] == "TokenValid")
			{		 
				return true;
			}
			else 
			{	   
				return false;
			}				
		}

		public bool EditBucketListItem(SharedBucketListModel bucketListItem, string encodedUser, string encodedToken)
		{										
			var bucketListItemArray = Utilities.ConvertModelToString(bucketListItem);
			var bucketListItemArrayBase64 = Shared.misc.Utilities.EncodeClientBase64String(bucketListItemArray);

			var result = this.service.UpsertBucketListItemV2(bucketListItemArrayBase64, encodedUser, encodedToken);

			if (result != null && result.Length == 1 && result[0] == "TokenValid")
			{		 
				return true;
			}
			else 
			{	   
				return false;
			}	
		}		   

		public bool DeleteBucketListItem(string dbId, string encodedUser, string encodedToken)
		{										  
			int databaseId = Convert.ToInt32(dbId);
			var result = this.service.DeleteBucketListItem(databaseId, encodedUser, encodedToken);

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
			string encodedToken,
			string encodedSrchTerm
		){	 											
			var result = this.service.GetBucketListItemsV2(encodedUserName, encodedSortString, encodedToken, encodedSrchTerm);	  														   
			var list = Utilities.ConvertStringArrayToModelList(result, encodedUserName);		   

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
	}
}
