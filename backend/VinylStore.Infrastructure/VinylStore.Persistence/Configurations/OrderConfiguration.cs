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
            .WithMany();

        // добавить еще один слой с entities для работы с бд.
        builder
            .HasOne(d => d.DeliveryAddress)
            .WithMany()
            .HasForeignKey(d => d.DeliveryAddressId);
    }
}