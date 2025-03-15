using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using VinylStore.Core.Abstractions.Repositories;
using VinylStore.Persistence.Repositories;

namespace VinylStore.Persistence;

public static class PersistenceExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<VinylStoreDbContext>();
        services.AddScoped<IVinylPlatesRepository, VinylPlatesRepository>();
        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<IAlbumsRepository, AlbumsRepository>();
        services.AddScoped<ITracksRepository, TracksRepository>();
        services.AddScoped<IGenresRepository, GenresRepository>();
        services.AddScoped<ICartRepository, CartRepository>();

        return services;
    }
}