using System.Text;
using Azure.Storage.Blobs;
using GalleryAPI.BLL.Services.Interfaces;
using GalleryAPI.DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace GalleryAPI.BLL.Services;

public class AzureBlobService :  IAzureBlobService
{
    private readonly  BlobServiceClient _blobCliet;
    private readonly BlobContainerClient _containerClient;
    private readonly IImageRepository _imageContext;
        
    public AzureBlobService(BlobServiceClient blobClient,IConfiguration configuration, IImageRepository imageContext)
    {
        _blobCliet = blobClient;
        _imageContext = imageContext;
        _containerClient = _blobCliet.GetBlobContainerClient(configuration.GetValue<string>("BlobContainerName"));
    }

    public async Task<String> UploadFilesAsync(IFormFile file,string filename, int id)
    {
        var fileName = new StringBuilder($"{id}/{filename}").ToString();
        BlobClient client = _containerClient.GetBlobClient(fileName);
        var streamContent = file.OpenReadStream();

        var responseFromUploading = await _containerClient.UploadBlobAsync(fileName, streamContent, default);

        await _imageContext.SaveImageAsync(client.Uri.ToString(), id);

        return client.Uri.ToString();
    }

}