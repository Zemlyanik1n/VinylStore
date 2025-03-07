namespace VinylStore.Core.Abstractions.Filters;

public interface IVinylFilter
{
    string? Search { get; set; }
    string? Genre { get; set; }
    int? ReleaseYear { get; set; }
    string? ReleaseType { get; set; }
    decimal? MinPrice { get; set; }
    decimal? MaxPrice { get; set; }
    int Page { get; set; }
    int PageSize { get; set; }
    string? SortBy { get; set; }
}