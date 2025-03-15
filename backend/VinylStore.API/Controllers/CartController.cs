using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinylStore.Application.Abstractions.Services;
using VinylStore.Application.DTOs.Requests;

namespace VinylStore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController(ICartService cartService) : ControllerBase
{
    private readonly ICartService _cartService = cartService;

    [HttpGet("cart")]
    [Authorize]
    public async Task<IActionResult> GetCart()
    {
        var result = await _cartService.GetCart();
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }

    [Authorize]
    [HttpPost("addToCart")]
    public async Task<IActionResult> AddToCart([FromBody] CartRequest request)
    {
        var result = await _cartService.AddItemToCart(request.VinylPlateId);
        if(result.IsFailure)
            return BadRequest(result.Error);
        return Ok();
    }

    [Authorize]
    [HttpDelete("removeFromCart")]
    public async Task<IActionResult> RemoveFromCart([FromBody] CartRequest request)
    {
        var result = await _cartService.RemoveItemFromCart(request.VinylPlateId);
        if (result.IsFailure)
            return BadRequest(result.Error);
        return Ok();
    }

    [Authorize]
    [HttpPut("changeQuantity")]
    public async Task<IActionResult> ChangeItemsInCart([FromBody] ToCartRequest request)
    {
        var result = await _cartService.ChangeQuantity(request.VinylPlateId, request.Quantity);
        
        if(result.IsFailure)
            return BadRequest(result.Error);
        return Ok();
    }
}