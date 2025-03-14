using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VinylStore.Core.Enums;
using VinylStore.Persistence.Entities;

namespace VinylStore.Persistence.Configurations;

public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermissionEntity>
{
    private readonly AuthorizationOptions _authorizationOptions;

    public RolePermissionConfiguration(AuthorizationOptions authorizationOptions)
    {
        _authorizationOptions = authorizationOptions;
    }

    public void Configure(EntityTypeBuilder<RolePermissionEntity> builder)
    {
        builder.HasKey(x => new { x.RoleId, x.PermissionId });
        builder.HasData(ParseRolePermissions());
    }

    private RolePermissionEntity[] ParseRolePermissions()
    {
        return _authorizationOptions.RolePermissions
            .SelectMany(rp => rp.Permissions
                .Select(p => new RolePermissionEntity
                {
                    RoleId = (int)Enum.Parse<Roles>(rp.Role),
                    PermissionId = (int)Enum.Parse<Permissions>(p)
                }))
            .ToArray();
    }
}