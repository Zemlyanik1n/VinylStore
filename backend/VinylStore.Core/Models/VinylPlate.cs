namespace VinylStore.Core.Models;

public enum VinylPlateCondition
{
    FactoryNew,
    Good,
    Used,
    Bad
}

public class VinylPlate
{
    private VinylPlate()
    {
    }

    public long Id { get; set; }
    public long AlbumId { get; set; }
    public VinylPlateCondition Condition { get; set; }
    public string CoverImageUrl { get; set; }
    public string Manufacturer { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int PrintYear { get; set; }
    public int StockCount { get; set; }

    public Album Album { get; set; }
}