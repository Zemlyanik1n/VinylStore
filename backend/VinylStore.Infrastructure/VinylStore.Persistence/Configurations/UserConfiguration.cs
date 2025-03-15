using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VinylStore.Persistence.Entities;

namespace VinylStore.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Password)
            .IsRequired();

        builder
            .HasMany(o => o.Orders)
            .WithOne(o => o.User)
            .HasForeignKey(o => o.UserId);

        builder
            .HasMany(a => a.DeliveryAddresses)
            .WithMany(d => d.Users);

        builder
            .HasOne(u => u.Cart)
            .WithOne(c => c.User)
            .HasForeignKey<CartEntity>(c => c.UserId);

        builder.HasMany(u => u.Roles)
            .WithMany(r => r.Users)
            .UsingEntity<UserRoleEntity>(
                l => l.HasOne<RoleEntity>().WithMany().HasForeignKey(r => r.RoleId),
                r => r.HasOne<UserEntity>().WithMany().HasForeignKey(u => u.UserId));
    }
}