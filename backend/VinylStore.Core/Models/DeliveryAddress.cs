using VinylStore.Core.Models;

namespace VinylStore.Core.Models;

public class DeliveryAddress
{
    public Guid Id { get; set; }
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public int PostalCode { get; set; } = 0;
    public string StreetNumber { get; set; } = string.Empty;
    public int FlatNumber { get; set; } = 0;
    public Guid UserId { get; set; }
    public virtual ICollection<User>? Users { get; set; } = [];
    public virtual ICollection<Order>? Orders { get; set; } = [];
}