using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VinylStore.DataAccess.Entities;

namespace VinylStore.DataAccess.Configurations;

public class VinylPlateConfiguration : IEntityTypeConfiguration<VinylPlateEntity>
{
    public void Configure(EntityTypeBuilder<VinylPlateEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.PrintYear).HasMaxLength(4).IsRequired();
        builder.Property(x => x.Description).IsRequired();
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.AlbumId).IsRequired();
        builder.Property(x => x.Condition).IsRequired();
        builder.Property(x => x.Format).IsRequired();
        builder.Property(x => x.CoverUrl).IsRequired();
        builder.Property(x => x.Manufacturer).IsRequired();
    }
}