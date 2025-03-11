using Microsoft.EntityFrameworkCore;
using VinylStore.Core.Models;

namespace VinylStore.Persistence.Repositories;

public class CartRepository(VinylStoreDbContext context)
{
    private readonly VinylStoreDbContext _context = context;

    public async Task<Cart?> GetByUserId(long userId)
    {
        return await context.Carts
            .AsNoTracking()
            .Include(c => c.CartItems)
            .Where(c => c.UserId == userId)
            .FirstOrDefaultAsync();
    }
    public async Task<Cart?> GetById(long id)
    {
        return await _context.Carts
            .AsNoTracking()
            .Include(c => c.CartItems)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
    
}