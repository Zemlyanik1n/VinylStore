using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VinylStore.Core.Abstractions.Repositories;
using VinylStore.Core.Enums;
using VinylStore.Core.Models;
using VinylStore.Persistence.Entities;

namespace VinylStore.Persistence.Repositories;

public class UsersRepository(VinylStoreDbContext context, IMapper mapper) : IUsersRepository
{
    private readonly VinylStoreDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<User?> GetByEmailAsync(string email)
    {
        var user = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email);
        return _mapper.Map<User>(user);
    }

    public async Task CreateAsync(User user)
    {
        var userEntity = _mapper.Map<UserEntity>(user);
        await _context.Users
            .AddAsync(userEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        var userEntity = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id);
        return _mapper.Map<User>(userEntity);
    }

    public async Task<HashSet<Permissions>> GetUserPermissions(Guid userId)
    {
        var roles = await _context.Users
            .AsNoTracking()
            .Include(u => u.Roles)
            .ThenInclude(r => r.Permissions)
            .Where(u => u.Id == userId)
            .Select(u => u.Roles)
            .ToArrayAsync();
            
        return roles
            .SelectMany(r => r)
            .SelectMany(r => r.Permissions)
            .Select(p => (Permissions)p.Id)
            .ToHashSet();
    }
}