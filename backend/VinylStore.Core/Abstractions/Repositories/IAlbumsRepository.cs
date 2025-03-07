using VinylStore.Core.Models;

namespace VinylStore.Core.Abstractions.Repositories;

public interface IAlbumsRepository
{
    Task<IEnumerable<Album>> GetAll(CancellationToken ct);
    Task<Album?> GetById(long id, CancellationToken ct);
    Task Create(Album album, CancellationToken ct);
    Task Update(long id, Album album, CancellationToken ct);
    Task Delete(long id, CancellationToken ct);
}