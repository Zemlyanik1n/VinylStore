using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using VinylStore.Application.Abstractions.Services;
using VinylStore.Application.DTOs.Requests;
using VinylStore.Application.DTOs.Responses;
using VinylStore.Application.Queries;
using VinylStore.Core.Abstractions.Repositories;
using VinylStore.Core.Models;
using VinylStore.Infrastructure.Services;

namespace VinylStore.Application.Services;

public class VinylsService(IVinylPlatesRepository vinylPlatesRepository, IGenresRepository genresRepository, IImageService imageService,
    IAlbumsRepository albumRepository)
    : IVinylsService
{
    private readonly IVinylPlatesRepository _vinylPlatesRepository = vinylPlatesRepository;
    private readonly IGenresRepository _genresRepository = genresRepository;
    private readonly IImageService _imageService = imageService;
    private readonly IAlbumsRepository _albumRepository = albumRepository;

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

        var (vinylPlates, totalCount) = await _vinylPlatesRepository
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
        var genres = await _genresRepository.GetUnique();
        var result = genres.Select(g => new GenreResponse
        {
            Id = g.Id,
            Name = g.Name,
        });
        return result;
    }

    public async Task<VinylPlateResponse?> GetVinylPlateById(long id)
    {
        var vinylPlate = await _vinylPlatesRepository.GetById(id);

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
        var vinyls = await _vinylPlatesRepository.GetSuggestions(search, count);
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

    private bool IsImageValid(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return false;

        if (file.Length > 5 * 1024 * 1024) // 5MB
            return false;

        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
    
        return allowedExtensions.Contains(extension);
    }
    public async Task<Result> CreateVinylPlate(CreateVinylPlateRequest request)
    {
        if(request.Condition is null)
            return Result.Failure("condition cannot be null");
        if(string.IsNullOrEmpty(request.Description))
            return Result.Failure("description cannot be null");
        if(string.IsNullOrEmpty(request.Manufacturer))
            return Result.Failure("manufacturer cannot be null");
        if(request.PrintYear < 1931 || request.PrintYear > DateTime.Now.Year)
            return Result.Failure("print year must be between 1931 and present year");
        if(request.Price < 0)
            return Result.Failure("price cannot be negative");
        if(request.StockCount < 0)
            return Result.Failure("stock count cannot be negative");
        if(!IsImageValid(request.Image))
            return Result.Failure("image is not a valid image");
            
        var result = await _imageService.SaveImageAsync(request.Image);
        
        var vinylPlate = VinylPlate.Create(request.Condition, result, request.Manufacturer, request.Description,
            request.Price, request.PrintYear, request.StockCount);

        var album = await _albumRepository.GetById(request.AlbumId);
        
        if(album is null)
            return Result.Failure($"album with id {request.AlbumId} not found");
        
        if (vinylPlate.IsFailure)
        {
            _imageService.DeleteImage(result);
            return Result.Failure(vinylPlate.Error);
        }

        await _vinylPlatesRepository.CreateAsync(vinylPlate.Value, album);
        return Result.Success();
    }

    public async Task<Result> DeleteVinylPlate(long id)
    {
        await _vinylPlatesRepository.DeleteAsync(id);
        return Result.Success("plate deleted");
    }
}