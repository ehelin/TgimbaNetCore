using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Shared.dto.api;
using Shared.dto;
using Shared.misc;
using System.Collections.Generic;

namespace API_IntegrationTests
{
    [TestClass]
    public class HappyPathTests
    {
        private string host = "https://localhost:44363";
        private string userName = null;
        private string password = "wilmaRules87&";
        private string email = "fred@bedrock.com";

        private void SetUser()
        {
            var guid = System.Guid.NewGuid().ToString();
            this.userName = "fredFlintstone" + guid;
        }

        [TestMethod]
        public void HappyPathTest()
        {
            SetUser();

            EndPoint_Register();
            var token = EndPoint_Login();
            var resultBeforeUpsert = EndPoint_Get(token);
            Assert.IsNotNull(resultBeforeUpsert);
            Assert.IsTrue(resultBeforeUpsert.Count == 0);

            EndPoint_Upsert(token);

            var resultsAfterUpsert = EndPoint_Get(token);
            Assert.IsNotNull(resultsAfterUpsert);
            Assert.IsTrue(resultsAfterUpsert.Count == 1);
            var bucketListItem = resultsAfterUpsert[0];

            EndPoint_Delete(token, bucketListItem.Id);

            var resultsAfterDelete = EndPoint_Get(token);
            Assert.IsNotNull(resultBeforeUpsert);
            Assert.IsTrue(resultBeforeUpsert.Count == 0);

            //TODO - add requests for each call and make sure each one uses a token
            //EndPoint_TestPage();
        }

        private void EndPoint_Register()
        {            
            var request = new RegistrationRequest() 
            {
                Login = new LoginRequest() 
                { 
                    EncodedUserName = Base64Encode(userName),
                    EncodedPassword = Base64Encode(password)
                },
                EncodedEmail = Base64Encode(email)
            };
            
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var url = host + "/api/tgimbaapi/processuserregistration";
            var result = Post(url, content).Result;

            Assert.AreEqual(true, System.Convert.ToBoolean(result));
        }
        private string EndPoint_Login()
        {
            var request =  new LoginRequest()
            {
                EncodedUserName = Base64Encode(userName),
                EncodedPassword = Base64Encode(password)
            };

            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var url = host + "/api/tgimbaapi/processuser";
            var token = Post(url, content).Result;

            Assert.AreEqual(true, token.Length > 1);

            return token;
        }
        private List<BucketListItem> EndPoint_Get(string token)
        {
            var url = host + "/api/tgimbaapi/getbucketlistitems";
            var query = CreateGetRequest(token, this.userName, "", "");
            var fullUrl = url + query;
            var result = Get(fullUrl).Result;
            var bucketListItems = JsonConvert.DeserializeObject<List<BucketListItem>>(result);
            
            return bucketListItems;
        }
        private void EndPoint_Upsert(string token)
        {
            var request = CreateUpsertRequest(token);
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var url = host + "/api/tgimbaapi/upsert";
            var result = Post(url, content).Result;

            Assert.AreEqual(true, System.Convert.ToBoolean(result));
        }
        private void EndPoint_Delete(string token, int id)
        {
            var url = host + "/api/tgimbaapi/delete";
            var query = CreateDeleteRequest(token, userName, id);
            var fullUrl = url + query;
            var result = Delete(fullUrl).Result;

            Assert.AreEqual(true, System.Convert.ToBoolean(result));
        }

        // TODO - add requests to test page and all other endpoints to currently expecting a token...they need to take a token
        private void EndPoint_TestPage()
        {
            var url = host + "/api/tgimbaapi/test";
            var result = Get(url).Result;

            Assert.AreEqual("Test Service Response", result);
        }

        #region Http methods

        private async Task<string> Delete(string url)
        {
            var client = new HttpClient();

            var response = await client.DeleteAsync(url);
            CheckStatus(response);

            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        private async Task<string> Post(string url, StringContent content)
        {
            var client = new HttpClient();

            var response = await client.PostAsync(url, content);
            CheckStatus(response);

            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        private async Task<string> Get(string url)
        {
            var client = new HttpClient();

            var response = await client.GetAsync(url);
            CheckStatus(response);

            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        #endregion

        #region Private methods

        private void CheckStatus(HttpResponseMessage response)
        {
            Assert.IsNotNull(response);
            
            //Assume everything completes ok
            Assert.AreEqual(200, (int)response.StatusCode);  
        }

        private string Base64Encode(string value)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(value);
            return System.Convert.ToBase64String(data);
        }

        private UpsertBucketListItemRequest CreateUpsertRequest(string token)
        {
            var request = new UpsertBucketListItemRequest()
            {
                Token = new TokenRequest()
                {
                    EncodedToken = Base64Encode(token),
                    EncodedUserName = Base64Encode(userName)
                },
                BucketListItem = new BucketListItem()
                {
                    Name = "IAmABucketListItem",
                    Created = System.DateTime.UtcNow,
                    Category = Enums.BucketListItemTypes.Warm.ToString(),
                    Achieved = false,
                    Latitude = (decimal)1.1,
                    Longitude = (decimal)1.2
                }
            };

            return request;
        }
        private string CreateGetRequest(string token, string userName, string sort, string search)
        {
            var query = "?EncodedUserName=" + Base64Encode(userName)
                + "&EncodedToken=" + Base64Encode(token)
                + "&EncodedSortString=" + Base64Encode(sort)
                + "&EncodedSearchString=" +  Base64Encode(search);

            return query;
        }
        private string CreateDeleteRequest(string token, string userName, int id)
        {
            var query = "?EncodedUserName=" + Base64Encode(userName)
                + "&EncodedToken=" + Base64Encode(token)
                + "&BucketListItemId=" + id.ToString();

            return query;
        }

        #endregion
    }
}
