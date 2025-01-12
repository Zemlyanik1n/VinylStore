using VinylStore.Core.Models;

namespace VinylStore.Core.Abstractions;

public interface IVinylPlatesRepository
{
    Task<List<VinylPlate>> GetAll();
    Task<Guid> Create(VinylPlate vinylPlate);
    Task<Guid> Update(Guid id, Guid albumId, string condition, string description,
        string format, string coverUrl, string manufacturer, decimal price, int printYear);
    Task<Guid> Delete(Guid id);
}