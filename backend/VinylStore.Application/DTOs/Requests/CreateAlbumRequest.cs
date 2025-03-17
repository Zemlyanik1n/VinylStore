using System.ComponentModel.DataAnnotations;

namespace VinylStore.Application.DTOs.Requests;

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