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
        
        public bool AddBucketListItem(SharedBucketListModel bucketListItem, string userName, string token) 
		{
            var request = CreateAddEditRequest(bucketListItem, userName, token, true);

            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var url = host + "/api/tgimbaapi/upsert";
            var result = Post(url, content).Result;

            bool added = System.Convert.ToBoolean(result);

            return added;
		}

        public bool EditBucketListItem(SharedBucketListModel bucketListItem, string userName, string token)
        {
            var request = CreateAddEditRequest(bucketListItem, userName, token, false);

            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var url = host + "/api/tgimbaapi/upsert";
            var result = Post(url, content).Result;

            bool updated = System.Convert.ToBoolean(result);

            return updated;
        }		   

		public bool DeleteBucketListItem(string dbId, string userName, string token)
        {
            var url = host + "/api/tgimbaapi/delete";
            var query = "?EncodedUserName=" + SharedMisc.Utilities.EncodeClientBase64String(userName)
                            + "&EncodedToken=" + SharedMisc.Utilities.EncodeClientBase64String(token)
                            + "&BucketListItemId=" + dbId;
            var fullUrl = url + query;
            var result = Delete(fullUrl).Result;

            return System.Convert.ToBoolean(result);
        }

		public List<SharedBucketListModel> GetBucketListItems
		(
			string userName, 
			string sort, 
			string token,
			string search
		)
        {
            var url = host + "/api/tgimbaapi/getbucketlistitems";
            var query = "?EncodedUserName=" + SharedMisc.Utilities.EncodeClientBase64String(userName)
                + "&EncodedToken=" + SharedMisc.Utilities.EncodeClientBase64String(token)
                + "&EncodedSortString=" + SharedMisc.Utilities.EncodeClientBase64String(sort)
                + "&EncodedSearchString=" + SharedMisc.Utilities.EncodeClientBase64String(search);
            var fullUrl = url + query;
            var result = Get(fullUrl).Result;
            var bucketListItems = JsonConvert.DeserializeObject<List<BucketListItem>>(result);
            var convertedBucketListItems = Convert(bucketListItems, userName);

            return convertedBucketListItems;
        }

        private List<SharedBucketListModel> Convert(List<BucketListItem> bucketListItems, string userName)
        {
            var convertedBucketListItems = new List<SharedBucketListModel>();

            foreach(var bucketListItem in bucketListItems)
            {
                var convertedBucketListItem = new SharedBucketListModel()
                {
                    Name = bucketListItem.Name,
                    DateCreated = bucketListItem.Created.ToString(),
                    BucketListItemType = (SharedMisc.Enums.BucketListItemTypes)Enum.Parse(
                                                            typeof(SharedMisc.Enums.BucketListItemTypes), 
                                                                    bucketListItem.Category),
                    Completed = bucketListItem.Achieved,
                    Latitude = bucketListItem.Latitude.ToString(),
                    Longitude = bucketListItem.Longitude.ToString(),
                    DatabaseId = bucketListItem.Id.HasValue ? bucketListItem.Id.ToString() : null,
                    UserName = userName,
                };

                convertedBucketListItems.Add(convertedBucketListItem);
            }

            return convertedBucketListItems;
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

            bool registered = System.Convert.ToBoolean(result);

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

        #region Private methods

        private SharedApi.UpsertBucketListItemRequest CreateAddEditRequest
        (
            SharedBucketListModel bucketListItem,
            string userName,
            string token,
            bool isAdd
        )
        {
            var request = new SharedApi.UpsertBucketListItemRequest()
            {
                Token = new SharedApi.TokenRequest()
                {
                    EncodedToken = SharedMisc.Utilities.EncodeClientBase64String(token),
                    EncodedUserName = SharedMisc.Utilities.EncodeClientBase64String(userName)
                },
                BucketListItem = new BucketListItem()
                {
                    Name = bucketListItem.Name,
                    Created = System.DateTime.UtcNow,
                    Category = bucketListItem.BucketListItemType.ToString(),
                    Achieved = bucketListItem.Completed,
                    Latitude = System.Convert.ToDecimal(bucketListItem.Latitude),
                    Longitude = System.Convert.ToDecimal(bucketListItem.Longitude),
                    Id = isAdd ? (int?)null : System.Convert.ToInt32(bucketListItem.DatabaseId)
                }
            };

            return request;
        }

        #endregion
    }
}
