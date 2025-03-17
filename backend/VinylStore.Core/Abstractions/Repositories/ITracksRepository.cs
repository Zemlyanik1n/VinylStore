using VinylStore.Core.Models;

namespace VinylStore.Core.Abstractions.Repositories;

public interface ITracksRepository
{
    Task<IEnumerable<Track>> GetAll();
    Task<Track?> GetById(long id);
    Task Create(Track track);
    Task Update(Track track);
    Task Delete(long id);
}