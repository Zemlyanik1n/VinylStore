using VinylStore.Core.Models;

namespace VinylStore.Core.Abstractions.Repositories;

public interface IUsersRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task CreateAsync(User user);
    Task<User?> GetByIdAsync(Guid id);
}