namespace VinylStore.Core.Models;

public class Track
{
    private Track()
    {
    }

    public Guid Id { get; set; }
    public int Duration { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public int Position { get; set; } = 0; 
    public virtual Guid AlbumId { get; set; }
    public virtual Album? Album { get; set; }
  
}