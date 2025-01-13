using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VinylStore.DataAccess.Entities;

namespace VinylStore.DataAccess.Configurations;

public class GenreConfiguration : IEntityTypeConfiguration<GenreEntity>
{
    public void Configure(EntityTypeBuilder<GenreEntity> builder)
    {
        builder.HasKey(g => g.Id);

        builder
            .HasMany(g => g.Albums)
            .WithMany(a => a.Genres);
    }
}