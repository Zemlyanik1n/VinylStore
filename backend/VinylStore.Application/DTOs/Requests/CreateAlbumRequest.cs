using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using VinylStore.Core.Models;

namespace VinylStore.Application.DTOs.Requests;

public record CreateVinylPlateRequest(
    [Required] VinylPlateCondition? Condition,
    [Required] string? Manufacturer,
    [Required] string? Description,
    [Required][Range(1, 100000000)] decimal Price,
    [Required][Range(1, 3000)] int PrintYear,
    [Required][Range(0, int.MaxValue)] int StockCount,
    [Required][Range(1, long.MaxValue)] long AlbumId,
    IFormFile Image); 

public record CreateAlbumRequest(
    [Required] string? AlbumName,
    [Required] string? ReleaseType,
    [Required] string? ArtistName,
    [Required] string? Description,
    [Required][Range(1, int.MaxValue)] int ReleaseYear,
    [Required] ICollection<CreateTrackRequest> Tracks,
    [Required] ICollection<CreateGenreRequest> Genres);

public record CreateGenreRequest([Required] string? Name);

public record CreateTrackRequest(
    [Required]string? Name,
    [Required][Range(1, int.MaxValue)]int DurationInSeconds,
    [Required][Range(1, int.MaxValue)] int Position);