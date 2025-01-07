using Microsoft.EntityFrameworkCore;
using VinylStore.DataAccess.Entities;

namespace VinylStore.DataAccess;
public class VinylStoreDbContext : DbContext
{
    public VinylStoreDbContext(DbContextOptions<VinylStoreDbContext> options) : base(options)
    {
    }
    public DbSet<VinylPlateEntity> VinylPlates { get; set; }
}