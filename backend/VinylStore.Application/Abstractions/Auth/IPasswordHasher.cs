namespace VinylStore.Application.Abstractions.Auth;

public interface IPasswordHasher
{
    string Generator(string password);
    bool Verify(string password, string hashedPassword);
}