using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VinylStore.DataAccess.Entities;

namespace VinylStore.DataAccess.Configurations;

public class TrackConfiguration : IEntityTypeConfiguration<TrackEntity>
{
    public void Configure(EntityTypeBuilder<TrackEntity> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder
            .HasOne(a => a.Album)
            .WithMany(a => a.Tracks)
            .HasForeignKey(a => a.AlbumId);
    }
}