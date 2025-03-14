using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VinylStore.Core.Enums;
using VinylStore.Persistence.Entities;

namespace VinylStore.Persistence.Configurations;

public class PermissionConfiguration : IEntityTypeConfiguration<PermissionEntity>
{
    public void Configure(EntityTypeBuilder<PermissionEntity> builder)
    {
        builder.HasKey(c => c.Id);

        var permissions = Enum.GetValues<Permissions>()
            .Select(p =>
                new PermissionEntity
                {
                    Id = (int)p,
                    Name = p.ToString(),
                });

        builder.HasData(permissions);
    }
}