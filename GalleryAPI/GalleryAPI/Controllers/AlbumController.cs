using System.Security.Claims;
using GalleryAPI.BLL.Services.Interfaces;
using GalleryAPI.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GalleryAPI.Controllers;
[Route("[controller]")]
[ApiController]
public class AlbumController(IAlbumService albumService) : Controller
{
    [HttpPost,Authorize]
    public async Task<IActionResult> CreateAlbum([FromForm]string name, [FromServices] IHttpContextAccessor accessor)
    {
        var id =  accessor.HttpContext?.User.Claims
            .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)? 
            .Value;
   
        Int32.TryParse(id, out int res);
        
        await albumService.CreateAlbumAsync(name, res);
        
        return Ok("good");
    }

    [HttpPost]
    [Route("AddImages")]
    public async Task<IActionResult> UploadImages(ImagesToAlbumRequest images,int albumId)
    {
        await albumService.UploadImages(images,albumId);
        return Ok("giood");
    }

    [HttpGet]
    [Route("View")]
    public async Task<IActionResult> View(int albumId)
    {
        var images = await albumService.GetImages(albumId);
        return Ok(images);
    }
}
    