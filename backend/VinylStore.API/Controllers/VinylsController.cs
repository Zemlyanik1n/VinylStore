using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using VinylStore.Application.Abstractions;
using VinylStore.Application.DTOs.Requests;
using VinylStore.Application.Services;

namespace VinylStore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VinylsController(IVinylsService vinylsService) : ControllerBase
{
    [HttpGet("catalog")]
    public async Task<IActionResult> GetVinylsWithFilters([FromQuery] VinylFilterRequest filter)
    {
        try
        {
            var result = await vinylsService.GetFilteredPagedVinyls(filter);
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
            var result = await vinylsService.GetUniqueGenres();
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
            var result = await vinylsService.GetVinylPlateById(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("suggestions")]
    public async Task<IActionResult> GetSuggestions([FromQuery] string query)
    {
        const int numOfSuggestions = 5; // количество подсказок, пока оставлю здесь, позже подумать, куда убрать
        try
        {
            if (!string.IsNullOrEmpty(query) && query.Length > 2)
            {
                var result = await vinylsService.GetSuggestions(query, numOfSuggestions);
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
}