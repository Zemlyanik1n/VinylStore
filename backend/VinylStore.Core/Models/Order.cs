namespace VinylStore.Core.Models;

public class Order
{
    private Order()
    {
    }

    public long Id { get; set; }
    public DateTime DateOfOrder { get; }
    public DateTime DateOfDelivery { get; }
    public string Status { get; set; } = string.Empty;
    public decimal TotalPrice { get; set; } = 0;
    public Guid UserId { get; set; }
    public User? User { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; } = [];
    public DeliveryAddress? DeliveryAddress { get; set; }
    public long DeliveryAddressId { get; set; }
}