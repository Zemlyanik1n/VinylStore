namespace VinylStore.DataAccess.Entities;

public class TrackEntity
{
    public Guid Id { get; set; }
    public int Duration { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public int Position { get; set; } = 0;
    public AlbumEntity? Album { get; set; }
    public Guid AlbumId { get; set; }
}