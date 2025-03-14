using VinylStore.Core.Enums;
using VinylStore.Infrastructure.Auth;

namespace VinylStore.Extensions;

public static class AddPermission
{
    public static IEndpointConventionBuilder RequirePermissions<TBuilder>(this TBuilder builder,
        params Permissions[] permissions)
        where TBuilder : IEndpointConventionBuilder
    {
        return builder.RequireAuthorization(policy =>
        {
            policy.AddRequirements(new PermissionRequirements(permissions));
        });
    }
}