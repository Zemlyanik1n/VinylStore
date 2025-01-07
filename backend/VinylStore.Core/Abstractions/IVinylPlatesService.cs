using VinylStore.Core.Models;

namespace VinylStore.Application.Services;

public interface IVinylPlatesService
{
    Task<List<VinylPlate>> GetAllVinylPlates();
    Task<Guid> CreateVinylPlate(VinylPlate vinylPlate);

    Task<Guid> UpdateVinylPlate(Guid id, Guid albumId, string condition, string description,
        string format, string coverUrl, string manufacturer, int price, int printYear);

    Task<Guid> Delete(Guid id);
}