using Microsoft.AspNetCore.Http;

namespace GalleryAPI.BLL.Services.Interfaces;

public interface IAzureBlobService
{
    Task<String> UploadFilesAsync(IFormFile file,string filename, int id);
}