using Microsoft.EntityFrameworkCore;
using VinylStore.Core.Abstractions;
using VinylStore.Core.Models;

namespace VinylStore.Persistence.Repositories;

public class VinylPlatesRepository : IVinylPlatesRepository
{
    private readonly VinylStoreDbContext _context;
    
    public VinylPlatesRepository(VinylStoreDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<VinylPlate>> GetAll(CancellationToken ct)
    {
        var vinylPlates = await _context.VinylPlates
            .AsNoTracking()
            .ToListAsync();
        
        return vinylPlates;
    }

    public async Task<VinylPlate?> GetById(Guid id, CancellationToken ct)
    {
        return await _context.VinylPlates
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Guid> Create(VinylPlate vinylPlate, CancellationToken ct)
    {
        
        await _context.AddAsync(vinylPlate);
        await _context.SaveChangesAsync();
        
        return vinylPlate.Id;
    }

    public Task<Guid> Update(Guid id, VinylPlate vinylPlate, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> Delete(Guid id, CancellationToken ct)
    {
        await _context.VinylPlates
            .Where(v => v.Id == id)
            .ExecuteDeleteAsync();
        return id;
    }
}