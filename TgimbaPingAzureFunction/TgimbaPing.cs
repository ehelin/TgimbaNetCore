using Microsoft.Azure.WebJobs;
using Shared.interfaces;
using Shared.misc;
using TgimbaSupport;
using MS = Microsoft.Extensions.Logging;

namespace TgimbaPingAzureFunction
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([TimerTrigger("0 30 9 * * *")]TimerInfo myTimer, MS.ILogger log)
        {
            // NOTE: If using environmental variables, this has to be set up on the azure function cloud provider
            ITgimbaDatabase database = new TgimbaDatabase(EnvironmentalConfig.GetDbSetting());
            ITgimbaHttpClient httpClient = new TgimbaHttpClient();
            ITgimbaPing ping = new TgimbaPing("https://www.tgimba.com/", httpClient, database);
            ping.PingWebSite();
        }
    }
}
