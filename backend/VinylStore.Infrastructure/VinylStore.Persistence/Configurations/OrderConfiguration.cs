using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VinylStore.Core.Models;

namespace VinylStore.Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder
            .HasMany(v => v.VinylPlates)
            .WithMany(o => o.Orders);

        builder
            .HasOne(u => u.User)
            .WithMany(o => o.Orders)
            .HasForeignKey(u => u.UserId);

        builder
            .HasOne(d => d.DeliveryAddress)
            .WithMany(o => o.Orders)
            .HasForeignKey(d => d.DeliveryAddressId);

    }
}