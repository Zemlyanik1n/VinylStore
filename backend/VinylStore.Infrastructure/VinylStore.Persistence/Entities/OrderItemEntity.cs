namespace VinylStore.Persistence.Entities;

public class OrderItemEntity
{
    public long Id { get; set; }
    public long OrderId { get; set; }
    public OrderEntity? Order { get; set; }
    public long VinylPlateId { get; set; }
    public VinylPlateEntity? VinylPlate { get; set; }
    public int Count { get; set; }
}