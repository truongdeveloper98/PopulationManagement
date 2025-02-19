using Microsoft.AspNetCore.Mvc;
using SWECVI.ApplicationCore.Interfaces.Services;
using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.Web.Controllers;

[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [Route("api/auth/login")]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginDto.Login model)
    {
        
        var result = await _authenticationService.Login(model);
        
        return Ok(result);
    }
}
