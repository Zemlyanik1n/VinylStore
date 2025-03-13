using VinylStore.Application.Abstractions;
using VinylStore.Application.Abstractions.Auth;

namespace VinylStore.Infrastructure;

public class PasswordHasher : IPasswordHasher
{
    public string Generator(string password)
    {
        return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
    }

    public bool Verify(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
    }
}