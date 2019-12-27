using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Shared.dto;
using Shared.interfaces;
using TgimbaNetCoreWebShared.Models;
using SharedMisc = Shared.misc;
using SharedApi = Shared.dto.api;
using Newtonsoft.Json;

namespace TgimbaNetCoreWebShared
{
    public class WebClient : IWebClient
    {
        private string host = null;        

        public WebClient(string host)
        {
            this.host = host;
        }

        private string CreateTokenQueryString(string token, string userName)
        {
            var query = "?encodedUser=" + SharedMisc.Utilities.EncodeClientBase64String(userName)
               + "&encodedToken=" + SharedMisc.Utilities.EncodeClientBase64String(token);

            return query;
        }

        public List<SystemStatistic> GetSystemStatistics(string userName, string token)
        {
            var url = host + "/api/tgimbaapi/getsystemstatistics"; 
            var query = CreateTokenQueryString(token, userName);
            var fullUrl = url + query;
            var result = Get(fullUrl).Result;

            var systemStatistics = JsonConvert.DeserializeObject<List<SystemStatistic>>(result);

            return systemStatistics;
        }

        public List<SystemBuildStatistic> GetSystemBuildStatistics(string userName, string token)
        {
            var url = host + "/api/tgimbaapi/getsystemstatistics";
            var query = CreateTokenQueryString(token, userName);
            var fullUrl = url + query;
            var result = Get(fullUrl).Result;

            var systemBuildStatistics = JsonConvert.DeserializeObject< List<SystemBuildStatistic>>(result);

            return systemBuildStatistics;
        }
        
        public bool AddBucketListItem(SharedBucketListModel bucketListItem, string encodedUser, string encodedToken) 
		{
            // TODO - convert bucket list item to one used by API
            // TODO - create request
            // TODO - make upsert call
            // TODO - parse and return the result
            throw new NotImplementedException();

			//var bucketListItemArray = Utilities.ConvertModelToString(bucketListItem);
			//var bucketListItemArrayBase64 = Shared.misc.Utilities.EncodeClientBase64String(bucketListItemArray);

			//var result = this.service.UpsertBucketListItemV2(bucketListItemArrayBase64, encodedUser, encodedToken);

			//if (result != null && result.Length == 1 && result[0] == "TokenValid")
			//{		 
			//	return true;
			//}
			//else 
			//{	   
			//	return false;
			//}				
		}

		public bool EditBucketListItem(SharedBucketListModel bucketListItem, string encodedUser, string encodedToken)
        {
            // TODO - convert bucket list item to one used by API
            // TODO - create request
            // TODO - make upsert call
            // TODO - parse and return the result
            throw new NotImplementedException();

            //var bucketListItemArray = Utilities.ConvertModelToString(bucketListItem);
            //var bucketListItemArrayBase64 = Shared.misc.Utilities.EncodeClientBase64String(bucketListItemArray);

            //var result = this.service.UpsertBucketListItemV2(bucketListItemArrayBase64, encodedUser, encodedToken);

            //if (result != null && result.Length == 1 && result[0] == "TokenValid")
            //{		 
            //	return true;
            //}
            //else 
            //{	   
            //	return false;
            //}	
        }		   

		public bool DeleteBucketListItem(string dbId, string encodedUser, string encodedToken)
        {
            // TODO - create request
            // TODO - make delete call
            // TODO - parse and return the result
            throw new NotImplementedException();

            //int databaseId = Convert.ToInt32(dbId);
            //var result = this.service.DeleteBucketListItem(databaseId, encodedUser, encodedToken);

            //if (result != null && result.Length == 1 && result[0] == "TokenValid")
            //{		 
            //	return true;
            //}
            //else 
            //{	   
            //	return false;
            //}	
        }

		public List<SharedBucketListModel> GetBucketListItems
		(
			string encodedUserName, 
			string encodedSortString, 
			string encodedToken,
			string encodedSrchTerm
		)
        {
            // TODO - create request
            // TODO - make get call
            // TODO - parse and return the result
            throw new NotImplementedException();

            //var result = this.service.GetBucketListItemsV2(encodedUserName, encodedSortString, encodedToken, encodedSrchTerm);	  														   
            //var list = Utilities.ConvertStringArrayToModelList(result, encodedUserName);		   

            //return list;
        }

        public string Login(string userName, string password)
        {
            var request = new SharedApi.LoginRequest()
            {
                EncodedUserName = SharedMisc.Utilities.EncodeClientBase64String(userName),
                EncodedPassword = SharedMisc.Utilities.EncodeClientBase64String(password)
            };

            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var url = host + "/api/tgimbaapi/processuser";
            var token = Post(url, content).Result;

            return token;
        }

		public bool Registration(
			string userName, 
			string email, 
			string password
		) {
            var request = new SharedApi.RegistrationRequest()
            {
                Login = new SharedApi.LoginRequest()
                {
                    EncodedUserName = SharedMisc.Utilities.EncodeClientBase64String(userName),
                    EncodedPassword = SharedMisc.Utilities.EncodeClientBase64String(password)
                },
                EncodedEmail = SharedMisc.Utilities.EncodeClientBase64String(email)
            };

            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var url = host + "/api/tgimbaapi/processuserregistration";
            var result = Post(url, content).Result;

            bool registered = Convert.ToBoolean(result);

            return registered;
		}

        #region Http methods

        private async Task<string> Delete(string url)
        {
            var client = new HttpClient();

            var response = await client.DeleteAsync(url);

            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        private async Task<string> Post(string url, StringContent content)
        {
            var client = new HttpClient();

            var response = await client.PostAsync(url, content);

            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        private async Task<string> Get(string url)
        {
            var client = new HttpClient();

            var response = await client.GetAsync(url);

            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        #endregion
    }
}
