using VinylStore.Core.Abstractions;
using VinylStore.Core.Abstractions.Repositories;
using VinylStore.Core.Abstractions.Services;
using VinylStore.Core.Models;

namespace VinylStore.Application.Services;

public class VinylPlatesService : IVinylPlatesService
{
    private readonly IVinylPlatesRepository _vinylPlatesRepository;
    private IVinylPlatesService _vinylPlatesServiceImplementation;

    public VinylPlatesService(IVinylPlatesRepository vinylPlatesRepository)
    {   
        _vinylPlatesRepository = vinylPlatesRepository;
    }

    public Task<IEnumerable<VinylPlate>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Guid> Create(VinylPlate vinylPlate)
    {
        throw new NotImplementedException();
    }

    public Task<Guid> Update(Guid id, Guid albumId, string condition, string description, string format, string coverUrl,
        string manufacturer, decimal price, int printYear, int count)
    {
        throw new NotImplementedException();
    }

    public Task<Guid> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}