using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VinylStore.Application.Abstractions.Auth;
using VinylStore.Infrastructure.Auth;
using VinylStore.Infrastructure.Services;

namespace VinylStore.Infrastructure.Extensions;

public static  class AddInfrastructureServicesExtension
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddScoped<IImageService, ImageService>();
        return services;
    }
}