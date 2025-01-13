using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using VinylStore.DataAccess.Entities;

namespace VinylStore.DataAccess.Configurations;

public class DeliveryAddressConfiguration : IEntityTypeConfiguration<DeliveryAddressEntity>
{
    public void Configure(EntityTypeBuilder<DeliveryAddressEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(u => u.Users)
            .WithMany(a => a.DeliveryAddresses);
        
        builder
            .HasMany(d => d.Orders)
            .WithOne(o => o.DeliveryAddress)
            .HasForeignKey(o => o.DeliveryAddressId);
    }
}