using VinylStore.Core.Models;

namespace VinylStore.Core.Abstractions;

public interface IVinylPlatesRepository
{
    Task<List<VinylPlate>> Get();
    Task<Guid> Create(VinylPlate vinylPlate);
    Task<Guid> Update(Guid id, Guid albumId, string condition, string description,
        string format, string coverUrl, string manufacturer, int price, int printYear);
    Task<Guid> Delete(Guid id);
}