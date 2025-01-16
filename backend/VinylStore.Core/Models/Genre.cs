namespace VinylStore.Core.Models;

public class Genre
{
    private Genre()
    {
        
    }
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}