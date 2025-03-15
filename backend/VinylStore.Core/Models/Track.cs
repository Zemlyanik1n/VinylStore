namespace VinylStore.Core.Models;

public class Track
{
    private Track()
    {
    }

    public long Id { get; set; }
    public int DurationInSeconds { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public int Position { get; set; } = 0;
    public long AlbumId { get; set; }
    public Album Album { get; set; }
}