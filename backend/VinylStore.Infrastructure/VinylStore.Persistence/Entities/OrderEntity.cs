namespace VinylStore.Persistence.Entities;

public class OrderEntity
{
    public long Id { get; set; }
    public DateTime DateOfOrder { get; }
    public DateTime DateOfDelivery { get; }
    public string Status { get; set; } = string.Empty;
    public decimal TotalPrice { get; set; } = 0;
    public Guid UserId { get; set; }
    public UserEntity? User { get; set; }

    public ICollection<OrderItemEntity> OrderItems { get; set; } = [];
    public DeliveryAddressEntity? DeliveryAddress { get; set; }
    public long DeliveryAddressId { get; set; }
}