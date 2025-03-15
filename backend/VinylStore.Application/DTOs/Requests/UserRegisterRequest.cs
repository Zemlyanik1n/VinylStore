using System.ComponentModel.DataAnnotations;
using VinylStore.Core.Models;

namespace VinylStore.Application.DTOs.Requests;

public record UserRegisterRequest()
{
    [Required] [EmailAddress] public string Email { get; init; }

    [Required]
    [MinLength(User.MIN_PASSWORD_LENGTH)]
    public string Password { get; init; }
}