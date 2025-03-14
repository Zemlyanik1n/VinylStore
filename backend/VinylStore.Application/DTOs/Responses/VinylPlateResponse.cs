namespace VinylStore.Application.DTOs.Responses;

public record VinylPlateResponse
{
    public long Id { get; set; }
    public long AlbumId { get; set; }
    public string Condition { get; set; } = null!;
    public string CoverImageUrl { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int PrintYear { get; set; }
    public int StockCount { get; set; }
    public AlbumResponse Album { get; set; } = null!;
}

public record AlbumResponse
{
    public long Id { get; set; }
    public string AlbumName { get; set; } = null!;
    public string ReleaseType { get; set; } = null!;
    public string ArtistName { get; set; } = null!;      
    public string Description { get; set; } = null!;
    public int Duration { get; set; }
    public int ReleaseYear { get; set; }
    public List<string> Genres { get; set; } = [];
    public ICollection<TrackResponse> Tracks { get; set; } = [];
}
public record TrackResponse
{
    public int DurationInSeconds { get; set; }
    public string FormattedDurationInSeconds { get; set; } = null!;
    public string Name { get; set; } = null!;
    public int Position { get; set; }
}