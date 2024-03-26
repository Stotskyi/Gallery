using GalleryAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GalleryAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UploadingController : Controller
{
    private readonly IAzureBlobService _service;

    public UploadingController(IAzureBlobService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> UploadFile(IFormFile file, [FromForm] string email)
    {
        var response = await _service.UploadFilesAsync(file, email);
        return Ok(response);
    }
}