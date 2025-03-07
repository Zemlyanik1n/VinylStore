namespace VinylStore.Core.Models;

public class Genre
{
    private Genre()
    {
    }
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
}