using Microsoft.EntityFrameworkCore;
using VinylStore.Core.Abstractions.Filters;
using VinylStore.Core.Abstractions.Repositories;
using VinylStore.Core.Models;

namespace VinylStore.Persistence.Repositories;

public class VinylPlatesRepository(VinylStoreDbContext context) : IVinylPlatesRepository
{
    private readonly VinylStoreDbContext _context = context;
    public async Task<(IEnumerable<VinylPlate> Items, int TotalCount)> GetAllFilteredPagedAsync(IVinylFilter filter)
    {
        var baseQuery = BuildQuery(filter); 
    
        // Запрос для общего количества (БЕЗ пагинации)
        var totalCount = await baseQuery.CountAsync(); 
    
        // Запрос для данных (С пагинацией)
        var pagedQuery = ApplyPaging(baseQuery, filter);
        var items = await pagedQuery.ToListAsync();
    
        return (items, totalCount);
    }

    public IQueryable<VinylPlate> BuildQuery(IVinylFilter filter)
    {
        var query = _context.VinylPlates
            .AsNoTracking()
            .Include(v => v.Album)
            .ThenInclude(a => a.Genres)
            .AsSplitQuery();
            //.AsQueryable();
        
        if (!string.IsNullOrEmpty(filter.Search))
            query = query.Where(v => v.Album.AlbumName.Contains(filter.Search));

        if (filter.MinPrice != null)
            query = query.Where(v => v.Price >= filter.MinPrice);
        
        if(filter.MaxPrice != null)
            query = query.Where(v => v.Price <= filter.MaxPrice);
        
        if(filter.ReleaseType != null)
            query = query.Where(v => v.Album.ReleaseType == filter.ReleaseType);
        
        if(filter.ReleaseYear != null)
            query = query.Where(v => v.Album.ReleaseYear == filter.ReleaseYear);

        if (!string.IsNullOrEmpty(filter.Genre))
        {
            query = query.Where(v => v.Album.Genres.Any(g => g.Name == filter.Genre));
        }

        if (string.IsNullOrEmpty(filter.SortBy)) return query;
        query = filter.SortBy switch
        {
            "price_asc" => query.OrderBy(v => v.Price),
            "price_desc" => query.OrderByDescending(v => v.Price),
            "year_asc" => query.OrderBy(v => v.PrintYear),
            _ => query.OrderByDescending(v => v.PrintYear)
        };

        return query;
    }
    private static IQueryable<VinylPlate> ApplyPaging(IQueryable<VinylPlate> query, IVinylFilter filter)
    {
        return query
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize);
    }
    public async Task<VinylPlate?> GetById(long id, CancellationToken ct)
    { // may be errors, catch
        return await _context.VinylPlates
            .AsNoTracking()
            .Include(v => v.Album)
            .ThenInclude(a => a.Genres)
            .Include(v => v.Album)
            .ThenInclude(a => a.Tracks)
            .SingleOrDefaultAsync(p => p.Id == id, ct);
    }

    public async Task Create(VinylPlate vinylPlate, CancellationToken ct)
    {
        await _context.VinylPlates.AddAsync(vinylPlate, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task Delete(long id, CancellationToken ct)
    {
        await _context.VinylPlates
            .Where(v => v.Id == id)
            .ExecuteDeleteAsync(ct);
    }

    // условный умный поиск - не совсем разумно использовать запрос к бд каждый раз
    // public async Task<IEnumerable<VinylPlate>> GetBySmartSearch(string albumName)
    // {
    //     var result = _context.VinylPlates
    //         .AsNoTracking()
    //         .Include(v => v.Album)
    //         .Where(v => v.Album.AlbumName.ToLower().Contains(albumName.ToLower()));
    //
    //     return await result.ToListAsync();
    // }

}