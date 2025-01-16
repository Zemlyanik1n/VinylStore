namespace VinylStore.Core.Models;

public class User
{
    private User()
    {
        
    }
    public Guid Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public virtual ICollection<DeliveryAddress>? DeliveryAddresses { get; set; } = [];
    public virtual ICollection<Order>? Orders { get; set; } = [];
}