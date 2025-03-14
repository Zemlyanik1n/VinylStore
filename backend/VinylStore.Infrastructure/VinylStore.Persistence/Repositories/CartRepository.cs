using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VinylStore.Core.Models;

namespace VinylStore.Persistence.Repositories;

public class CartRepository(VinylStoreDbContext context, IMapper mapper)
{
    private readonly VinylStoreDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<Cart?> GetByUserId(Guid userId)
    {
        var result = await context.Carts
            .AsNoTracking()
            .Include(c => c.CartItems)
            .Where(c => c.UserId == userId)
            .FirstOrDefaultAsync();
        return _mapper.Map<Cart>(result);
    }
    public async Task<Cart?> GetById(long id)
    {
        var result= await _context.Carts
            .AsNoTracking()
            .Include(c => c.CartItems)
            .FirstOrDefaultAsync(c => c.Id == id);
        return _mapper.Map<Cart>(result);
    }
    
}