using CSharpFunctionalExtensions;
using VinylStore.Application.DTOs.Requests;
using VinylStore.Application.DTOs.Responses;
using VinylStore.Core.Models;

namespace VinylStore.Application.Abstractions.Services;

public interface IAuthService
{
    Task<Result> Register(UserRegisterRequest registerRequest);
    Task<Result<string>> Login(UserLoginRequest loginRequest);
    Task<Result<User>> GetUserByEmail(string email);
    Task<Result<UserInfoResponse>> GetMe();
}