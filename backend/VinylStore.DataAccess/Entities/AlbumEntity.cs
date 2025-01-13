namespace VinylStore.DataAccess.Entities;

public class AlbumEntity
{
    public Guid Id { get; set; }
    public string AlbumName { get; set; } = string.Empty;
    public string ReleaseType { get; set; } = string.Empty;
    public string ArtistName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Duration { get; set; } = 0;
    public int ReleaseYear { get; set; } = 0;
    public List<GenreEntity>? Genres { get;} = [];
    public List<VinylPlateEntity>? VinylPlates { get;} = [];
    public List<TrackEntity>? Tracks { get;} = [];
}