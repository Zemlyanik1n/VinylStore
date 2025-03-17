using System.Collections;
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

    public async Task<IEnumerable<Track>> GetAll()
    {
        var result = await _context.Tracks
            .AsNoTracking()
            .ToListAsync();
        return _mapper.Map<IEnumerable<Track>>(result);
    }

    public async Task<Track?> GetById(long id)
    {
        var track = await _context.Tracks
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id);
        return _mapper.Map<Track>(track);
    }

    public async Task Create(Track track)
    {
        var trackEntity = _mapper.Map<TrackEntity>(track);
        await _context.Tracks.AddAsync(trackEntity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Track track)
    {
        var trackEntity = _mapper.Map<TrackEntity>(track);
        _context.Tracks.Update(trackEntity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(long id)
    {
        await _context.Tracks
            .Where(t => t.Id == id)
            .ExecuteDeleteAsync();
    }
}