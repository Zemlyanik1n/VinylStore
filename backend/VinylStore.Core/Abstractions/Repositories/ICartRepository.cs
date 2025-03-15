using VinylStore.Core.Models;

namespace VinylStore.Persistence.Repositories;

public interface ICartRepository
{
    Task<Cart?> GetByUserId(Guid userId);
    Task<Cart?> GetById(long id);
    Task AddItemToCart(CartItem cartItem);
    Task RemoveItemFromCart(long cartItemId);
    Task ChangeQuantity(CartItem cartItem);
}