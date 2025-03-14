namespace VinylStore.Application.DTOs.Responses;

public record PagedResponse<T>
{
    public List<T>? Items { get; set; }
    public int TotalCount { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 12;
}