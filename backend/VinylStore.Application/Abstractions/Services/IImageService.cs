using Microsoft.AspNetCore.Http;

namespace VinylStore.Infrastructure.Services;

public interface IImageService
{
    Task<string> SaveImageAsync(IFormFile image);
    void DeleteImage(string imageUrl);
}