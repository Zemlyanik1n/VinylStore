using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VinylStore.Persistence.Entities;

namespace VinylStore.Persistence.Configurations;

public class VinylPlateConfiguration : IEntityTypeConfiguration<VinylPlateEntity>
{
    public void Configure(EntityTypeBuilder<VinylPlateEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired();

        // builder
        //     .HasMany(o => o.Orders)
        //     .WithMany(o => o.VinylPlates);
    }
}