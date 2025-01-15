using VinylStore.Core.Models;

namespace VinylStore.Core.Abstractions;

public interface IAlbumsRepository
{
    Task<IEnumerable<Album>> GetAll();
    Task<Album> GetById(Guid id);
    Task<Guid> Create();
    Task<Guid> Update();
    Task<Guid> Delete(Guid id);
}

public interface ITracksRepository
{
    
}

public interface IGenresRepository
{
    
}