using Azure;
using Azure.Storage.Blobs.Models;

namespace GalleryAPI.Interfaces;

public interface IAzureBlobService
{
    Task<String> UploadFilesAsync(IFormFile file, string email);
    Task<Response<BlobInfo>> SetMetadataAsync(string fileName, string email);
}