using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VinylStore.Core.Models;

namespace VinylStore.Persistence.Configurations;

public class VinylPlateConfiguration : IEntityTypeConfiguration<VinylPlate>
{
    public void Configure(EntityTypeBuilder<VinylPlate> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired();

        // builder
        //     .HasMany(o => o.Orders)
        //     .WithMany(o => o.VinylPlates);
    }
}