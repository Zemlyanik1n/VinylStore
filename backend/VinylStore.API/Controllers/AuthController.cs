using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinylStore.Application.Abstractions.Auth;
using VinylStore.Application.Abstractions.Services;
using VinylStore.Application.DTOs.Requests;

namespace VinylStore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService, ICurrentUserService currentUserService) : ControllerBase
{
    private readonly IAuthService _authService = authService;
    private readonly ICurrentUserService _currentUserService = currentUserService;

    [Authorize]
    [HttpGet("me")]
    public async Task<IActionResult> GetMe()
    {
        var meResult = await _authService.GetMe();
        
        if(meResult.IsFailure)
            return BadRequest(meResult.Error);
        
        return Ok(meResult.Value);
    }


    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] UserRegisterRequest registerRequest)
    {
        var registerResult = await _authService.Register(registerRequest);
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
    [AllowAnonymous]
    public async Task<ActionResult> Login([FromBody] UserLoginRequest loginRequest)
    {
        var token = await _authService.Login(loginRequest);

        if (token.IsFailure)
            return BadRequest(token.Error);

        HttpContext.Response.Cookies.Append("cookie", token.Value);

        return Ok();
    }

    [Authorize]
    [HttpPost("logout")]
    public ActionResult Logout()
    {
        HttpContext.Response.Cookies.Delete("cookie");
        return Ok();
    }
}