using CSharpFunctionalExtensions;
using VinylStore.Application.DTOs.Requests;
using VinylStore.Application.DTOs.Responses;

namespace VinylStore.Application.Abstractions.Services;

public interface IAlbumService
{
    Task<Result<PaginatedResponse<AlbumAdminResponse>>> GetAlbumsPaged(AlbumsRequest albumsRequest);
    Task<Result> DeleteAlbum(long id);
    Task<Result> CreateAlbum(CreateAlbumRequest albumRequest);
}