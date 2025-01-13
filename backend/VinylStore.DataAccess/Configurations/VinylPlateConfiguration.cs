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
        
        builder
            .HasOne(x => x.Album)
            .WithMany(x => x.VinylPlates)
            .HasForeignKey(x => x.AlbumId);

        builder
            .HasMany(o => o.Orders)
            .WithMany(o => o.VinylPlates);
    }
}