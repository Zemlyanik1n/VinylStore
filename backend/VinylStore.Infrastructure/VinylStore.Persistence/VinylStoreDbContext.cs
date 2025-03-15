using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using VinylStore.Core.Models;
using VinylStore.Persistence.Configurations;
using VinylStore.Persistence.Entities;

namespace VinylStore.Persistence;

public class VinylStoreDbContext(IConfiguration configuration, IOptions<AuthorizationOptions> authOptions) : DbContext
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IOptions<AuthorizationOptions> _authOptions = authOptions;

    public DbSet<AlbumEntity> Albums { get; set; }
    public DbSet<DeliveryAddressEntity> DeliveryAddresses { get; set; }
    public DbSet<GenreEntity> Genres { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<TrackEntity> Tracks { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<VinylPlateEntity> VinylPlates { get; set; }
    public DbSet<CartItemEntity> CartItems { get; set; }
    public DbSet<CartEntity> Carts { get; set; }

    public DbSet<OrderItemEntity> OrderItems { get; set; }

    public DbSet<RoleEntity> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration
            .GetConnectionString("VinylStoreDbContext"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseTablespace("vinylstore");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(VinylStoreDbContext).Assembly);
        modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(_authOptions.Value));
        base.OnModelCreating(modelBuilder);
    }
}