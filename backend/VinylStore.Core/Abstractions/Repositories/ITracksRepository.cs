using VinylStore.Core.Models;

namespace VinylStore.Core.Abstractions.Repositories;

public interface ITracksRepository
{
    Task<IEnumerable<Track>> GetAll(CancellationToken ct);
    Task<Track?> GetById(long id, CancellationToken ct);
    Task Create(Track track, CancellationToken ct);
    Task Update(long id, Track track, CancellationToken ct);
    Task Delete(long id, CancellationToken ct);
}