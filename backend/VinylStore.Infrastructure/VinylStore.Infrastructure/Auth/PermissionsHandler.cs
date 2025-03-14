using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using VinylStore.Application.Abstractions.Services;

namespace VinylStore.Infrastructure.Auth;

public class PermissionAuthorizationHandler(IServiceScopeFactory scopeFactory)
    : AuthorizationHandler<PermissionRequirements>
{
    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissionRequirements requirement)
    {
        var userId = context.User.Claims.FirstOrDefault(
            x => x.Type == CustomClaims.UserId);

        if (userId is null || !Guid.TryParse(userId.Value, out var id))
            return;

        using var scope = scopeFactory.CreateScope();

        var permissionService = scope.ServiceProvider
            .GetRequiredService<IPermissionService>();

        var permissions = await permissionService.GetPermissionsAsync(id);

        if (permissions.Intersect(requirement.Permissions).Any())
        {
            context.Succeed(requirement);
        }
    }
}