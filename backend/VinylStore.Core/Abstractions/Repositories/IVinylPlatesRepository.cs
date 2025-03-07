using VinylStore.Core.Abstractions.Filters;
using VinylStore.Core.Models;

namespace VinylStore.Core.Abstractions.Repositories;

public interface IVinylPlatesRepository
{
    Task<(IEnumerable<VinylPlate> Items, int TotalCount)> GetAllFilteredPagedAsync(IVinylFilter filter);
    IQueryable<VinylPlate> BuildQuery(IVinylFilter filter);
    Task<VinylPlate?> GetById(long id, CancellationToken ct);
    Task Create(VinylPlate vinylPlate, CancellationToken ct);
    Task Delete(long id, CancellationToken ct);
}