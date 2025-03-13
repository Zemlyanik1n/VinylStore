using CSharpFunctionalExtensions;
using VinylStore.Application.Abstractions.Auth;
using VinylStore.Application.Abstractions.Services;
using VinylStore.Application.DTOs.Requests;
using VinylStore.Core.Abstractions.Repositories;
using VinylStore.Core.Models;

namespace VinylStore.Application.Services;

public class UsersService(IPasswordHasher passwordHasher, IUsersRepository usersRepository, IJwtProvider jwtProvider) : IUsersService
{
    private readonly IPasswordHasher _passwordHasher = passwordHasher;
    private readonly IUsersRepository _usersRepository = usersRepository;
    private readonly IJwtProvider _jwtProvider = jwtProvider;

    public async Task<Result> Register(UserRegisterRequest registerRequest)
    {
        var hashedPassword = _passwordHasher.Generator(registerRequest.Password);
        var user = User.Create(Guid.NewGuid(), registerRequest.Email, hashedPassword);
        if (user.IsFailure)
        {
            return Result.Failure(user.Error);
        }
        await _usersRepository.CreateAsync(user.Value);
        return Result.Success();
    }
    
    public async Task<Result<string>> Login(UserLoginRequest loginRequest)
    {
        var user = await _usersRepository.GetByEmailAsync(loginRequest.Email);
        if (user == null)
        {
            return Result.Failure<string>("There is no such user");
        }
        var result = _passwordHasher.Verify(loginRequest.Password, user.Password);

        if (!result)
            return Result.Failure<string>("Password is incorrect");
        
        var token = _jwtProvider.GenerateToken(user);

        return Result.Success(token);
    }

    public Task<Result<User>> GetUserByEmail(string email)
    {
        throw new NotImplementedException();
    }
}