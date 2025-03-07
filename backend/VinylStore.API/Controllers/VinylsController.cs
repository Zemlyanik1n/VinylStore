using Microsoft.AspNetCore.Mvc;
using VinylStore.Application.DTOs.Requests;
using VinylStore.Application.Services;

namespace VinylStore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VinylsController(IVinylsService vinylsService) : ControllerBase
{
    [HttpGet]
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
}