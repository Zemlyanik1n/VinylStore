using CSharpFunctionalExtensions;
using VinylStore.Application.Abstractions.Services;
using VinylStore.Application.DTOs.Requests;
using VinylStore.Application.DTOs.Responses;
using VinylStore.Application.Queries;
using VinylStore.Core.Abstractions.Repositories;
using VinylStore.Core.Models;

namespace VinylStore.Application.Services;

public class AlbumService(IAlbumsRepository albumsRepository, IGenresRepository genresRepository) : IAlbumService
{
    private readonly IAlbumsRepository _albumsRepository = albumsRepository;
    private readonly IGenresRepository _genresRepository = genresRepository;

    public async Task<Result<PaginatedResponse<AlbumAdminResponse>>> GetAlbumsPaged(AlbumsRequest albumsRequest)
    {
        var filter = new AlbumFilter
        {
            Search = albumsRequest.Search,
            Page = albumsRequest.Page,
            PageSize = albumsRequest.PageSize,
            SortBy = albumsRequest.SortBy,
        };
        var result = await _albumsRepository.GetFilteredPaginated(filter);

        var albums = result.Items.Select(a => new AlbumAdminResponse
            {
                Id = a.Id,
                AlbumName = a.AlbumName,
                ReleaseType = a.ReleaseType,
                ArtistName = a.ArtistName,
                Description = a.Description,
                Duration = a.Duration,
                ReleaseYear = a.ReleaseYear,
                Tracks = a.Tracks.Select(t => new TrackAdminResponse
                {
                    Id = t.Id,
                    Position = t.Position,
                    Duration = t.DurationInSeconds,
                    TrackName = t.Name,
                }).OrderBy(t => t.Position).ToList(),
                Genres = a.Genres.Select(g => new GenreAdminResponse
                {
                    Id = g.Id,
                    Name = g.Name
                }).ToList()
            }
        );

        var response = new PaginatedResponse<AlbumAdminResponse>(
            albums,
            filter.Page,
            filter.PageSize,
            result.TotalCount
        );

        return Result.Success<PaginatedResponse<AlbumAdminResponse>>(response);
    }

    public async Task<Result> DeleteAlbum(long id)
    {
        await _albumsRepository.Delete(id);
        return Result.Success("album deleted");
    }

    public async Task<Result> CreateAlbum(CreateAlbumRequest albumRequest)
    {
        if (albumRequest.Genres.Count == 0)
            return Result.Failure("Genre list is empty");

        if (albumRequest.Tracks.Count == 0)
            return Result.Failure("Track list is empty");

        if (albumRequest.AlbumName == null)
            return Result.Failure("Album name is empty");

        if (albumRequest.ReleaseType == null)
            return Result.Failure("Release type is empty");

        if (albumRequest.ReleaseYear < 1700 || albumRequest.ReleaseYear > DateTime.Now.Year)
            return Result.Failure("Release year is out of range");

        if (albumRequest.Description == null)
            return Result.Failure("Description is empty");

        if (albumRequest.ArtistName is null)
            return Result.Failure("Artist name is empty");

        var query = albumRequest.Genres.Select(g => g.Name).ToList();
        var existingGenres = (await _genresRepository.GetByNames(query)).ToList();
        var existingGenresNames = existingGenres.Select(g => g.Name.ToLower()).ToList();
        var genresFromRequest = albumRequest.Genres
            .Where(g => !existingGenresNames.Contains(g.Name.ToLower()));
        
        foreach (var genre in genresFromRequest)
        {
            var genreResult = Genre.Create(genre.Name);
            if (genreResult.IsFailure)
                return Result.Failure(genreResult.Error);
            existingGenres.Add(genreResult.Value);
        }
        
        var tracksToAdd = new List<Track>();
        foreach (var track in albumRequest.Tracks)
        {
            var trackResult = Track.Create(track.Name, track.DurationInSeconds, track.Position);
            if (trackResult.IsFailure)
                return Result.Failure(trackResult.Error);
            tracksToAdd.Add(trackResult.Value);
        }

        var durationOfAlbum = tracksToAdd.Sum(t => t.DurationInSeconds);
        
        var albumToAdd = Album.Create(albumRequest.AlbumName, albumRequest.ReleaseType, albumRequest.ArtistName,
            albumRequest.Description, durationOfAlbum, albumRequest.ReleaseYear, tracksToAdd);

        if (albumToAdd.IsFailure)
            return Result.Failure(albumToAdd.Error);

        await _albumsRepository.Create(albumToAdd.Value, existingGenres);

        return Result.Success("album added");
    }

}