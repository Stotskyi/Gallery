using System.Security.Claims;
using GalleryAPI.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GalleryAPI.Controllers;


[Route("[controller]")]
[ApiController]
public class ImageController(IImageService imageService, IAzureBlobService azureBlobService)
    : Controller
{
    [HttpGet,Authorize]
    [Route("getAll")]
    public async Task<List<String>> GetFiles([FromServices] IHttpContextAccessor accessor)
    {
        var id =  accessor.HttpContext?.User.Claims
            .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)? 
            .Value;
   
        Int32.TryParse(id, out int res);
        var images =  imageService.GetAllImagesAsync(res).Result;

        List<string> references = new List<string>();
        foreach (var i in images)
        {
            references.Add((i.Uri));
        }

        return references;
    }

    [HttpPost]
    [Route("upload")]
    public async Task<IActionResult> UploadFile([FromForm] IFormFile file,[FromForm] string filename,[FromServices] IHttpContextAccessor accessor)
    {
        var id = accessor.HttpContext?.User.Claims
            .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?
            .Value;
        Int32.TryParse(id, out int res);
        var uri = await azureBlobService.UploadFilesAsync(file, filename,res);
        return Ok(uri);
    }
    
}