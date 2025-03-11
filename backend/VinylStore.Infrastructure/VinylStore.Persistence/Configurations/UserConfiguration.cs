using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VinylStore.Core.Models;

namespace VinylStore.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        
        builder.HasKey(u => u.Id);
        
        builder
            .HasMany(o => o.Orders)
            .WithOne(o => o.User)
            .HasForeignKey(o => o.UserId);

        builder
            .HasMany(a => a.DeliveryAddresses)
            .WithMany();

        builder
            .HasOne(u => u.Cart)
            .WithOne(c => c.User)
            .HasForeignKey<Cart>(c => c.UserId);
    }
}