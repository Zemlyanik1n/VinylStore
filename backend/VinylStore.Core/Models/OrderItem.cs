namespace VinylStore.Core.Models;

public class OrderItem
{
    public long Id { get; set; }
    public long OrderId { get; set; }
    public Order? Order { get; set; }
    public long VinylPlateId { get; set; }
    public VinylPlate? VinylPlate { get; set; }
    public int Count { get; set; }

    private OrderItem()
    {
    }
}