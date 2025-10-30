namespace WebApi_With_SQL_Server.Domain.Events
{
    public class ProductCreatedEvent
    {
        public int ProductId { get; }
        public DateTime CreatedAt { get; }

        public ProductCreatedEvent(int productId)
        {
            ProductId = productId;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
