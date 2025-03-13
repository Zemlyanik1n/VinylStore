using VinylStore.Application.Abstractions.Services;
using VinylStore.Application.DTOs.Requests;
using VinylStore.Application.DTOs.Responses;
using VinylStore.Application.Queries;
using VinylStore.Core.Abstractions.Repositories;
using VinylStore.Core.Models;

namespace VinylStore.Application.Services;

public class VinylsService(IVinylPlatesRepository vinylPlatesRepository, IGenresRepository genresRepository)
    : IVinylsService
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
            PrintYear = v.PrintYear,
            Condition = v.Condition switch
            {
                VinylPlateCondition.FactoryNew => "Только отпечатана",
                VinylPlateCondition.Good => "Хорошее",
                VinylPlateCondition.Bad => "Плохое",
                VinylPlateCondition.Used => "Б/У",
                _ => "Неизвестно"

            }
        });

        return new PaginatedResponse<VinylCatalogResponse>(
            result,
            filter.Page,
            filter.PageSize,
            totalCount
        );
    }
    public async Task<IEnumerable<GenreResponse>> GetUniqueGenres()
    {
        var genres = await genresRepository.GetUnique();
        var result = genres.Select(g => new GenreResponse
        {
            Id = g.Id,
            Name = g.Name,
        });
        return result;
    }
    public async Task<VinylPlateResponse?> GetVinylPlateById(long id)
    {
        var vinylPlate = await vinylPlatesRepository.GetById(id);
    
        if (vinylPlate?.Album == null) 
        {
            return null;
        }

        return new VinylPlateResponse()
        {
            Id = vinylPlate.Id,
            AlbumId = vinylPlate.AlbumId,
            Condition = vinylPlate.Condition switch
            {
                VinylPlateCondition.FactoryNew => "Только отпечатана",
                VinylPlateCondition.Good => "Хорошее",
                VinylPlateCondition.Used => "Б/у",
                VinylPlateCondition.Bad => "Плохое",
                _ => "Неизвестно"
            },
            CoverImageUrl = vinylPlate.CoverImageUrl,
            Manufacturer = vinylPlate.Manufacturer,
            Description = vinylPlate.Description,
            Price = vinylPlate.Price,
            PrintYear = vinylPlate.PrintYear,
            StockCount = vinylPlate.StockCount,
            Album = new AlbumResponse
            {
                Id = vinylPlate.Album.Id,
                AlbumName = vinylPlate.Album.AlbumName,
                ReleaseType = vinylPlate.Album.ReleaseType,
                ArtistName = vinylPlate.Album.ArtistName,
                Description = vinylPlate.Album.Description,
                Duration = vinylPlate.Album.Duration,
                ReleaseYear = vinylPlate.Album.ReleaseYear,
                Genres = vinylPlate.Album.Genres.Select(g => g.Name).ToList(),
                Tracks = vinylPlate.Album.Tracks
                    .Select(t => new TrackResponse
                    {
                        Name = t.Name,
                        DurationInSeconds = t.DurationInSeconds,
                        FormattedDurationInSeconds = $"{t.DurationInSeconds / 60}:{t.DurationInSeconds % 60:D2}",
                        Position = t.Position
                    })
                    .OrderBy(t => t.Position)
                    .ToList()
            }
        };
    }
    public async Task<IEnumerable<VinylSuggestionResponse>> GetSuggestions(string search, int count)
    {
        var vinyls = await vinylPlatesRepository.GetSuggestions(search, count);
            var result = vinyls.Select(v => new VinylSuggestionResponse
            {
                VinylPlateId = v.Id,
                AlbumName = v.Album.AlbumName,
                ArtistName = v.Album.ArtistName,
                CoverImageUrl = v.CoverImageUrl,
                Manufacturer = v.Manufacturer,
                ReleaseYear = v.Album.ReleaseYear,
                PrintYear = v.PrintYear,
            });

            return result;
    }
}