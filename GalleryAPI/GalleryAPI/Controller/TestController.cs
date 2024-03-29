using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GalleryAPI.Controller;

[Route("test")]
[ApiController]
public class TestController : ControllerBase
{
    [HttpGet]
    [Authorize(Roles = "Owner")]
    public string Test()
    {
        return "Okay from aith owner";
    }
}