using Microsoft.EntityFrameworkCore;
using VinylStore.Core.Abstractions.Repositories;
using VinylStore.Core.Models;

namespace VinylStore.Persistence.Repositories;

public class AlbumsRepository(VinylStoreDbContext context) : IAlbumsRepository
{
    private readonly VinylStoreDbContext _context = context;
    
    public async Task<IEnumerable<Album>> GetAll(CancellationToken ct)
    {
        return await _context.Albums
            .AsNoTracking()
            .ToListAsync(ct);
    }

    public async Task<Album?> GetById(long id, CancellationToken ct)
    {
        var album = await _context.Albums
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id, ct);
        return album;
    }

    public async Task Create(Album album, CancellationToken ct)
    {
        await _context.Albums.AddAsync(album, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task Update(long id, Album album, CancellationToken ct)
    {
        throw new Exception();
    }

    public async Task Delete(long id, CancellationToken ct)
    {
        await _context.Albums
            .Where(t => t.Id == id)
            .ExecuteDeleteAsync(ct);
    }
}