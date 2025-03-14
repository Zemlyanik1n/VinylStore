namespace VinylStore.Application.DTOs.Requests;

public record VinylFilterRequest
{
    public string? Search { get; set; }
    public string? Genre { get; set; }
    public int? ReleaseYear { get; set; }
    public string? ReleaseType { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 4;
    public string SortBy { get; set; } = "year_desc";
}