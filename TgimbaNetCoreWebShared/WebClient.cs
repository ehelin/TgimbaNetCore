using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Shared.dto;
using TgimbaNetCoreWebShared.Models;
using SharedApi = Shared.dto.api;
using SharedMisc = Shared.misc;

namespace TgimbaNetCoreWebShared
{
    public class WebClient : IWebClient
    {
        private string host = null;
        private ITgimbaHttpClient httpClient = null;

        public WebClient(string host, ITgimbaHttpClient httpClient)
        {
            this.host = host;
            this.httpClient = httpClient;
        }

        public List<SystemStatistic> GetSystemStatistics()
        {
            var url = host + "/api/tgimbaapi/getsystemstatistics";
            var token = DemoUserLogin();

            var result = httpClient.Get(url,
                Shared.misc.Utilities.EncodeClientBase64String(Shared.Constants.DEMO_USER),
                Shared.misc.Utilities.EncodeClientBase64String(token));

            var systemStatistics = JsonConvert.DeserializeObject<List<SystemStatistic>>(result);

            return systemStatistics;
        }

        private string DemoUserLogin()
        {
            var encodedUser = Shared.misc.Utilities.EncodeClientBase64String(Shared.Constants.DEMO_USER);
            var encodedPassword = Shared.misc.Utilities.EncodeClientBase64String(Shared.Constants.DEMO_USER_PASSWORD);

            var token = this.Login(encodedUser, encodedPassword);

            return token;
        }

        public List<SystemBuildStatistic> GetSystemBuildStatistics()
        {
            var url = host + "/api/tgimbaapi/getsystembuildstatistics";
            var token = DemoUserLogin();
   
            var result = httpClient.Get(url,
                Shared.misc.Utilities.EncodeClientBase64String(Shared.Constants.DEMO_USER),
                Shared.misc.Utilities.EncodeClientBase64String(token));

            var systemBuildStatistics = JsonConvert.DeserializeObject<List<SystemBuildStatistic>>(result);

            return systemBuildStatistics;
        }
        
        public bool AddBucketListItem(SharedBucketListModel bucketListItem, string encodedUserName, string encodedToken) 
		{
            var request = CreateAddEditRequest(bucketListItem, encodedUserName, encodedToken, true);

            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var url = host + "/api/tgimbaapi/upsert";

            var result = httpClient.Post(url, content);

            bool added = System.Convert.ToBoolean(result);

            return added;
		}

        public bool EditBucketListItem(SharedBucketListModel bucketListItem, string encodedUserName, string encodedToken)
        {
            var request = CreateAddEditRequest(bucketListItem, encodedUserName, encodedToken, false);

            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var url = host + "/api/tgimbaapi/upsert";

            var result = httpClient.Post(url, content);

            bool updated = System.Convert.ToBoolean(result);

            return updated;
        }		   

		public bool DeleteBucketListItem(string dbId, string encodedUserName, string encodedToken)
        {
            var url = host + "/api/tgimbaapi/delete";

            var result = httpClient.Delete(url, encodedUserName, encodedUserName);

            return System.Convert.ToBoolean(result);
        }

		public List<SharedBucketListModel> GetBucketListItems
		(
			string encodedUserName, 
			string encodedSort, 
			string encodedToken,
			string encodedSearch,
            string encodedSortType,
            string encodedSearchType
        )
        {
            var url = host + "/api/tgimbaapi/getbucketlistitems";
            var query = "?EncodedUserName=" + encodedUserName
                + "&EncodedToken=" + encodedToken
                + "&EncodedSortString=" + encodedSort
                + "&EncodedSearchString=" + encodedSearch
                + "&EncodedSortType=" + encodedSortType
                + "&EncodedSearchType=" + encodedSearchType;
            
            var fullUrl = url + query;

            var result = httpClient.Get(fullUrl);

            var bucketListItems = JsonConvert.DeserializeObject<List<BucketListItem>>(result);

            List<SharedBucketListModel> convertedBucketListItems = null;
            if (bucketListItems != null && bucketListItems.Count > 0)
            {
                convertedBucketListItems = Convert(bucketListItems, encodedUserName);
            }

            return convertedBucketListItems;
        }

        public string Login(string encodedUserName, string encodedPassword)
        {
            var request = new SharedApi.LoginRequest()
            {
                EncodedUserName = encodedUserName,
                EncodedPassword = encodedPassword
            };

            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var url = host + "/api/tgimbaapi/processuser";

            var token = httpClient.Post(url, content);

            return token;
        }

		public bool Registration(
			string encodedUserName, 
			string encodedEmail, 
			string eoncodedPassword
		) 
        {
            var request = new SharedApi.RegistrationRequest()
            {
                Login = new SharedApi.LoginRequest()
                {
                    EncodedUserName = encodedUserName, 
                    EncodedPassword = eoncodedPassword 
                },
                EncodedEmail = encodedEmail
            };

            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var url = host + "/api/tgimbaapi/processuserregistration";

            var result = httpClient.Post(url, content);

            bool registered = System.Convert.ToBoolean(result);

            return registered;
		}
        
        #region Private methods
               
        private string CreateTokenQueryString(string encodedToken, string encodedUserName)
        {
            var query = "?encodedUser=" + encodedUserName
               + "&encodedToken=" + encodedToken;

            return query;
        }

        private List<SharedBucketListModel> Convert(List<BucketListItem> bucketListItems, string encodedUserName)
        {
            var convertedBucketListItems = new List<SharedBucketListModel>();

            foreach (var bucketListItem in bucketListItems)
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
                    UserName = Shared.misc.Utilities.DecodeClientBase64String(encodedUserName),
                };

                convertedBucketListItems.Add(convertedBucketListItem);
            }

            return convertedBucketListItems;
        }

        private SharedApi.UpsertBucketListItemRequest CreateAddEditRequest
        (
            SharedBucketListModel bucketListItem,
            string encodedUserName,
            string encodedToken,
            bool isAdd
        )
        {
            var request = new SharedApi.UpsertBucketListItemRequest()
            {
                Token = new SharedApi.TokenRequest()
                {
                    EncodedToken = encodedToken,
                    EncodedUserName = encodedUserName
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
