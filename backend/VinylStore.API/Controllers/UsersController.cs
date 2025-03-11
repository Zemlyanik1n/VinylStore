using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using VinylStore.Application.DTOs.Requests;

namespace VinylStore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpPost("register")]
    public async Task Register([FromBody] UserRegisterRequest registerRequest)
    {
        throw new NotImplementedException();
    }

    [HttpPost("login")]
    public async Task Login([FromBody] UserLoginRequest loginRequest)
    {
        throw new NotImplementedException();
    }


}