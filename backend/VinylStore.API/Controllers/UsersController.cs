using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinylStore.Application.Abstractions.Services;
using VinylStore.Application.DTOs.Requests;

namespace VinylStore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUsersService usersService) : ControllerBase
{
    private readonly IUsersService _usersService = usersService;
    
    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] UserRegisterRequest registerRequest)
    {
        var registerResult = await _usersService.Register(registerRequest);
        if (registerResult.IsFailure)
        {
            return BadRequest(registerResult.Error);
        }
        return Ok();
    }

    /// <summary>
    /// returns auth token
    /// </summary>
    /// <param name="loginRequest"></param>
    /// <returns></returns>
    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] UserLoginRequest loginRequest)
    {
        var token = await _usersService.Login(loginRequest);
        
        if(token.IsFailure)
            return BadRequest(token.Error);
        
        HttpContext.Response.Cookies.Append("cookie", token.Value);
        
        return Ok();
    }

    [Authorize]
    [HttpPost("logout")]
    public async Task<ActionResult> Logout()
    {
        HttpContext.Response.Cookies.Delete("cookie");
        return Ok();
    }


}