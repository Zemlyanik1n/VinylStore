using Microsoft.EntityFrameworkCore;
using VinylStore.DataAccess.Configurations;
using VinylStore.DataAccess.Entities;

namespace VinylStore.DataAccess;
public class VinylStoreDbContext(DbContextOptions<VinylStoreDbContext> options) : DbContext(options)
{
    public DbSet<AlbumEntity> Albums { get; set; }
    public DbSet<DeliveryAddressEntity> DeliveryAddresses { get; set; }
    public DbSet<GenreEntity> Genres { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<TrackEntity> Tracks { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<VinylPlateEntity> VinylPlates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AlbumConfiguration());
        modelBuilder.ApplyConfiguration(new VinylPlateConfiguration());
        
        
        base.OnModelCreating(modelBuilder);
    }
}