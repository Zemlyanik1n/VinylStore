using System.Dynamic;
using CSharpFunctionalExtensions;

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

    private VinylPlate(VinylPlateCondition condition, string manufacturer, string description, decimal price, int stockCount, int printYear,
        string coverImageUrl)
    {
        Condition = condition;
        Manufacturer = manufacturer;
        Description = description;
        Price = price;
        StockCount = stockCount;
        PrintYear = printYear;
        CoverImageUrl = coverImageUrl;
    }

    public static Result<VinylPlate> Create(VinylPlateCondition? condition, string? coverImageUrl,
        string? manufacturer, string? description, decimal price, int printYear, int stockCount)
    {
        if(condition == null)
            return Result.Failure<VinylPlate>("Invalid condition");
        if(string.IsNullOrEmpty(coverImageUrl))
            return Result.Failure<VinylPlate>("Invalid cover image url");
        if(string.IsNullOrEmpty( manufacturer))
            return Result.Failure<VinylPlate>("Invalid manufacturer");
        if(string.IsNullOrEmpty(description))
            return Result.Failure<VinylPlate>("Invalid description");
        if(price < 1)
            return Result.Failure<VinylPlate>("Invalid price");
        if(printYear < 1931 || DateTime.Now.Year < printYear)
            return Result.Failure<VinylPlate>("Invalid print year");
        if(stockCount < 0)
            return Result.Failure<VinylPlate>("Invalid stock count");

        var vinylPlate = new VinylPlate(condition.Value, manufacturer,description, price, stockCount, printYear,
            coverImageUrl);
        
        var res = Result.Success(vinylPlate);

        return res;
    }
}