using VinylStore.Application.Abstractions.Services;
using VinylStore.Core.Abstractions.Repositories;
using VinylStore.Core.Enums;

namespace VinylStore.Application.Services;



public class PermissionService(IUsersRepository usersRepository) : IPermissionService
{
    public Task<HashSet<Permissions>> GetPermissionsAsync(Guid userId)
    {
        return usersRepository.GetUserPermissions(userId);
    }
}
