using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Shared.dto;
using Shared.dto.api;
using Shared.misc;

namespace API_IntegrationTests
{
    [TestClass]
    public class HappyPathTests
    {
        private string host = "http://www.tgimba.com/api/TgimbaApi/";
        private string userName = "fredFlintstone";
        private string password = "wilmaRules87&";
        private string email = "fred@bedrock.com";

        private void CleanUser()
        {
            var utilities = new Shared.misc.testUtilities.TestUtilities();
            utilities.CleanUpLocal(userName);
        }

        [TestMethod]
        public void HappyPathTest()
        {
            EndPoint_TestPage();
            CleanUser();

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

            EndPoint_Delete(token, bucketListItem.Id.Value);

            var resultsAfterDelete = EndPoint_Get(token);
            Assert.IsNotNull(resultBeforeUpsert);
            Assert.IsTrue(resultBeforeUpsert.Count == 0);

            //misc endpoints
            EndPoint_GetSystemStatistics(token);
            EndPoint_GetSystemBuildStatistics(token);
            EndPoint_Log(token);
            EndPoint_TestPage();

            CleanUser();
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
            var url = host + "processuserregistration";
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
            var url = host + "processuser";
            var token = Post(url, content).Result;

            Assert.AreEqual(true, token.Length > 1);

            return token;
        }
        private List<BucketListItem> EndPoint_Get(string token)
        {
            var url = host + "getbucketlistitems";
            var query = CreateGetQueryString(token, this.userName, "", "");
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
            var url = host + "upsert";
            var result = Post(url, content).Result;

            Assert.AreEqual(true, System.Convert.ToBoolean(result));
        }
        private void EndPoint_Delete(string token, int id)
        {
            var url = host + "delete";
            var query = CreateDeleteQueryString(token, userName, id);
            var fullUrl = url + query;
            var result = Delete(fullUrl).Result;

            Assert.AreEqual(true, System.Convert.ToBoolean(result));
        }
        private void EndPoint_GetSystemStatistics(string token)
        {
            var url = host + "getsystemstatistics";
            var query = CreateTokenQueryString(token, userName);
            var fullUrl = url + query;
            var result = Get(fullUrl).Result;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length > 1);  // Convert to object and check for params?
        }
        private void EndPoint_GetSystemBuildStatistics(string token)
        {
            var url = host + "getsystembuildstatistics";
            var query = CreateTokenQueryString(token, userName);
            var fullUrl = url + query;
            var result = Get(fullUrl).Result;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length > 1);  // Convert to object and check for params?
        }
        private void EndPoint_Log(string token)
        {
            var request = new LoginRequest()
            {
                EncodedUserName = Base64Encode(userName),
                EncodedPassword = Base64Encode(password)
            };

            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var url = host + "log";

            // Test is if a 200 returns
            Post(url, content);    
        }
        private void EndPoint_TestPage()
        {
            var url = host + "test";
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
        private string CreateGetQueryString(string token, string userName, string sort, string search)
        {
            var query = "?EncodedUserName=" + Base64Encode(userName)
                + "&EncodedToken=" + Base64Encode(token)
                + "&EncodedSortString=" + Base64Encode(sort)
                + "&EncodedSearchString=" +  Base64Encode(search);

            return query;
        }
        private string CreateDeleteQueryString(string token, string userName, int id)
        {
            var query = "?EncodedUserName=" + Base64Encode(userName)
                + "&EncodedToken=" + Base64Encode(token)
                + "&BucketListItemId=" + id.ToString();

            return query;
        }
        private string CreateLogQueryString(string msg, string token, string userName)
        {
            var query = "?msg=" + msg
                + "&encodedUser =" + Base64Encode(userName)
                + "&encodedToken=" + Base64Encode(token);

            return query;
        }
        private string CreateTokenQueryString(string token, string userName)
        {
            var query = "?encodedUser=" + Base64Encode(userName)
                + "&encodedToken=" + Base64Encode(token);

            return query;
        }

        #endregion
    }
}
