using CSharpFunctionalExtensions;
using System.Collections.ObjectModel;

namespace VinylStore.Core.Models;

public class Cart
{
    public long Id { get; set; }
    public Guid UserId { get; set; }
    
    public ICollection<CartItem> CartItems { get; set; }
    
    public User User { get; } = null!;
    private Cart() { }

    private Cart(Guid userId)
    {
        UserId = userId;
    }

    private Cart(long id, Guid userId)
    {
        Id = id;
        UserId = userId;
    }

    public static Result<Cart> Create(Guid userId)
    {
        return userId == Guid.Empty 
            ? Result.Failure<Cart>("User ID is required") 
            : Result.Success(new Cart(userId));
    }
    public static Result<Cart> Create(long id, Guid userId)
    {
        return userId == Guid.Empty 
            ? Result.Failure<Cart>("User ID is required") 
            : Result.Success(new Cart(id,userId));
    }
    
    

}