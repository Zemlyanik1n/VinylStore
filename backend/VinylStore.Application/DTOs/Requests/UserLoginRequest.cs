using System.ComponentModel.DataAnnotations;

namespace VinylStore.Application.DTOs.Requests;

public record UserLoginRequest()
{
    [Required]
    public string Email { get; init; }
    [Required]
    public string Password { get; init; }
}