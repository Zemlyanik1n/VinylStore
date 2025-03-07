namespace VinylStore.Application.DTOs.Responses;

public class VinylCatalogResponse
{
    public long VinylPlateId { get; set; }
    public string CoverUrl { get; set; } = null!;
    public string AlbumName { get; set; } = null!;
    public string ArtistName { get; set; } = null!;
    public int ReleaseYear { get; set; }
    public string ReleaseType { get; set; } = null!;
    public decimal Price { get; set; }
    public List<string>? Genres { get; set; }
}