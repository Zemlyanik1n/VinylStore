namespace VinylStore.Application.DTOs.Responses;

public record UserInfoResponse
{
    public string Email { get; init; } = null!;
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    
    public string Role { get; init; } = null!;
}