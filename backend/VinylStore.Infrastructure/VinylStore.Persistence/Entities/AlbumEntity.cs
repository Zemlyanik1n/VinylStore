namespace VinylStore.Persistence.Entities;

public class AlbumEntity
{
    public long Id { get; set; }
    public string AlbumName { get; set; }
    public string ReleaseType { get; set; }
    public string ArtistName { get; set; } 
    public string Description { get; set; }
    public int Duration { get; set; } = 0;
    public int ReleaseYear { get; set; } = 0;
    public ICollection<GenreEntity> Genres { get; set; } = [];
    public ICollection<TrackEntity> Tracks { get; set; } = [];
    public ICollection<VinylPlateEntity> VinylPlates { get; set; } = []; 
}