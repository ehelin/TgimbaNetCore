using Shared.interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace TgimbaSupport
{
    public class TgimbaHttpClient : ITgimbaHttpClient
    {
        public bool Get(string url)
        {
            bool websiteIsUp = PingWebsite(url).Result;

            return websiteIsUp;
        }

        private async Task<bool> PingWebsite(string url)
        {
            bool ok = false;

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            var code = response.StatusCode;

            if (code == System.Net.HttpStatusCode.OK)
            {
                ok = true;
            }

            return ok;
        }
    }
}
