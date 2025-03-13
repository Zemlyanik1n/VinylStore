using VinylStore.Core.Models;

namespace VinylStore.Application.Abstractions.Auth;

public interface IJwtProvider
{
    string GenerateToken(User user);
}