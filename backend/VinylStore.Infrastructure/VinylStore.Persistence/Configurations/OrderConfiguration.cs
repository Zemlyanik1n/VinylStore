using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VinylStore.Persistence.Entities;

namespace VinylStore.Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.HasKey(o => o.Id);

        builder
            .HasOne(d => d.DeliveryAddress)
            .WithMany()
            .HasForeignKey(d => d.DeliveryAddressId);
    }
}