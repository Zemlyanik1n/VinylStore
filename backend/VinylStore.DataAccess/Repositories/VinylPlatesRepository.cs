using Microsoft.EntityFrameworkCore;
using VinylStore.Core.Abstractions;
using VinylStore.Core.Models;
using VinylStore.DataAccess.Entities;

namespace VinylStore.DataAccess.Repositories;

public class VinylPlatesRepository : IVinylPlatesRepository
{
    private readonly VinylStoreDbContext _context;
    
    public VinylPlatesRepository(VinylStoreDbContext context)
    {
        _context = context;
    }

    public async Task<List<VinylPlate>> GetAll()
    {
        var vinylPlatesEntities = await _context.VinylPlates
            .AsNoTracking()
            .ToListAsync();
        var vinylPlates = vinylPlatesEntities
            .Select(v => VinylPlate.Create(v.Id, v.AlbumId, v.Condition, v.Description, v.Format, v.CoverUrl, v.Manufacturer,
                v.Price, v.PrintYear).VinylPlate)
            .ToList();
        return vinylPlates;
    }

    public async Task<Guid> Create(VinylPlate vinylPlate)
    {
        var vinylPlateEntity = new VinylPlateEntity
        {
            Id = vinylPlate.Id,
            AlbumId = vinylPlate.AlbumId,
            Condition = vinylPlate.Condition,
            Description = vinylPlate.Description,
            Format = vinylPlate.Format,
            CoverUrl = vinylPlate.CoverUrl,
            Manufacturer = vinylPlate.Manufacturer,
            Price = vinylPlate.Price,
            PrintYear = vinylPlate.PrintYear,
        };
        
        await _context.AddAsync(vinylPlateEntity);
        await _context.SaveChangesAsync();
        
        return vinylPlateEntity.Id;
    }

    public async Task<Guid> Update(Guid id, Guid albumId, string condition, string description,
        string format, string coverUrl, string manufacturer, decimal price, int printYear)
    {
        await _context.VinylPlates
            .Where(v => v.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(x => x.Condition, x => condition)
                .SetProperty(x => x.Description, x => description)
                .SetProperty(x => x.Format, x => format)
                .SetProperty(x => x.CoverUrl, x => coverUrl)
                .SetProperty(x => x.Manufacturer, x => manufacturer)
                .SetProperty(x => x.AlbumId, x => albumId)
                .SetProperty(x => x.PrintYear, x => printYear)
                .SetProperty(x => x.Price, x => price)
            );
        return id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _context.VinylPlates
            .Where(v => v.Id == id)
            .ExecuteDeleteAsync();
        return id;
    }
}