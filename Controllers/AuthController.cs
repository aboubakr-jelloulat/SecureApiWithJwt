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
    public async Task<IActionResult> Register([FromBody]RegisterModel model)
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
    }


}
