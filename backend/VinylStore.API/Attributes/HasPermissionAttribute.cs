using Microsoft.AspNetCore.Authorization;
using VinylStore.Core.Enums;

namespace VinylStore.Attributes;

public class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(params Permissions[] permissions)
    {
        Policy = $"Permissions:{string.Join(",", permissions)}";
    }
}