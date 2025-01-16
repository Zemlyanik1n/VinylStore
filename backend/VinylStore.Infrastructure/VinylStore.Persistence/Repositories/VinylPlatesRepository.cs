using Microsoft.EntityFrameworkCore;
using VinylStore.Core.Abstractions.Repositories;
using VinylStore.Core.Models;

namespace VinylStore.Persistence.Repositories;

public class VinylPlatesRepository(VinylStoreDbContext context) : IVinylPlatesRepository
{
    private readonly VinylStoreDbContext _context = context;
    public async Task<IEnumerable<VinylPlate>> GetAll(CancellationToken ct)
    {
        return await _context.VinylPlates
            .AsNoTracking()
            .ToListAsync(ct);
    }

    public async Task<VinylPlate?> GetById(Guid id, CancellationToken ct)
    {
        return await _context.VinylPlates
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id, ct);
    }

    public async Task Create(VinylPlate vinylPlate, CancellationToken ct)
    {
        
        await _context.AddAsync(vinylPlate, ct);
        await _context.SaveChangesAsync(ct);
        
    }

    public Task Update(Guid id, VinylPlate vinylPlate, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(Guid id, CancellationToken ct)
    {
        await _context.VinylPlates
            .Where(v => v.Id == id)
            .ExecuteDeleteAsync(ct);
    }
}