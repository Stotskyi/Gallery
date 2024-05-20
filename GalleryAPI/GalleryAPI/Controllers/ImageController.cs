using System.Security.Claims;
using GalleryAPI.BLL.Services.Interfaces;
using GalleryAPI.Core.DTO;
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
    public  List<ImageDto> GetFiles([FromServices] IHttpContextAccessor accessor)
    {
        var id =  accessor.HttpContext?.User.Claims
            .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)? 
            .Value;
   
        Int32.TryParse(id, out int res);
        var images =   imageService.GetAllImagesAsync(res).Result;
        return images;
    }

    [HttpPost,Authorize]
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

    [HttpDelete]
    [Route("delete/{id?}")]
    public async Task<IActionResult> DeleteImage(int id)
    {
        var response =  imageService.DeleteImageAsync(id).Status;
        return Ok(response.ToString());
    }
    
}