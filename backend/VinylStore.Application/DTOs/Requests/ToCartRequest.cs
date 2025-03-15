using System.ComponentModel.DataAnnotations;
using VinylStore.Core.Models;

namespace VinylStore.Application.DTOs.Requests;

public record ToCartRequest()
{
    [Required] [Range(1, long.MaxValue)]
    public long VinylPlateId { get; init; }
    [Range(1, int.MaxValue)]
    public int Quantity { get; init; }
}