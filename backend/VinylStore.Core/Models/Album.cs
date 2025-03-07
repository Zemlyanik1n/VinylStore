
using System.Drawing;

namespace VinylStore.Core.Models;

public class Album
{
    private Album()
    {
    }
    public long Id { get; set; }
    public string AlbumName { get; set; }
    public string ReleaseType { get; set; }
    public string ArtistName { get; set; } 
    public string Description { get; set; }
    public int Duration { get; set; } = 0;
    public int ReleaseYear { get; set; } = 0;
    public ICollection<Genre> Genres { get; set; } = [];
    public ICollection<Track> Tracks { get; set; } = [];
    public ICollection<VinylPlate> VinylPlates { get; set; } = []; 
}