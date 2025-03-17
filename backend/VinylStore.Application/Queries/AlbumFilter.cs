using VinylStore.Core.Abstractions.Filters;

namespace VinylStore.Application.Queries;

public class AlbumFilter : IAlbumFilter
{
    public string? Search { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public string? SortBy { get; set; }
}