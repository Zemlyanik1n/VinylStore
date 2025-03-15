using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VinylStore.Persistence.Entities;

namespace VinylStore.Persistence.Configurations;

public class DeliveryAddressConfiguration : IEntityTypeConfiguration<DeliveryAddressEntity>
{
    public void Configure(EntityTypeBuilder<DeliveryAddressEntity> builder)
    {
        builder.HasKey(x => x.Id);
    }
}