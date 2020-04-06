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
    public static class AudioFile
    {
        [FunctionName("AudioFile")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req, ExecutionContext context, ILogger log)
        {
            string path = context.FunctionDirectory+"/itunes.rss";
            string responseMessage = "";
            responseMessage = await File.ReadAllTextAsync(path);

            return new OkObjectResult(responseMessage);
        }
    }
}
