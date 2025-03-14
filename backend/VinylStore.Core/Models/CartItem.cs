namespace VinylStore.Core.Models;

public class CartItem
{
    private CartItem()
    { }
    public long Id { get; set; }
    public long VinylPlateId { get; set; }
    public VinylPlate VinylPlate { get; set; }
    public long CartId { get; set; }
    public Cart Cart { get; set; }
    public int Count { get; set; }
}