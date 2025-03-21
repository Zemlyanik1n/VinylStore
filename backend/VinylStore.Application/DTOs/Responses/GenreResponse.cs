namespace VinylStore.Application.DTOs.Responses;

public record GenreResponse
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
}