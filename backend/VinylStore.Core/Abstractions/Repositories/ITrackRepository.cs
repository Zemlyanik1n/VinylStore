using VinylStore.Core.Models;

namespace VinylStore.Core.Abstractions.Repositories;

public interface ITrackRepository
{
    Task<IEnumerable<Track>> GetAll(CancellationToken ct);
    Task<Track?> GetById(Guid id, CancellationToken ct);
    Task Create(Track track, CancellationToken ct);
    Task Update(Guid id, Track track, CancellationToken ct);
    Task Delete(Guid id, CancellationToken ct);
}