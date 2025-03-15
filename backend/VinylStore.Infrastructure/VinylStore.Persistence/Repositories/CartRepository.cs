using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VinylStore.Core.Models;
using VinylStore.Persistence.Entities;

namespace VinylStore.Persistence.Repositories;

public class CartRepository(VinylStoreDbContext context, IMapper mapper) : ICartRepository
{
    private readonly VinylStoreDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<Cart?> GetByUserId(Guid userId)
    {
        var result = await _context.Carts
            .AsNoTracking()
            .Where(c => c.UserId == userId)
            .Include(c => c.CartItems)
            .ThenInclude(i => i.VinylPlate)
            .ThenInclude(i => i.Album)
            .FirstOrDefaultAsync();
        return _mapper.Map<Cart>(result);   
    }

    public async Task<Cart?> GetById(long id)
    {
        var result = await _context.Carts
            .AsNoTracking()
            .Include(c => c.CartItems)
            .ThenInclude(i => i.VinylPlate)
            .ThenInclude(i => i.Album)
            .FirstOrDefaultAsync(c => c.Id == id);
        return _mapper.Map<Cart>(result);
    }

    public async Task AddItemToCart(CartItem cartItem)
    {
        var cartItemEntity = _mapper.Map<CartItemEntity>(cartItem);
        await _context.CartItems.AddAsync(cartItemEntity);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveItemFromCart(long cartItemId)
    {
        await _context.CartItems
            .Where(c => c.Id == cartItemId)
            .ExecuteDeleteAsync();
    }

    public async Task ChangeQuantity(CartItem cartItem)
    {
        var cartItemEntity = _mapper.Map<CartItemEntity>(cartItem);
        
        var res = await _context.CartItems.FirstOrDefaultAsync(c => c.Id == cartItemEntity.Id);
        res.Count = cartItemEntity.Count;
        
        await _context.SaveChangesAsync();  
    }
}