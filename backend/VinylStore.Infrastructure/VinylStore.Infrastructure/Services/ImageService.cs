using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace VinylStore.Infrastructure.Services;

public class ImageService(IWebHostEnvironment environment) : IImageService
{
    private readonly IWebHostEnvironment _environment = environment;

    public async Task<string> SaveImageAsync(IFormFile image)
    {
        var uploadsPath = Path.Combine(_environment.WebRootPath, "images", "vinyls");
        Directory.CreateDirectory(uploadsPath);

        var fileName = $"{Guid.NewGuid()}.jpg";
        var filePath = Path.Combine(uploadsPath, fileName);

        await using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await image.CopyToAsync(stream);
        }

        return $"/images/vinyls/{fileName}";
    }

    public void DeleteImage(string imageUrl)
    {
        var filePath = Path.Combine(_environment.WebRootPath, imageUrl.TrimStart('/'));
        if (File.Exists(filePath)) File.Delete(filePath);
    }
}