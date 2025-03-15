using VinylStore.Core.Enums;
using VinylStore.Core.Models;

namespace VinylStore.Core.Abstractions.Repositories;

public interface IUsersRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task AddAsync(User user);
    Task<User?> GetByIdAsync(Guid id);
    Task<HashSet<Permissions>> GetUserPermissions(Guid userId);
}