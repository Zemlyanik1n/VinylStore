namespace VinylStore.Persistence.Entities;

public class DeliveryAddressEntity
{
    public long Id { get; set; }
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public int PostalCode { get; set; } = 0;
    public string StreetNumber { get; set; } = string.Empty;
    public int FlatNumber { get; set; } = 0;
    public long UserId { get; set; }
    public ICollection<UserEntity> Users { get; set; }
}