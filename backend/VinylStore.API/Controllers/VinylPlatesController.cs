using Microsoft.AspNetCore.Mvc;
using VinylStore.Application.Services;
using VinylStore.Contracts;
using VinylStore.Core.Abstractions;
using VinylStore.Core.Abstractions.Services;
using VinylStore.Core.Models;

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
        var vinylPlates = await _vinylPlatesService.GetAll();
        var response = vinylPlates.Select(v => new VinylPlatesResponse(v.Id, v.AlbumId,
            v.CoverUrl, v.Format, v.Condition, v.Description, v.PrintYear, v.Price, v.Manufacturer, v.Count)).ToList();
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> AddVinylPlate([FromBody] VinylPlatesRequest request)
    {
        var (vinylPlates, error) = VinylPlate.Create(Guid.NewGuid(), request.AlbumId,
            request.Condition, request.Description, request.Format, request.CoverUrl,
            request.Manufacturer, request.Price, request.PrintYear, request.Count);
        if (!string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }
        
        var createdPlateId = await _vinylPlatesService.Create(vinylPlates);
        return Ok(createdPlateId);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdateVinylPlate(Guid id, [FromBody] VinylPlatesRequest request)
    {
        var updatedVinylPlateId = await _vinylPlatesService.Update(id, request.AlbumId, request.Condition, request.Description, 
            request.Format, request.CoverUrl, request.Manufacturer, request.Price, request.PrintYear, request.Count);
        return Ok(updatedVinylPlateId);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteVinylPlate(Guid id)
    {
        return Ok(await _vinylPlatesService.Delete(id));
    }
}