using Azure;
using Azure.Storage.Blobs.Models;

namespace GalleryAPI.Interfaces;

public interface IAzureBlobService
{
    Task<String> UploadFilesAsync(IFormFile file,int id);
}