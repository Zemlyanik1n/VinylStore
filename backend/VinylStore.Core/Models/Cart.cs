namespace VinylStore.Core.Models;

public class Cart
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }

    public ICollection<CartItem> CartItems { get; set; } = [];

}