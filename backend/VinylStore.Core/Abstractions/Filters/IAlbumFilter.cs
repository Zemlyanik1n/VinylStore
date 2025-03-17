using VinylStore.Core.Models;

namespace VinylStore.Core.Abstractions.Filters;

public interface IAlbumFilter
{
    string? Search { get; set; }
    int Page { get; set; }
    int PageSize { get; set; }
    string? SortBy { get; set; }
}