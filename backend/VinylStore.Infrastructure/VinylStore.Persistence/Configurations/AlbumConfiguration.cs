using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VinylStore.Persistence.Entities;


namespace VinylStore.Persistence.Configurations;

public class AlbumConfiguration : IEntityTypeConfiguration<AlbumEntity>
{
    public void Configure(EntityTypeBuilder<AlbumEntity> builder)
    {
        builder.HasKey(x => x.Id);
            
        builder.Property(x => x.Id).IsRequired();
        
        builder
            .HasMany(g => g.Genres)
            .WithMany(g=> g.Albums);
        
        builder
            .HasMany(v => v.VinylPlates)
            .WithOne(v => v.Album)
            .HasForeignKey(v => v.AlbumId);
        
        builder
            .HasMany(t => t.Tracks)
            .WithOne(t => t.Album)
            .HasForeignKey(t => t.AlbumId);
    }
}