using VinylStore.Core.Enums;
using VinylStore.Core.Models;

namespace VinylStore.Persistence.Entities;

public class UserEntity
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Password { get; set; }

    public long? CartId { get; set; }
    public CartEntity? Cart { get; set; }
    public ICollection<DeliveryAddressEntity>? DeliveryAddresses { get; set; }
    public ICollection<OrderEntity>? Orders { get; set; }
    public ICollection<RoleEntity> Roles { get; set; }
}