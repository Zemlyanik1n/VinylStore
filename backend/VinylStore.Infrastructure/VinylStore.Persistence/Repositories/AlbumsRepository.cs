using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VinylStore.Core.Abstractions.Repositories;
using VinylStore.Core.Models;
using VinylStore.Persistence.Entities;

namespace VinylStore.Persistence.Repositories;

public class AlbumsRepository(VinylStoreDbContext context, IMapper mapper) : IAlbumsRepository
{
    private readonly VinylStoreDbContext _context = context;
    private readonly IMapper _mapper = mapper;
    
    public async Task<IEnumerable<Album>> GetAll(CancellationToken ct)
    {
        var result =  await _context.Albums
            .AsNoTracking()
            .ToListAsync(ct);
        
        return _mapper.Map<IEnumerable<Album>>(result);
    }

    public async Task<Album?> GetById(long id, CancellationToken ct)
    {
        var album = await _context.Albums
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id, ct);
        return _mapper.Map<Album>(album);
    }

    public async Task Create(Album album, CancellationToken ct)
    {
        var albumEntity = _mapper.Map<AlbumEntity>(album);
        await _context.Albums.AddAsync(albumEntity, ct);
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