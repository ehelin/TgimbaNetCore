//using System;
//using Microsoft.Azure.WebJobs;
//using Microsoft.Azure.WebJobs.Host;
//using Microsoft.Extensions.Logging;

//namespace TgimbaAzureFunctionPing
//{
//    public static class TgimbaPing
//    {
//        [FunctionName("TgimbaPing")]
//        public static void Run([TimerTrigger("0 */5 * * * *", RunOnStartup = true)]TimerInfo myTimer, ILogger log)
//        {
//            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
//        }

//        //[FunctionName("TgimbaPing")]
//        //public static void Run
//        //(
//        //    [TimerTrigger("* 0 7 * * 1-5"
//        //    #if DEBUG
//        //                , RunOnStartup=true
//        //    #endif
//        //    )]TimerInfo myTimer, 
//        //     ILogger log
//        //)
//        //{
//        //    log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
//        //}

//    }
//}

using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
//using Shared.interfaces;
//using TgimbaPing;

namespace TgimbaAzureFunctionPing
{
    public static class AzureFunction
    {
        [FunctionName("TgimbaPing")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            //IPing ping = new Ping();
            //ping.PingWebsite();
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            return name != null
                ? (ActionResult)new OkObjectResult($"Hello, {name}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}