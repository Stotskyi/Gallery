using System.Security.Claims;
using GalleryAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GalleryAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UploadingController : Controller
{
    private readonly IAzureBlobService _service;
    private readonly IHttpContextAccessor _accessor;
    public UploadingController(IAzureBlobService service, IHttpContextAccessor accessor)
    {
        _service = service;
        _accessor = accessor;
    }

       [HttpPost]
       [Authorize]
       public async Task<IActionResult> UploadFile(IFormFile file)
       {
           var id = _accessor.HttpContext?.User.Claims
               .FirstOrDefault(c => c.Type == ClaimTypes.Name)?
               .Value;
        
           if (int.TryParse(id, out int userId))
           {
               try
               {
                   var uri = await _service.UploadFilesAsync(file, userId);
                   return Ok(uri);
               }
               catch (Exception ex)
               {
                   return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
               }
           }
           else
           {
               return BadRequest("Invalid user id");
           }
       }
}