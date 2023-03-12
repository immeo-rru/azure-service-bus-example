using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;

namespace ServiceBus.ConsumerFunctions
{
    public class Function1
    {
        [FunctionName("Function1")]
        public void Run([ServiceBusTrigger("sbq-rru-queue", Connection = "ServiceBus:ConnectionString")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            System.Diagnostics.Trace.WriteLine($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}