using Microsoft.EntityFrameworkCore;
using VinylStore.Core.Abstractions.Repositories;
using VinylStore.Core.Models;

namespace VinylStore.Persistence.Repositories;

public class UsersRepository(VinylStoreDbContext context) : IUsersRepository
{
    private readonly VinylStoreDbContext _context = context;
    
    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task CreateAsync(User user)
    {
        await _context.Users
            .AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id);
    }
}