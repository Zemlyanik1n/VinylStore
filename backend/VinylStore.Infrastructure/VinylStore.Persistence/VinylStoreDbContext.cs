using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VinylStore.Core.Models;
using VinylStore.Persistence.Configurations;

namespace VinylStore.Persistence;
public class VinylStoreDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public VinylStoreDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public DbSet<Album> Albums { get; set; }
    public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Track> Tracks { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<VinylPlate> VinylPlates { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration
            .GetConnectionString("VinylStoreDbContext"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseTablespace("vinylstore");
        modelBuilder.ApplyConfiguration(new AlbumConfiguration());
        modelBuilder.ApplyConfiguration(new VinylPlateConfiguration());
        modelBuilder.ApplyConfiguration(new GenreConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new TrackConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new DeliveryAddressConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}