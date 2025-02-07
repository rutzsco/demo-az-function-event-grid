// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}
using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.IO;

namespace Demo.Function.EventGrid
{
    public static class BlobEventProcessor
    {
        [FunctionName("BlobEventProcessor")]
        public static async Task Run([EventGridTrigger]EventGridEvent eventGridEvent, [Blob("{data.url}", FileAccess.Read)] Stream input, ILogger log)
        {
            log.LogInformation(eventGridEvent.Data.ToString());
        }
    }
}
