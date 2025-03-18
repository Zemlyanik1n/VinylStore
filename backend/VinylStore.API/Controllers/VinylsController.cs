using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinylStore.Application.Abstractions.Services;
using VinylStore.Application.DTOs.Requests;
using VinylStore.Attributes;
using VinylStore.Core.Enums;

namespace VinylStore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VinylsController(IVinylsService vinylsService) : ControllerBase
{
    private readonly IVinylsService _vinylsService = vinylsService;

    [HttpGet("catalog")]
    public async Task<IActionResult> GetVinylsWithFilters([FromQuery] VinylFilterRequest filter)
    {
        try
        {
            var result = await _vinylsService.GetFilteredPagedVinyls(filter);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("genres")]
    public async Task<IActionResult> GetUniqueGenres()
    {
        try
        {
            var result = await _vinylsService.GetUniqueGenres();
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetVinylPlateById(long id)
    {
        try
        {
            var result = await _vinylsService.GetVinylPlateById(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    /// <summary>
    /// Получить список первых совпадений альбомов и музыкантов по введеной строке
    /// </summary>
    /// <param name="query"> строка подзапроса поиска</param>
    /// <returns>список совпадений винила</returns>
    /// <exception cref="Exception"></exception>
    [HttpGet("suggestions")]
    public async Task<IActionResult> GetSuggestions([FromQuery] string query)
    {
        const int numOfSuggestions = 5; // количество подсказок, пока оставлю здесь, позже подумать, куда убрать
        try
        {
            if (!string.IsNullOrEmpty(query) && query.Length > 2)
            {
                var result = await _vinylsService.GetSuggestions(query, numOfSuggestions);
                return Ok(result);
            }
            else
            {
                throw new Exception("query string lenght must be more than 2");
            }
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [Authorize]
    [HasPermission(Permissions.CreateVinyls)]
    [HttpPost("add")]
    public async Task<IActionResult> CreateVinylPlate(
        [FromForm] CreateVinylPlateRequest request)
    {
        var result = await _vinylsService.CreateVinylPlate(request);
        if(result.IsFailure)
            return BadRequest(result.Error);
        return Ok("album created");
    }

    
    [Authorize]
    [HasPermission(Permissions.DeleteVinyls)]
    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteVinylPlate(long id)
    {
        var result = await _vinylsService.DeleteVinylPlate(id);
        if(result.IsFailure)
            return BadRequest(result.Error);
        return Ok(result);
    }
}