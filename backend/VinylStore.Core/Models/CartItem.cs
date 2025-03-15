using CSharpFunctionalExtensions;

namespace VinylStore.Core.Models;

public class CartItem
{
    public long Id { get; set; }

    public long VinylPlateId { get; private set; }
    public VinylPlate VinylPlate { get; private set; }

    public Cart Cart { get; } = null!;
    public long CartId { get; set; }

    public int Count { get; private set; }

    private CartItem()
    {
    }
    
    public CartItem(long cartId, long vinylPlateId, int count)
    {
        CartId = cartId;
        VinylPlateId = vinylPlateId;
        Count = count;
    }

    public Result ChangeQuantity(int newCount)
    {
        if(newCount <= 0)
            return Result.Failure("quantity must be positive");
        Count = newCount;
        return Result.Success();
    }
}
