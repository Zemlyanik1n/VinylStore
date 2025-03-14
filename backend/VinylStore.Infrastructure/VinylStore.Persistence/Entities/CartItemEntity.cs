namespace VinylStore.Persistence.Entities;

public class CartItemEntity
{
    public long Id { get; set; }
    public long VinylPlateId { get; set; }
    public VinylPlateEntity VinylPlate { get; set; }
    public long CartId { get; set; }
    public CartEntity Cart { get; set; }
    public int Count { get; set; }
}