namespace VinylStore.Application.DTOs.Responses;

public record AlbumAdminResponse
{
    public long Id { get; init; }
    public string AlbumName { get; init; } = null!;
    public string ReleaseType { get; init; } = null!;
    public string ArtistName { get; init; } = null!;
    public string Description { get; init; } = null!;
    public int Duration { get; set; } = 0;
    public int ReleaseYear { get; set; } = 0;
    public List<GenreAdminResponse> Genres { get; init; } = null!;
    public List<TrackAdminResponse> Tracks { get; init; } = null!;
    

};

public record TrackAdminResponse
{
    public long Id { get; init; }
    public string TrackName { get; init; } = null!;
    public int Position { get; init; }
    public int Duration { get; init; }
}

public record GenreAdminResponse
{
    public long Id { get; init; }
    public string Name { get; init; } = null!;
}