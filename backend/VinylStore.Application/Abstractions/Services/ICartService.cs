using CSharpFunctionalExtensions;
using VinylStore.Application.DTOs.Responses;

namespace VinylStore.Application.Abstractions.Services;

public interface ICartService
{
    Task<Result<CartResponse>> GetCart();
    Task<Result> AddItemToCart(long vinylPlateId);
    Task<Result> RemoveItemFromCart(long vinylPlateId);
    Task<Result> ChangeQuantity(long vinylPlateId, int quantity);
}