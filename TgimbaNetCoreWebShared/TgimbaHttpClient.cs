using System.Net.Http;
using System.Threading.Tasks;

namespace TgimbaNetCoreWebShared
{
    // TODO - is this client still needed?
    public class TgimbaHttpClient : ITgimbaHttpClient
    {
        public string Delete(string url, string encodedUserName = "", string encodedToken = "")
        {
            var result = DeleteMethod(url, encodedUserName, encodedToken).Result;

            return result;
        }

        public string Get(string url, string encodedUserName = "", string encodedToken = "")
        {
            var result = GetMethod(url, encodedUserName, encodedToken).Result;

            return result;
        }

        public string Post(string url, StringContent content)
        {
            var result = PostMethod(url, content).Result;

            return result;
        }

        #region Http methods

        private async Task<string> DeleteMethod(string url, string encodedUserName = "", string encodedToken = "")
        {
            var client = new HttpClient();
            SetHeaders(client, encodedUserName, encodedToken);

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

        private async Task<string> GetMethod(string url, string encodedUserName = "", string encodedToken = "")
        {
            var client = new HttpClient();
            SetHeaders(client, encodedUserName, encodedToken);

            var response = await client.GetAsync(url);

            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        private void SetHeaders(HttpClient client, string encodedUserName = "", string encodedToken = "")
        {
            if (!string.IsNullOrEmpty(encodedUserName))
            {
                client.DefaultRequestHeaders.Add("EncodedUserName", encodedUserName);
            }
            if (!string.IsNullOrEmpty(encodedToken))
            {
                client.DefaultRequestHeaders.Add("EncodedToken", encodedToken);
            }
        }

        #endregion
    }
}
