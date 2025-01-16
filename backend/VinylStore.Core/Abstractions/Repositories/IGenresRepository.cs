using VinylStore.Core.Models;

namespace VinylStore.Core.Abstractions.Repositories;

public interface IGenresRepository
{
    Task<IEnumerable<Genre>> GetAll(CancellationToken ct);
    Task<Genre?> GetById(Guid id, CancellationToken ct);
    Task Create(Genre genre, CancellationToken ct);
    Task Update(Guid id, Genre genre, CancellationToken ct);
    Task Delete(Guid id, CancellationToken ct);
}