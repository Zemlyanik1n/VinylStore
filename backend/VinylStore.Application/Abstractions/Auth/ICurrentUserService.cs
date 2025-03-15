namespace VinylStore.Application.Abstractions.Auth;

public interface ICurrentUserService
{
    Guid? UserId { get; }
    bool IsAuthenticated { get; }
}