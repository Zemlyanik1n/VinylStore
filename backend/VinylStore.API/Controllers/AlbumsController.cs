using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinylStore.Application.Abstractions.Services;
using VinylStore.Application.DTOs.Requests;
using VinylStore.Application.DTOs.Responses;
using VinylStore.Attributes;
using VinylStore.Core.Abstractions.Repositories;
using VinylStore.Core.Enums;
using VinylStore.Core.Models;

namespace VinylStore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlbumsController(IAlbumService albumService) : ControllerBase
{
    private readonly IAlbumService _albumService = albumService;
    
    [HttpGet("catalog")]
    [Authorize]
    [HasPermission(Permissions.ReadAlbums)]
    public async Task<IActionResult> GetPagedAlbums([FromQuery] AlbumsRequest albumsRequest)
    {
        var result = await _albumService.GetAlbumsPaged(albumsRequest);
        if(result.IsFailure)
            return BadRequest(result.Error);
        
        return Ok(result.Value);
    }

    [Authorize]
    [HasPermission(Permissions.DeleteVinyls)]
    [HttpDelete("delete/{albumId:long}")]
    public async Task<IActionResult> DeleteAlbum(long albumId)
    {
        var result = await _albumService.DeleteAlbum(albumId);
        if(result.IsFailure)
            return BadRequest(result.Error);
        return Ok("Album deleted");
    }

    [Authorize]
    [HasPermission(Permissions.CreateVinyls)]
    [HttpPost("add")]
    public async Task<IActionResult> CreateAlbum([FromBody] CreateAlbumRequest request)
    {
        var result = await _albumService.CreateAlbum(request);
        if(result.IsFailure)
            return BadRequest(result.Error);
        return Ok("album created");
    }

}