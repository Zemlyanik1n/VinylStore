using VinylStore.Core.Models;

namespace VinylStore.Core.Abstractions.Services;

public interface IOrderService
{
    Task Create();
    Task Delete();
    Task Update();
    Task<Order> GetById(Guid id, CancellationToken ct);
    Task<IEnumerable<Order>> GetAll();
    Task<IEnumerable<Order>> GetAllByUserId();
}