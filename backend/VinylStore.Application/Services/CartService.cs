using CSharpFunctionalExtensions;
using VinylStore.Application.Abstractions.Auth;
using VinylStore.Application.Abstractions.Services;
using VinylStore.Application.DTOs.Responses;
using VinylStore.Core.Abstractions.Repositories;
using VinylStore.Core.Models;
using VinylStore.Persistence.Repositories;

namespace VinylStore.Application.Services;

public class CartService(
    ICartRepository cartRepository,
    ICurrentUserService currentUserService,
    IVinylPlatesRepository vinylPlatesRepository) : ICartService
{
    private readonly ICartRepository _cartRepository = cartRepository;
    private readonly ICurrentUserService _currentUserService = currentUserService;

    public async Task<Result<CartResponse>> GetCart()
    {
        var userId = _currentUserService.UserId;
        if (userId is null)
            return Result.Failure<CartResponse>("User is not authenticated");

        var cart = await _cartRepository.GetByUserId(userId.Value);

        if (cart is null)
            return Result.Failure<CartResponse>("User is not authenticated");

        var cartItems = cart.CartItems.Select(i => new CartItemResponse
        {
            Quantity = i.Count,
            CoverImageUrl = i.VinylPlate.CoverImageUrl,
            VinylPlateId = i.VinylPlateId,
            Manufacturer = i.VinylPlate.Manufacturer,
            PrintYear = i.VinylPlate.PrintYear,
            ArtistName = i.VinylPlate.Album.ArtistName,
            AlbumName = i.VinylPlate.Album.AlbumName,
            ReleaseYear = i.VinylPlate.Album.ReleaseYear,
            Price = i.VinylPlate.Price,
        });

        var cartResponse = new CartResponse
        {
            CartItems = cartItems.ToArray(),
        };

        return Result.Success(cartResponse);
    }

    public async Task<Result> AddItemToCart(long vinylPlateId)
    {
        var userId = _currentUserService.UserId;

        if (userId is null)
            return Result.Failure("User is not authenticated");

        var cart = await _cartRepository.GetByUserId(userId.Value);
        
        if (cart is null)
            return Result.Failure("User is not authenticated");
        
        var vinylPlate = await vinylPlatesRepository.GetById(vinylPlateId);

        if (vinylPlate is null)
            return Result.Failure("Vinyl plate is not found");

        var cartItem = new CartItem(cart.Id, vinylPlateId, 1);

        await _cartRepository.AddItemToCart(cartItem);

        return Result.Success();
    }

    public async Task<Result> RemoveItemFromCart(long vinylPlateId)
    {
        var userId = _currentUserService.UserId;

        if (userId is null)
            return Result.Failure("User is not authenticated");

        var cart = await _cartRepository.GetByUserId(userId.Value);

        if (cart is null)
            return Result.Failure("User is not authenticated");

        if (cart.CartItems.All(i => i.VinylPlateId != vinylPlateId))
            return Result.Failure("Vinyl plate is not found");

        var itemId = cart.CartItems.First(i => i.VinylPlateId == vinylPlateId).Id;

        await _cartRepository.RemoveItemFromCart(itemId);

        return Result.Success();
    }

    public async Task<Result> ChangeQuantity(long vinylPlateId, int quantity)
    {
        var userId = _currentUserService.UserId;

        if (userId is null)
            return Result.Failure("User is not authenticated");

        var cart = await _cartRepository.GetByUserId(userId.Value);

        if (cart is null)
            return Result.Failure("User is not authenticated");

        var item = cart.CartItems.Single(i => i.VinylPlateId == vinylPlateId);
        item.ChangeQuantity(quantity);
        await _cartRepository.ChangeQuantity(item);
        return Result.Success();
    }
}