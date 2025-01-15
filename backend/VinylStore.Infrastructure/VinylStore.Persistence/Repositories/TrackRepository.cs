using Microsoft.EntityFrameworkCore;
using VinylStore.Core.Abstractions;
using VinylStore.Core.Abstractions.Repositories;
using VinylStore.Core.Models;

namespace VinylStore.Persistence.Repositories;

public class TrackRepository(VinylStoreDbContext context) : ITrackRepository
{
    private readonly VinylStoreDbContext _context = context;
    
    public async Task<IEnumerable<Track>> GetAll(CancellationToken ct)
    {
        return await _context.Tracks
            .AsNoTracking()
            .ToListAsync(ct);   
    }

    public async Task<Track?> GetById(Guid id, CancellationToken ct)
    {
        var track = await _context.Tracks
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id, ct);
        return track;
    }

    public async Task Create(Track track, CancellationToken ct)
    {
        await _context.Tracks.AddAsync(track, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task Update(Guid id, Track track, CancellationToken ct)
    {
        await _context.Tracks
            .Where(t => t.Id == track.Id)
            
    }

    public Task Delete(Guid id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}