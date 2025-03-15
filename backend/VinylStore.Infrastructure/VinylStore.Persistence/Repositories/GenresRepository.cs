using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VinylStore.Core.Abstractions.Repositories;
using VinylStore.Core.Models;
using VinylStore.Persistence.Entities;

namespace VinylStore.Persistence.Repositories;

public class GenresRepository(VinylStoreDbContext context, IMapper mapper) : IGenresRepository
{
    private readonly VinylStoreDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<Genre>> GetUnique()
    {
        var result = await _context.Genres
            .AsNoTracking()
            .Distinct()
            .ToListAsync();
        return _mapper.Map<IEnumerable<Genre>>(result);
    }

    public async Task<IEnumerable<Genre>> GetAll(CancellationToken ct)
    {
        var result = await _context.Genres
            .AsNoTracking()
            .ToListAsync(ct);
        return _mapper.Map<IEnumerable<Genre>>(result);
    }

    public async Task<Genre?> GetById(long id, CancellationToken ct)
    {
        var result = await _context.Genres
            .AsNoTracking()
            .FirstOrDefaultAsync(g => g.Id == id, ct);
        return _mapper.Map<Genre>(result);
    }

    public async Task Create(Genre genre, CancellationToken ct)
    {
        var genreEntity = _mapper.Map<GenreEntity>(genre);
        await _context.Genres.AddAsync(genreEntity, ct);
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