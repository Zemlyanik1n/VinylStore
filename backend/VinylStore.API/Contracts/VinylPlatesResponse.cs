namespace VinylStore.Contracts;

public record VinylPlatesResponse(
    Guid Id,
    Guid AlbumId,
    string CoverUrl,
    string Format,
    string Condition,
    string Description,
    int PrintYear,
    decimal Price, 
    string Manufacturer,
    int Count);
    
    