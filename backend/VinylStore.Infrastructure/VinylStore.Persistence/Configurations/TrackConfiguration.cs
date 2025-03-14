using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VinylStore.Persistence.Entities;

namespace VinylStore.Persistence.Configurations;

public class TrackConfiguration : IEntityTypeConfiguration<TrackEntity>
{
    public void Configure(EntityTypeBuilder<TrackEntity> builder)
    {
        builder.HasKey(x => x.Id);
    }
}