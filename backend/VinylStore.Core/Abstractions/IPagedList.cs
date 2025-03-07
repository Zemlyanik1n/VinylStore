namespace VinylStore.Core.Abstractions;

public interface IPagedList<T>
{
    List<T>? Items { get; set; }
    int TotalCount { get; set; }
    int Page { get; set; }
    int PageSize { get; set; }
}