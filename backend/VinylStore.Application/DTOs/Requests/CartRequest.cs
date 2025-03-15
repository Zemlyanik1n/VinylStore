using System.ComponentModel.DataAnnotations;
using VinylStore.Core.Models;

namespace VinylStore.Application.DTOs.Requests;

public record CartRequest()
{
    [Range(0, int.MaxValue)] [Required] public long VinylPlateId { get; init; }
}