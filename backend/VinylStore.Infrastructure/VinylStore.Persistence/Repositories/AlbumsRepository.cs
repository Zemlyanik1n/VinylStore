using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using VinylStore.Core.Abstractions.Filters;
using VinylStore.Core.Abstractions.Repositories;
using VinylStore.Core.Models;
using VinylStore.Persistence.Entities;

namespace VinylStore.Persistence.Repositories;

public class AlbumsRepository(VinylStoreDbContext context, IMapper mapper, IGenresRepository genresRepository)
    : IAlbumsRepository
{
    private readonly VinylStoreDbContext _context = context;
    private readonly IMapper _mapper = mapper;
    private readonly IGenresRepository _genresRepository = genresRepository;

    public async Task<IEnumerable<Album>> GetAll()
    {
        var result = await _context.Albums
            .AsNoTracking()
            .Include(a => a.Tracks)
            .Include(a => a.Genres)
            .ToListAsync();
        return _mapper.Map<IEnumerable<Album>>(result);
    }

    public async Task<Album?> GetById(long id)
    {
        var album = await _context.Albums
            .AsNoTracking()
            .Include(a => a.Tracks)
            .Include(a => a.Genres)
            .FirstOrDefaultAsync(t => t.Id == id);
        return _mapper.Map<Album>(album);
    }

    public async Task Create(Album album, IEnumerable<Genre> genres)
    {
        var albumEntity = _mapper.Map<AlbumEntity>(album);
        var genreEntities = _mapper.Map<List<GenreEntity>>(genres);
        foreach (var genreEntity in genreEntities)
        {
            _context.Genres.Attach(genreEntity);
            albumEntity.Genres.Add(genreEntity);
        }

        await _context.Albums.AddAsync(albumEntity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(long id, Album album)
    {
        var albumEntity = _mapper.Map<AlbumEntity>(album);
        _context.Albums.Update(albumEntity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(long id)
    {
        await _context.Albums
            .Where(t => t.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task<IEnumerable<Album>> GetByName(string name)
    {
        name = name.ToLower();
        var result = await _context.Albums
            .AsNoTracking()
            .Include(a => a.Tracks)
            .Include(a => a.Genres)
            .Where(a => a.AlbumName.ToLower().Contains(name) || a.ArtistName.ToLower().Contains(name))
            .ToListAsync();
        return _mapper.Map<IEnumerable<Album>>(result);
    }

    public async Task<(IEnumerable<Album> Items, int TotalCount)> GetFilteredPaginated(IAlbumFilter filter)
    {
        var baseQuery = BuildQuery(filter);
        var totalCount = await baseQuery.CountAsync();
        var pagedQuery = ApplyPaging(baseQuery, filter);
        var items = await pagedQuery.ToListAsync();

        var albums = _mapper.Map<IEnumerable<Album>>(items);

        return (albums, totalCount);
    }

    private IQueryable<AlbumEntity> BuildQuery(IAlbumFilter filter)
    {
        var query = _context.Albums
            .AsNoTracking()
            .Include(a => a.Tracks)
            .Include(a => a.Genres)
            .AsQueryable();

        if (filter.Search != null)
        {
            var search = filter.Search.ToLower();
            query = query.Where(a => a.AlbumName.ToLower().Contains(search) || a.ArtistName.ToLower().Contains(search));
        }


        if (filter.SortBy is null)
            return query;

        query = filter.SortBy switch
        {
            "release_year_asc" => query.OrderBy(v => v.ReleaseYear),
            "release_year_desc" => query.OrderByDescending(v => v.ReleaseYear),
            "album_name_asc" => query.OrderBy(v => v.AlbumName),
            "album_name_desc" => query.OrderByDescending(v => v.AlbumName),
            "artist_name_asc" => query.OrderBy(v => v.ArtistName),
            "artist_name_desc" => query.OrderByDescending(v => v.ArtistName),
            _ => query.OrderByDescending(v => v.ReleaseYear)
        };

        return query;
    }

    private static IQueryable<AlbumEntity> ApplyPaging(IQueryable<AlbumEntity> query, IAlbumFilter filter)
    {
        return query
            .Skip((filter.Page - 1) * filter.PageSize)
            .Take(filter.PageSize);
    }
}