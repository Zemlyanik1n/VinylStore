namespace VinylStore.Application.DTOs.Responses;

public record CartResponse()
{
    public CartItemResponse[] CartItems { get; set; }
}

public record CartItemResponse()
{
    public int Quantity { get; init; }
    public string CoverImageUrl { get; init; } = null!;
    public long VinylPlateId { get; init; }
    public string Manufacturer { get; init; } = null!;
    public int PrintYear { get; init; }
    public string ArtistName { get; init; } = null!;
    public string AlbumName { get; init; } = null!;
    public int ReleaseYear { get; init; }
    public decimal? Price { get; init; } = null!;
}
