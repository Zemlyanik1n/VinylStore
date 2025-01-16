using VinylStore.Core.Models;

namespace VinylStore.Core.Abstractions.Repositories;

public interface IAlbumsRepository
{
    Task<IEnumerable<Album>> GetAll(CancellationToken ct);
    Task<Album?> GetById(Guid id, CancellationToken ct);
    Task Create(Album album, CancellationToken ct);
    Task Update(Guid id, Album album, CancellationToken ct);
    Task Delete(Guid id, CancellationToken ct);
}