using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DEVELOPERSINC.PodcastRSS
{
    public static class RSSFeed
    {
        [FunctionName("RSSFeed")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req, ExecutionContext context, ILogger log)
        {
            string responseMessage = context.FunctionDirectory+"\\itunes.rss";

            return new OkObjectResult(responseMessage);
        }
    }
}
