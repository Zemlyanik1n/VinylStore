namespace VinylStore.DataAccess.Entities;

public class GenreEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<AlbumEntity>? Albums { get; set; } = [];
}