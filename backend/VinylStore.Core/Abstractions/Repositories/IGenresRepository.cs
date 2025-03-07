using VinylStore.Core.Models;

namespace VinylStore.Core.Abstractions.Repositories;

public interface IGenresRepository
{
    Task<IEnumerable<Genre>> GetAll(CancellationToken ct);
    Task<Genre?> GetById(long id, CancellationToken ct);
    Task Create(Genre genre, CancellationToken ct);
    Task Update(long id, Genre genre, CancellationToken ct);
    Task Delete(long id, CancellationToken ct);
}