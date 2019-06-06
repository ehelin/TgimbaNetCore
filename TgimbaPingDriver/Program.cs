using Shared.interfaces;
using TgimbaSupport;
using Shared;

namespace TgimbaPingDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            ITgimbaDatabase database = new TgimbaDatabase(Credentials.GetDbConnection());
            ITgimbaHttpClient httpClient = new TgimbaHttpClient();
            ITgimbaPing ping = new TgimbaPing("https://www.tgimba.com/", httpClient, database);
            ping.PingWebSite();           
        }
    }
}
