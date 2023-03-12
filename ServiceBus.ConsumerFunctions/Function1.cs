using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Net;

namespace ServiceBus.ConsumerFunctions;

public class Function1
{
    private readonly ILogger _logger;

    public Function1(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<Function1>();
    }

    [Function("Function1")]
    public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

        response.WriteString("Welcome to Azure Functions!");

        return response;
    }

    [FunctionName("ServiceBusQueueTriggerCSharp")]
    public static void Run2(
    [ServiceBusTrigger("sbq-rru-queue", Connection = "ServiceBus.ConnectionString")]
        string myQueueItem,
        Int32 deliveryCount,
        DateTime enqueuedTimeUtc,
        string messageId,
        ILogger log)
    {
        log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        log.LogInformation($"EnqueuedTimeUtc={enqueuedTimeUtc}");
        log.LogInformation($"DeliveryCount={deliveryCount}");
        log.LogInformation($"MessageId={messageId}");
    }
}