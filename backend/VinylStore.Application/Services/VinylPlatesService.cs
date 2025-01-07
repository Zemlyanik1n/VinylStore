using VinylStore.Core.Abstractions;
using VinylStore.Core.Models;

namespace VinylStore.Application.Services;

public class VinylPlatesService : IVinylPlatesService
{
    private readonly IVinylPlatesRepository _vinylPlatesRepository;
    
    public VinylPlatesService(IVinylPlatesRepository vinylPlatesRepository)
    {   
        _vinylPlatesRepository = vinylPlatesRepository;
    }

    public async Task<List<VinylPlate>> GetAllVinylPlates()
    {
        return await _vinylPlatesRepository.Get();
    }

    public async Task<Guid> CreateVinylPlate(VinylPlate vinylPlate)
    {
        return await _vinylPlatesRepository.Create(vinylPlate);
    }

    public async Task<Guid> UpdateVinylPlate(Guid id, Guid albumId, string condition, string description,
        string format, string coverUrl, string manufacturer, int price, int printYear)
    {
        return await _vinylPlatesRepository.Update(id, albumId, condition, description, format, coverUrl, manufacturer,
            price, printYear);
    }

    public async Task<Guid> Delete(Guid id)
    {
        return await _vinylPlatesRepository.Delete(id);
    }
}