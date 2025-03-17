using System.Runtime.InteropServices.JavaScript;
using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;


namespace VinylStore.Core.Models;

public class User
{
    public const int MIN_PASSWORD_LENGTH = 8;

    public Guid Id { get; init; }
    public string Email { get; init; }
    public string? PhoneNumber { get; private set; }
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public string Password { get; private set; }

    public long? CartId { get; private set; }
    public Cart? Cart { get; private set; }
    public ICollection<DeliveryAddress>? DeliveryAddresses { get; private set; }
    public ICollection<Order>? Orders { get; private set; }

    private User()
    {
    }

    private User(Guid id, string email, string hashedPassword)
    {
        Id = id;
        Email = email;
        Password = hashedPassword;
    }
    
    public static Result<User> CreateCustomer(Guid id, string email, string passwordHash)
    {
        var validation = Validate(email, passwordHash);
        if (validation.IsFailure)
            return Result.Failure<User>(validation.Error);

        var user = new User(id, email, passwordHash)
        {
            Cart = Cart.Create(userId: Guid.NewGuid()).Value
        };
        return Result.Success(user);
    }
    
    private static Result Validate(string email, string hashedPassword)
    {
        if (string.IsNullOrWhiteSpace(email))
            return Result.Failure("Email is required");
        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            return Result.Failure("Email is not valid");
        if (string.IsNullOrWhiteSpace(hashedPassword))
            return Result.Failure("Password is required");
        if (hashedPassword.Length < MIN_PASSWORD_LENGTH)
            return Result.Failure("Password must be at least 8 characters long");

        return Result.Success();
    }
}


