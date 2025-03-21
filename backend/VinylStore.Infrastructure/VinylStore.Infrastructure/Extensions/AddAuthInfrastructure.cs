using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VinylStore.Application.Abstractions.Auth;
using VinylStore.Infrastructure.Auth;

namespace VinylStore.Infrastructure.Extensions;

public static class AddAuthInfrastructureExtensions
{
    public static IServiceCollection AddAuthInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(
            configuration.GetSection(nameof(JwtOptions)));
        services.Configure<AuthorizationOptions>(
            configuration.GetSection(nameof(AuthorizationOptions))); 
        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
        services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
        return services;
    }
}