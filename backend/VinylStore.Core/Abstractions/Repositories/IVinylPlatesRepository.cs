using VinylStore.Core.Models;

namespace VinylStore.Core.Abstractions;

public interface IVinylPlatesRepository
{
    Task<IEnumerable<VinylPlate>> GetAll(CancellationToken ct);
    Task<VinylPlate?> GetById(Guid id, CancellationToken ct);
    Task<Guid> Create(VinylPlate vinylPlate , CancellationToken ct);
    Task<Guid> Update(Guid id, VinylPlate vinylPlate, CancellationToken ct);
    Task<Guid> Delete(Guid id, CancellationToken ct);
}