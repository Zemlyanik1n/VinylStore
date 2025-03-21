using Microsoft.Extensions.DependencyInjection;
using VinylStore.Application.Abstractions.Services;
using VinylStore.Application.Services;

namespace VinylStore.Application.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IPermissionService, PermissionService>();
        services.AddScoped<IVinylsService, VinylsService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ICartService, CartService>();
        services.AddScoped<IAlbumService, AlbumService>();

        return services;
    }
}