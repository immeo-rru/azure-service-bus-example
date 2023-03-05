namespace ServiceBus.Consumer
{
    public class ServiceBusSettings
    {
        public const string Section = "ServiceBus";

        public string ConnectionString { get; set; } = String.Empty;
        public string TopicName { get; set; } = String.Empty;
        public string SubscriptionName { get; set; } = String.Empty;

    }
}
