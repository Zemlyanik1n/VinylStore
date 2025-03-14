namespace VinylStore.Persistence.Entities;

public class CartEntity
{
    public long Id { get; set; }
    public Guid UserId { get; set; }
    public UserEntity User { get; set; }

    public ICollection<CartItemEntity> CartItems { get; set; } = [];
}