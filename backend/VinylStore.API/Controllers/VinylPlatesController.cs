using Microsoft.AspNetCore.Mvc;
using VinylStore.Application.Services;
using VinylStore.Contracts;

namespace VinylStore.Controllers;

[ApiController]
[Route("[controller]")]
public class VinylPlatesController : ControllerBase
{
    private readonly IVinylPlatesService _vinylPlatesService;
    
    public VinylPlatesController(IVinylPlatesService vinylPlatesService)
    {
        _vinylPlatesService = vinylPlatesService;    
    }

    [HttpGet]
    public async Task<ActionResult<List<VinylPlatesResponse>>> GetAllVinylPlates()
    {
        var vinylPlates = await _vinylPlatesService.GetAllVinylPlates();
        var response = vinylPlates.Select(v => new VinylPlatesResponse(v.Id, v.AlbumId,
            v.CoverUrl, v.Format, v.Condition, v.Description, v.PrintYear, v.Price, v.Manufacturer)).ToList();
        
        return Ok(response);
    }
}