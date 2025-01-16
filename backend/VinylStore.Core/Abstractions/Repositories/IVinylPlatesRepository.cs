using VinylStore.Core.Models;

namespace VinylStore.Core.Abstractions.Repositories;

public interface IVinylPlatesRepository
{
    Task<IEnumerable<VinylPlate>> GetAll(CancellationToken ct);
    Task<VinylPlate?> GetById(Guid id, CancellationToken ct);
    Task Create(VinylPlate vinylPlate , CancellationToken ct);
    Task Update(Guid id, VinylPlate vinylPlate, CancellationToken ct);
    Task Delete(Guid id, CancellationToken ct);
}