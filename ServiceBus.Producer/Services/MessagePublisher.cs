using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Options;
using ServiceBus.Producer.Models;
using System.Text.Json;

namespace ServiceBus.Producer.Services
{
    public interface IMessagePublisher
    {
        Task Publish(string raw);

        Task Publish<T>(T obj);
    }

    public class MessagePublisher : IMessagePublisher
    {
        private readonly ServiceBusClient _serviceBusClient;
        private readonly ServiceBusSettings _serviceBusSettings;

        public MessagePublisher(ServiceBusClient client,
            IOptions<ServiceBusSettings> serviceBusSettings)
        {
            _serviceBusClient = client;
            _serviceBusSettings = serviceBusSettings.Value;
        }

        public async Task Publish(string raw)
        {
            var message = new ServiceBusMessage(raw);
            message.ApplicationProperties["messageType"] = "Raw";
            var sender = _serviceBusClient.CreateSender(_serviceBusSettings.TopicName);
            await sender.SendMessageAsync(message);
            return;
        }

        public async Task Publish<T>(T obj)
        {
            var objAsText = JsonSerializer.Serialize(obj);
            var message = new ServiceBusMessage(objAsText);
            message.ApplicationProperties["messageType"] = typeof(T).Name;
            var sender = _serviceBusClient.CreateSender(_serviceBusSettings.TopicName);
            await sender.SendMessageAsync(message);
            return;
        }
    }
}