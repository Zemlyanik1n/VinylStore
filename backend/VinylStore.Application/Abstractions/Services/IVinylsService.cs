using VinylStore.Application.DTOs.Requests;
using VinylStore.Application.DTOs.Responses;

namespace VinylStore.Application.Abstractions.Services;

public interface IVinylsService
{
    Task<PaginatedResponse<VinylCatalogResponse>> GetFilteredPagedVinyls(VinylFilterRequest filterRequest);
    Task<IEnumerable<GenreResponse>> GetUniqueGenres();
    Task<VinylPlateResponse?> GetVinylPlateById(long id);
    Task<IEnumerable<VinylSuggestionResponse>> GetSuggestions(string search, int count);
}