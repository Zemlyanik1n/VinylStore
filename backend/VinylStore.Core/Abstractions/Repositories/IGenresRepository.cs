using VinylStore.Core.Models;

namespace VinylStore.Core.Abstractions.Repositories;

public interface IGenresRepository
{
    Task<IEnumerable<Genre>> GetUnique();
    Task<IEnumerable<Genre>> GetAll();
    Task<Genre?> GetById(long id);
    Task Create(Genre genre);
    Task Update(Genre genre);
    Task Delete(long id);
    Task<IEnumerable<Genre>> GetByNames(IEnumerable<string?> names);
}