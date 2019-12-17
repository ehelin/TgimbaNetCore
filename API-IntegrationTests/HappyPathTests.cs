using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Shared.dto.api;

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
            EndPoint_TestPage();
            EndPoint_Register();
            EndPoint_Login();
        }

        private void EndPoint_TestPage()
        {
            var url = host + "/api/tgimbaapi/test";
            var result = Get(url).Result;

            Assert.AreEqual("Test Service Response", result);
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
        private void EndPoint_Login()
        {
            var request =  new LoginRequest()
            {
                EncodedUserName = Base64Encode(userName),
                EncodedPassword = Base64Encode(password)
            };

            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var url = host + "/api/tgimbaapi/processuser";
            var result = Post(url, content).Result;

            Assert.AreEqual(true, result.Length > 1);
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

        #endregion
    }
}
