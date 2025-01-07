namespace VinylStore.DataAccess.Entities;

public class VinylPlateEntity
{
    private const int MinimalPrintYear = 1900;
    public Guid Id { get; set; } = Guid.Empty;
    public Guid AlbumId { get; set; } = Guid.Empty;
    public string Condition { get; set; } = string.Empty;
    public string Format { get; set; } = string.Empty;
    public string CoverUrl { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Price { get; set; } = 0;
    public int PrintYear { get; set; } = MinimalPrintYear;
}