namespace VinylStore.Core.Models;

public class Order
{
    public Guid Id { get; set; }
    public DateTime DateOfOrder { get; }
    public DateTime DateOfDelivery { get; }
    public string Status { get; set; } = string.Empty;
    public decimal TotalPrice { get; set; } = 0;
    public Guid UserId { get; set; }
    public virtual User? User { get; set; }
    public virtual ICollection<VinylPlate>? VinylPlates { get; set; } = [];
    public virtual DeliveryAddress? DeliveryAddress { get; set; }
    public Guid DeliveryAddressId { get; set; }

}