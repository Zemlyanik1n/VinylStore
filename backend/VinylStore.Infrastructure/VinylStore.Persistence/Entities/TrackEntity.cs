namespace VinylStore.Persistence.Entities;

public class TrackEntity
{
    public long Id { get; set; }
    public int DurationInSeconds { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public int Position { get; set; } = 0;
    public long AlbumId { get; set; }
    public AlbumEntity Album { get; set; }
}