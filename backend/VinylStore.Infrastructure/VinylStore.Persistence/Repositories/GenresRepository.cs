using System.Collections;
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

    public async Task<IEnumerable<Genre>> GetAll()
    {
        var result = await _context.Genres
            .AsNoTracking()
            .ToListAsync();
        return _mapper.Map<IEnumerable<Genre>>(result);
    }

    public async Task<Genre?> GetById(long id)
    {
        var result = await _context.Genres
            .AsNoTracking()
            .FirstOrDefaultAsync(g => g.Id == id);
        return _mapper.Map<Genre>(result);
    }

    public async Task Create(Genre genre)
    {
        var genreEntity = _mapper.Map<GenreEntity>(genre);
        await _context.Genres.AddAsync(genreEntity);
        await _context.SaveChangesAsync();
    }

    public Task Update(Genre genre)
    {
        var genreEntity = _mapper.Map<GenreEntity>(genre);
        _context.Genres.Update(genreEntity);
        return _context.SaveChangesAsync();
    }

    public async Task Delete(long id)
    {
        await _context.Genres
            .Where(g => g.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task<IEnumerable<Genre>> GetByName(string name)
    {
        var result = await _context.Genres
            .AsNoTracking()
            .Where(g => g.Name.ToLower() == name.ToLower())
            .ToListAsync();
        return _mapper.Map<IEnumerable<Genre>>(result);
    }

    public async Task<IEnumerable<Genre>> GetByNames(IEnumerable<string?> names)
    {
        names = names.Select(n => n.ToLower());
        var result = await _context.Genres
            .AsNoTracking()
            .Where(g => names.Contains(g.Name.ToLower()))
            .ToListAsync();
        return _mapper.Map<IEnumerable<Genre>>(result);
    }
}