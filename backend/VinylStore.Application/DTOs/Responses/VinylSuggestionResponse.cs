namespace VinylStore.Application.DTOs.Responses;

public class VinylSuggestionResponse
{
    public long? VinylPlateId { get; set; }
    public string? AlbumName { get; set; }
    public string? ArtistName { get; set; }
    public string? CoverImageUrl { get; set; }
}