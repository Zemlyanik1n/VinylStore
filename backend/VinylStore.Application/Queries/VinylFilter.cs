using VinylStore.Core.Abstractions.Filters;

namespace VinylStore.Application.Queries;

public class VinylFilter : IVinylFilter
{
    public string? Search { get; set; }
    public string? Genre { get; set; }
    public int? ReleaseYear { get; set; }
    public string? ReleaseType { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 12;
    public string? SortBy { get; set; } = "year_desc";
}