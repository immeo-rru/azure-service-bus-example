namespace ServiceBus.Producer.Models
{
    public class ServiceBusSettings
    {
        public const string Section = "ServiceBus";
        public string ConnectionString { get; set; } = String.Empty;
        public ServiceBusTopic Topic { get; set; }
        public ServiceBusQueue Queue { get; set; }
    }

    public class ServiceBusTopic
    {
        public const string Section = "Topic";

        public string TopicName { get; set; } = String.Empty;
    }

    public class ServiceBusQueue
    {
        public const string Section = "Queue";

        public string QueueName { get; set; } = String.Empty;
    }
}