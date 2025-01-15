namespace VinylStore.Core.Models;   

public class VinylPlate
{
    private const int MinimalPrintYear = 1900;
    private VinylPlate(Guid id, Guid albumId, string condition, string description, string format, string coverUrl, 
        string manufacturer, decimal price, int printYear, int count)
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
        Count = count;
    }
    
    public Guid Id { get; set; }
    public Guid AlbumId { get; set; }
    public string Condition { get; set; } 
    public string Format { get; set;}
    public string CoverUrl { get; set;}
    public string Manufacturer { get; set;}
    public string Description { get;set; } 
    public decimal Price { get; set;}
    public int PrintYear { get; set;}
    public int Count { get;set;} 

    public virtual Album? Album { get; set;}
    public virtual ICollection<Order>? Orders { get;set; } = [];

    public static (VinylPlate VinylPlate, string Error) Create(Guid id, Guid albumId, string condition, string description, string format,
        string coverUrl, string manufacturer, decimal price, int printYear, int count)
    {
        var error = string.Empty;
        
        if (albumId == Guid.Empty)
        {
            error = "Album ID is required";
        }
        else if (string.IsNullOrEmpty(condition))
        {
            error = "Condition is required";
        }
        else if (string.IsNullOrEmpty(description))
        {
            error = "Description is required";
        }
        else if (string.IsNullOrEmpty(format))
        {
            error = "Format is required";
        }
        else if (string.IsNullOrEmpty(coverUrl))
        {
            error = "Cover URL is required";
        }
        else if (string.IsNullOrEmpty(manufacturer))
        {
            error = "Manufacturer is required";
        }
        else if (price <= 0)
        {
            error = "Price must be greater than zero";
        }
        else if (printYear <= 0)
        {
            error = "Print Year must be a valid year";
        }
        else if (count < 0)
        {
            error = "Count cannot be negative";
        }

        if (!string.IsNullOrEmpty(error))
        {
            return (null, error);
        }

        var vinylPlate = new VinylPlate(id, albumId, condition, description, format,
            coverUrl, manufacturer, price, printYear, count);

        return (vinylPlate, error);
    }
}