namespace VinylStore.Core.Models;

public class VinylPlate
{
    private const int MinimalPrintYear = 1900;
    private VinylPlate(Guid id, Guid albumId, string condition, string description, string format, string coverUrl, 
        string manufacturer, int price, int printYear)
    {
        Id = id;
        AlbumId = albumId;
        Condition = condition;
        Description = description;
        Format = format;
        CoverUrl = coverUrl;
        Price = price;
        Manufacturer = manufacturer;
        PrintYear = printYear;
    }

    public Guid Id { get;}
    public Guid AlbumId { get;} = Guid.Empty;
    public string Condition { get; } = string.Empty;
    public string Format { get; } = string.Empty;
    public string CoverUrl { get; } = string.Empty;
    public string Manufacturer { get; } = string.Empty;
    public string Description { get; } = string.Empty;
    public int Price { get; } = 0;
    public int PrintYear { get; } = MinimalPrintYear;

    public static (VinylPlate VinylPlate, string Error) Create(Guid id, Guid albumId, string condition, string description, string format,
        string coverUrl, string manufacturer, int price, int printYear)
    {
        var error = string.Empty;
        if (string.IsNullOrEmpty(condition))
        {
            error = "Condition is required";
        }
        
        var vinylPlate = new VinylPlate(id, albumId, condition, description, format, coverUrl, manufacturer, price, printYear);

        return (vinylPlate, error);
    }
}