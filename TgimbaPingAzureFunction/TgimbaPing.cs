using Microsoft.Azure.WebJobs;
using MS = Microsoft.Extensions.Logging;
using Shared.interfaces;
using TgimbaSupport;
using Shared;

namespace TgimbaPingAzureFunction
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([TimerTrigger("0 30 9 * * *")]TimerInfo myTimer, MS.ILogger log)
        {
            ITgimbaDatabase database = new TgimbaDatabase(Credentials.GetDbConnection());
            ITgimbaHttpClient httpClient = new TgimbaHttpClient();
            ITgimbaPing ping = new TgimbaPing("https://www.tgimba.com/", httpClient, database);
            ping.PingWebSite();
        }
    }
}
