using VinylStore.Application.DTOs.Requests;
using VinylStore.Application.DTOs.Responses;
using VinylStore.Application.Queries;
using VinylStore.Core.Abstractions.Filters;
using VinylStore.Core.Abstractions.Repositories;

namespace VinylStore.Application.Services;

public class VinylsService(IVinylPlatesRepository vinylPlatesRepository) : IVinylsService
{
    public async Task<PaginatedResponse<VinylCatalogResponse>> GetFilteredPagedVinyls(VinylFilterRequest filterRequest)
    {
        var filter = new VinylFilter
        {
            Search = filterRequest.Search,
            Genre = filterRequest.Genre,
            ReleaseYear = filterRequest.ReleaseYear,
            ReleaseType = filterRequest.ReleaseType,
            MinPrice = filterRequest.MinPrice,
            MaxPrice = filterRequest.MaxPrice,
            Page = filterRequest.Page,
            PageSize = filterRequest.PageSize,
            SortBy = filterRequest.SortBy,
        };
        
        var (vinylPlates, totalCount) = await vinylPlatesRepository
            .GetAllFilteredPagedAsync(filter);
        var result = vinylPlates.Select(v => new VinylCatalogResponse
        {
            VinylPlateId = v.Id,
            CoverUrl = v.CoverImageUrl,
            AlbumName = v.Album.AlbumName,
            ArtistName = v.Album.ArtistName,
            ReleaseYear = v.Album.ReleaseYear,
            ReleaseType = v.Album.ReleaseType,
            Price = v.Price,
            Genres = v.Album.Genres.Select(g => g.Name).ToList(),
        });
        
        return new PaginatedResponse<VinylCatalogResponse>(
            result,
            filter.Page,
            filter.PageSize,
            totalCount
        );
    }

}
