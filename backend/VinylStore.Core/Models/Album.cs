
namespace VinylStore.Core.Models;

public class Album
{
    public Guid Id { get; set; }
    public string AlbumName { get; set; } = string.Empty;
    public string ReleaseType { get; set; } = string.Empty;
    public string ArtistName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Duration { get; set; } = 0;
    public int ReleaseYear { get; set; } = 0;
    public virtual ICollection<Genre>? Genres { get;} = [];
    public virtual ICollection<VinylPlate>? VinylPlates { get;} = [];
    public virtual ICollection<Track>? Tracks { get;} = [];
}