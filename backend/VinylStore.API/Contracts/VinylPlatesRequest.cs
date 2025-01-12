namespace VinylStore.Contracts;

public record VinylPlatesRequest(
    Guid AlbumId,
    string CoverUrl,
    string Format,
    string Condition,
    string Description,
    int PrintYear,
    decimal Price, 
    string Manufacturer);