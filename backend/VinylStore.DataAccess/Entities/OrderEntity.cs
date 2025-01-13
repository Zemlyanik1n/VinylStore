namespace VinylStore.DataAccess.Entities;

public class OrderEntity
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; } = DateTime.Today;
    public string Status { get; set; } = string.Empty;
    public decimal TotalPrice { get; set; } = 0;
    public Guid UserId { get; set; }
    public UserEntity? User { get; set; }
    public List<VinylPlateEntity>? VinylPlates { get; set; } = [];
    public DeliveryAddressEntity? DeliveryAddress { get; set; }
    public Guid DeliveryAddressId { get; set; }

}