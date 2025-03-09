using Microsoft.EntityFrameworkCore;
using VinylStore.Core.Abstractions.Repositories;
using VinylStore.Core.Models;

namespace VinylStore.Persistence.Repositories;

public class GenresRepository(VinylStoreDbContext context) : IGenresRepository
{
    private readonly VinylStoreDbContext _context = context;

    public async Task<IEnumerable<Genre>> GetUnique()
    {
        return await _context.Genres
            .AsNoTracking()
            .Distinct()
            .ToListAsync();
    }

    public async Task<IEnumerable<Genre>> GetAll(CancellationToken ct)
    {
        return await _context.Genres
            .AsNoTracking()
            .ToListAsync(ct);
    }

    public async Task<Genre?> GetById(long id, CancellationToken ct)
    {
        return await _context.Genres
            .AsNoTracking()
            .FirstOrDefaultAsync(g => g.Id == id, ct);
    }

    public async Task Create(Genre genre, CancellationToken ct)
    {
        await _context.Genres.AddAsync(genre, ct);
        await _context.SaveChangesAsync(ct);
    }

    public Task Update(long id, Genre genre, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(long id, CancellationToken ct)
    {
        await _context.Genres
            .Where(g => g.Id == id)
            .ExecuteDeleteAsync(ct);
    }
}