using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecureApiWithJwt.Models;
using SecureApiWithJwt.Services;

namespace SecureApiWithJwt.Controllers;


[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("reg")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        if (!ModelState.IsValid)
        {

            return BadRequest(ModelState);
        }


        var result = await _authService.RegisterAsync(model);

        if (!result.IsAuthenticated) // fash kay faild dima katkoun error olla katkoun  IsAuthenticated ba9a false 
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
        //return Ok(new {Token = result.Token, ExpiresOn = result.ExpiresOn} );
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("token")]
    public async Task<IActionResult> GeTokent([FromBody] TokenRequestModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        

        var result = await _authService.GetTokenAsync(model);

        if (!result.IsAuthenticated) // fash kay faild dima katkoun error olla katkoun  IsAuthenticated ba9a false 
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }

    [HttpPost("addRole")]
    public async Task<IActionResult> AddRole([FromBody] AddRoleModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);


        var result = await _authService.AddRoleAsync(model);

        if (!string.IsNullOrEmpty(result))
            return BadRequest(result);
        
        return Ok(model);
    }

}
