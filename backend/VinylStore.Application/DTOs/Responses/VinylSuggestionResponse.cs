namespace VinylStore.Application.DTOs.Responses;

public record VinylSuggestionResponse
{
    public long? VinylPlateId { get; set; }
    public string? AlbumName { get; set; }
    public string? ArtistName { get; set; }
    public string? CoverImageUrl { get; set; }

    public string? Manufacturer { get; set; }
    public int? PrintYear { get; set; }
    public int? ReleaseYear { get; set; }
}