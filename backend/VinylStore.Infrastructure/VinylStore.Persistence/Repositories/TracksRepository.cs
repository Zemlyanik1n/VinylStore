using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VinylStore.Core.Abstractions;
using VinylStore.Core.Abstractions.Repositories;
using VinylStore.Core.Models;
using VinylStore.Persistence.Entities;

namespace VinylStore.Persistence.Repositories;

public class TracksRepository(VinylStoreDbContext context, IMapper mapper) : ITracksRepository
{
    private readonly VinylStoreDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<Track>> GetAll(CancellationToken ct)
    {
        var result = await _context.Tracks
            .AsNoTracking()
            .ToListAsync(ct);
        return _mapper.Map<IEnumerable<Track>>(result);
    }

    public async Task<Track?> GetById(long id, CancellationToken ct)
    {
        var track = await _context.Tracks
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id, ct);
        return _mapper.Map<Track>(track);
    }

    public async Task Create(Track track, CancellationToken ct)
    {
        var trackEntity = _mapper.Map<TrackEntity>(track);
        await _context.Tracks.AddAsync(trackEntity, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task Update(long id, Track track, CancellationToken ct)
    {
    }

    public async Task Delete(long id, CancellationToken ct)
    {
        await _context.Tracks
            .Where(t => t.Id == id)
            .ExecuteDeleteAsync(ct);
    }
}