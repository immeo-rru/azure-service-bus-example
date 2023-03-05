namespace ServiceBus.Producer.Models
{
    public class ServiceBusSettings
    {
        public const string Section = "ServiceBus";

        public string ConnectionString { get; set; } = String.Empty;
        public string TopicName { get; set; } = String.Empty;

    }
}
