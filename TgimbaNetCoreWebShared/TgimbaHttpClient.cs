using System.Net.Http;
using System.Threading.Tasks;

namespace TgimbaNetCoreWebShared
{
    public class TgimbaHttpClient : ITgimbaHttpClient
    {
        public string Delete(string url)
        {
            var result = DeleteMethod(url).Result;

            return result;
        }

        public string Get(string url)
        {
            var result = GetMethod(url).Result;

            return result;
        }

        public string Post(string url, StringContent content)
        {
            var result = PostMethod(url, content).Result;

            return result;
        }

        #region Http methods

        private async Task<string> DeleteMethod(string url)
        {
            var client = new HttpClient();

            var response = await client.DeleteAsync(url);

            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        private async Task<string> PostMethod(string url, StringContent content)
        {
            var client = new HttpClient();

            var response = await client.PostAsync(url, content);

            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        private async Task<string> GetMethod(string url)
        {
            var client = new HttpClient();

            var response = await client.GetAsync(url);

            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        #endregion
    }
}
