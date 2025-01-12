namespace VinylStore.DataAccess.Entities;

public class DeliveryAddressEntity
{
    public Guid Id { get; set; }
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public int PostalCode { get; set; } = 0;
    public string StreetNumber { get; set; } = string.Empty;
    public int FlatNumber { get; set; } = 0;
    public Guid UserId { get; set; }
    public UserEntity? User { get; set; }
    public List<OrderEntity>? Orders { get; set; } = [];
}