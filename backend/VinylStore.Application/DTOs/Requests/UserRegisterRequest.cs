using System.ComponentModel.DataAnnotations;

namespace VinylStore.Application.DTOs.Requests;

public record UserRegisterRequest()
{
    [Required] 
    public string Email { get; init; }
    [Required]
    public string Password { get; init; }
}