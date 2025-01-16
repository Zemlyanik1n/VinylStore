using VinylStore.Core.Models;

namespace VinylStore.Core.Abstractions.Services;

public interface IVinylPlatesService
{
    Task<IEnumerable<VinylPlate>> GetAll();
    Task<Guid> Create(VinylPlate vinylPlate);

    Task<Guid> Update(Guid id, Guid albumId, string condition, string description,
        string format, string coverUrl, string manufacturer, decimal price, int printYear, int count);

    Task<Guid> Delete(Guid id);
}