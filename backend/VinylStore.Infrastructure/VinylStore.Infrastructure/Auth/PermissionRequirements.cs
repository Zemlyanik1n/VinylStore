using Microsoft.AspNetCore.Authorization;
using VinylStore.Core.Enums;

namespace VinylStore.Infrastructure.Auth;

public class PermissionRequirements(Permissions[] permissions) : IAuthorizationRequirement
{
    public Permissions[] Permissions { get; set; } = permissions;
}