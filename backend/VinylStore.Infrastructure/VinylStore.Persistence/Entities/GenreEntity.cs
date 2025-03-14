namespace VinylStore.Persistence.Entities;

public class GenreEntity
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public ICollection<AlbumEntity> Albums { get; set; }
}