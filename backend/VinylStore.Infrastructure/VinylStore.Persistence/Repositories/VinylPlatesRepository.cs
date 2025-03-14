using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VinylStore.Core.Abstractions.Filters;
using VinylStore.Core.Abstractions.Repositories;
using VinylStore.Core.Models;
using VinylStore.Persistence.Entities;

namespace VinylStore.Persistence.Repositories;

public class VinylPlatesRepository(VinylStoreDbContext context, IMapper mapper) : IVinylPlatesRepository
{
    private readonly VinylStoreDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<(IEnumerable<VinylPlate> Items, int TotalCount)> GetAllFilteredPagedAsync(IVinylFilter filter)
    {
        var baseQuery = BuildQuery(filter); 
    
        // Запрос для общего количества (БЕЗ пагинации)
        var totalCount = await baseQuery.CountAsync(); 
    
        // Запрос для данных (С пагинацией)
        var pagedQuery = ApplyPaging(baseQuery, filter);
        var items = await pagedQuery.ToListAsync();
    
        return (_mapper.Map<IEnumerable<VinylPlate>>(items), totalCount);
    }

    public IQueryable<VinylPlateEntity> BuildQuery(IVinylFilter filter)
    {
        var query = _context.VinylPlates
            .AsNoTracking()
            .Include(v => v.Album)
            .ThenInclude(a => a.Genres)
            .AsSplitQuery();
            //.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Search))
            {
                query = query.Where(v => (v.Album.AlbumName.ToLower().Contains(filter.Search.ToLower())
                    || v.Album.ArtistName.ToLower().Contains(filter.Search.ToLower())));
            }

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
            "year_asc" => query.OrderBy(v => v.Album.ReleaseYear),
            _ => query.OrderByDescending(v => v.Album.ReleaseYear)
        };

        return query;
    }

    private static IQueryable<VinylPlateEntity> ApplyPaging(IQueryable<VinylPlateEntity> query, IVinylFilter filter)
    {
        return query
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize);
    }
    public async Task<VinylPlate?> GetById(long id)
    {
        var result =  await _context.VinylPlates
            .AsNoTracking()
            .Include(v => v.Album)
            .ThenInclude(a => a.Genres)
            .Include(v => v.Album)
            .ThenInclude(a => a.Tracks)
            .FirstOrDefaultAsync(p => p.Id == id);
        return _mapper.Map<VinylPlate>(result);
    }

    public async Task Create(VinylPlate vinylPlate, CancellationToken ct)
    {
        var vinylPlateEntity = _mapper.Map<VinylPlateEntity>(vinylPlate);
        await _context.VinylPlates.AddAsync(vinylPlateEntity, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task Delete(long id, CancellationToken ct)
    {
        await _context.VinylPlates
            .Where(v => v.Id == id)
            .ExecuteDeleteAsync(ct);
    }

    public async Task<IEnumerable<VinylPlate>> GetSuggestions(string searchQuery, int count)
    {
        searchQuery = searchQuery.ToLower();
        var vinylsAlbums = await _context.VinylPlates
            .AsNoTracking()
            .Include(v => v.Album)
            .Where(v => v.Album.AlbumName.ToLower().Contains(searchQuery))
            .Take(count)
            .ToListAsync();
        var remaining = count - vinylsAlbums.Count;

        if (remaining > 0)
        {
            var ids = vinylsAlbums.Select(v => v.Id).ToList();
            var vinylsArtists = await _context.VinylPlates
                .AsNoTracking()
                .Include(v => v.Album)
                .Where(v => v.Album.ArtistName.ToLower().Contains(searchQuery)
                            && !ids.Contains(v.Id) )
                .Take(remaining)
                .ToListAsync();
            vinylsAlbums.AddRange(vinylsArtists);
        }
        return _mapper.Map<IEnumerable<VinylPlate>>(vinylsAlbums);
    }

}