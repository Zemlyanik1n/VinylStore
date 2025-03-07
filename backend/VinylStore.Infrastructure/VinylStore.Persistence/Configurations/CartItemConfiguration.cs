using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using VinylStore.Core.Models;

namespace VinylStore.Persistence.Configurations;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder
            .HasOne(c => c.Cart)
            .WithMany(c => c.CartItems)
            .HasForeignKey(c => c.CartId);

        builder
            .HasOne(c => c.VinylPlate)
            .WithMany()
            .HasForeignKey(c => c.VinylPlateId);
        
        
    }
}