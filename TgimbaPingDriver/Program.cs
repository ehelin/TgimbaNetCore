using Shared.interfaces;
using TgimbaSupport;
using Shared.misc;

namespace TgimbaSupportDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            ITgimbaDatabase database = new TgimbaDatabase(EnvironmentalConfig.GetDbSetting());
            ITgimbaHttpClient httpClient = new TgimbaHttpClient();
            ITgimbaPing ping = new TgimbaPing("https://www.tgimba.com/", httpClient, database);
            ping.PingWebSite();           
        }
    }
}
