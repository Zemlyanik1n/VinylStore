using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VinylStore.Persistence.Entities;

namespace VinylStore.Persistence.Configurations;

public class AlbumEntityGenreEntityConfiguration : IEntityTypeConfiguration<AlbumEntityGenreEntity>
{
    public void Configure(EntityTypeBuilder<AlbumEntityGenreEntity> builder)
    {
        builder.HasKey(x => new {x.AlbumId, x.GenreId});
    }
}