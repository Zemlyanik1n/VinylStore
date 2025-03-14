using VinylStore.Core.Enums;

namespace VinylStore.Application.Abstractions.Services;

public interface IPermissionService
{
    Task<HashSet<Permissions>> GetPermissionsAsync(Guid userId);
}