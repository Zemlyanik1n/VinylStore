using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VinylStore.Core.Models;


namespace VinylStore.Persistence.Configurations;

public class AlbumConfiguration : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasMany(g => g.Genres)
            .WithMany();
        
        builder
            .HasMany(v => v.VinylPlates)
            .WithOne(v => v.Album)
            .HasForeignKey(v => v.AlbumId);
        
        builder
            .HasMany(t => t.Tracks)
            .WithOne(t => t.Album)
            .HasForeignKey(t => t.AlbumId);
        
        // builder
        //     .HasMany(v => v.VinylPlates)
        //     .WithOne(v => v.Album)
        //     .HasForeignKey(v => v.AlbumId);
        // builder
        //     .HasMany(v => v.Tracks)
        //     .WithOne(a => a.Album)
        //     .HasForeignKey(a => a.AlbumId);
    }
}