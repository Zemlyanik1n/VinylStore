using CSharpFunctionalExtensions;
using VinylStore.Application.DTOs.Requests;
using VinylStore.Core.Models;

namespace VinylStore.Application.Abstractions.Services;

public interface IUsersService
{
    Task<Result> Register(UserRegisterRequest registerRequest);
    Task<Result<string>> Login (UserLoginRequest loginRequest);
    Task<Result<User>> GetUserByEmail(string email);
    
}