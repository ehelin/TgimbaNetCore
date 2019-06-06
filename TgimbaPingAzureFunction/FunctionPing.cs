using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shared.interfaces;
using TgimbaSupport;
using Shared;

namespace TgimbaPingAzureFunction
{
    public static class FunctionPing
    {
        [FunctionName("FunctionPing")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            Microsoft.Extensions.Logging.ILogger log)
        {
            ITgimbaDatabase database = new TgimbaDatabase(Credentials.GetDbConnection());
            ITgimbaHttpClient httpClient = new TgimbaHttpClient();
            ITgimbaPing ping = new TgimbaPing("https://www.tgimba.com/", httpClient, database);
            ping.PingWebSite();
            
            return null;
        }
    }
}
