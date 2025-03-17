using VinylStore.Core.Abstractions.Filters;
using VinylStore.Core.Models;

namespace VinylStore.Core.Abstractions.Repositories;

public interface IAlbumsRepository
{
    Task<IEnumerable<Album>> GetAll();
    Task<Album?> GetById(long id);
    Task Create(Album album, IEnumerable<Genre> genres);
    Task Update(long id, Album album);
    Task Delete(long id);
    Task<IEnumerable<Album>> GetByName(string name);
    Task<(IEnumerable<Album> Items, int TotalCount)> GetFilteredPaginated(IAlbumFilter filter);

}