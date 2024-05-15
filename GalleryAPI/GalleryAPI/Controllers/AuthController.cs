using GalleryAPI.BLL.Services.Interfaces;
using GalleryAPI.PL.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GalleryAPI.Controllers;


[Route("[controller]")]
[ApiController]
public class AuthController : Controller
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("get")]
    public  Task<String> GetText() => Task.FromResult("Hello bitch");
    
    
    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp([FromBody] SignUpModel model)
    {
       
        var result = await _userService.RegisterUserAsync(model);
        return Ok(result); 
    }

    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn([FromBody] SignInModel model)
    {

        var result = await _userService.LoginUserAsync(model);
        return Ok(result);
    }
}