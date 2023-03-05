namespace ServiceBus.Contracts
{
    public record OrderCreated(string? WebOrderId)
    {
        public DateTime CreatedDate { get; } = DateTime.UtcNow;
    }
}