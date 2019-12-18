using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Shared.dto.api;
using Shared.dto;
using Shared.misc;

namespace API_IntegrationTests
{
    [TestClass]
    public class HappyPathTests
    {
        private string host = "https://localhost:44363";
        private string userName = "fredFlintstone";
        private string password = "wilmaRules87&";
        private string email = "fred@bedrock.com";

        [TestMethod]
        public void HappyPathTest()
        {
            EndPoint_Register();
            var token = EndPoint_Login();
            EndPoint_Get(token);
            EndPoint_Upsert(token);
            EndPoint_Get(token);


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
        private void EndPoint_Get(string token)
        {
            var url = host + "/api/tgimbaapi/getbucketlistitems";
            var query = CreateGetRequest(token, this.userName, "", "");
            var fullUrl = url + query;
            var result = Get(fullUrl).Result;

            Assert.IsNotNull(result);
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

        // TODO - add requests to test page and all other endpoints to currently expecting a token...they need to take a token
        private void EndPoint_TestPage()
        {
            var url = host + "/api/tgimbaapi/test";
            var result = Get(url).Result;

            Assert.AreEqual("Test Service Response", result);
        }

        #region Http methods

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

        #endregion
    }
}
