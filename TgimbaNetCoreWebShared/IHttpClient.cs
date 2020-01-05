using System.Net.Http;

namespace TgimbaNetCoreWebShared
{
    public interface ITgimbaHttpClient
    {
        string Delete(string url);
        string Post(string url, StringContent content);
        string Get(string url);
    }
}
