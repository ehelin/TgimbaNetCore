using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;

namespace API_IntegrationTests
{
    [TestClass]
    public class HappyPathTests
    {
        private string host = "https://localhost:44363";

        [TestMethod]
        public void HappyPathTest()
        {
            EndPoint_TestPage();
        }

        private void EndPoint_TestPage()
        {
            var url = host + "/api/tgimbaapi/test";
            var result = Get(url).Result;

            Assert.AreEqual("Test Service Response", result);
        }

        private async Task<string> Get(string url)
        {
            var client = new HttpClient();

            var response = await client.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}
