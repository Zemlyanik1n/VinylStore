using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VinylStore.DataAccess.Entities;

namespace VinylStore.DataAccess.Configurations;

public class AlbumConfiguration : IEntityTypeConfiguration<AlbumEntity>
{
    public void Configure(EntityTypeBuilder<AlbumEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.Description).IsRequired();
        builder.Property(x => x.Duration).IsRequired();
        builder.Property(x => x.ArtistName).IsRequired();

        builder
            .HasMany(g => g.Genres)
            .WithMany(a => a.Albums);
        builder
            .HasMany(v => v.VinylPlates)
            .WithOne(v => v.Album)
            .HasForeignKey(v => v.AlbumId);
        builder
            .HasMany(v => v.Tracks)
            .WithOne(a => a.Album)
            .HasForeignKey(a => a.AlbumId);
    }
}